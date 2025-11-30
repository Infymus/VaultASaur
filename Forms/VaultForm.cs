using System.Data;
using System.Diagnostics;
using System.Security.Policy;
using VaultASaur3.DataBase;
using VaultASaur3.Encryption;
using VaultASaur3.Enums;
using VaultASaur3.ErrorHandling;
using VaultASaur3.Extensions;
using VaultASaur3.Globals;
using VaultASaur3.Objects;
using VaultASaur3.ToolsBox;
using static VaultASaur3.Extensions.tDialogBox;
using TaskDialogButton = Ookii.Dialogs.WinForms.TaskDialogButton;
using TaskDialogIcon = Ookii.Dialogs.WinForms.TaskDialogIcon;

namespace VaultASaur3.Forms
{
   public partial class frm_VaultForm : BaseForm
   {
      private MasterData.dbState dbState = MasterData.dbState.dsInitialize;
      public tDataGridView DataListGrid = new tDataGridView();
      public delegate void UpdateStuff(int updateCMD);
      private tToolStrip toolBar;
      private string fPasswordPhrase;
      private int fVaultSecondsLimit = 300;
      private int fVaultSecondsToLive = 300;
      private ActiveStates dbActive = ActiveStates.StateActive;

      public frm_VaultForm()
      {
         InitializeComponent();

         // Set the Caption
         this.Text = $"Vault - {Constants.ProgramName} {ToolBox.GetBuildInfoAsString()}";

         // Hide Some Defaults
         topNamePanel.Visible = false;
         workPanel.Visible = false;

         // Add a DB Navigator
         tToolStrip dbNav = new tToolStrip(baseDockPanel);
         dbNav.Dock = DockStyle.Left;
         dbNav.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
         dbNav.CreateButton(Actions.CMD_FIRST, "", buttonCmd => HandleAction(buttonCmd));
         dbNav.CreateButton(Actions.CMD_PREV, "", buttonCmd => HandleAction(buttonCmd));
         dbNav.CreateButton(Actions.CMD_NEXT, "", buttonCmd => HandleAction(buttonCmd));
         dbNav.CreateButton(Actions.CMD_LAST, "", buttonCmd => HandleAction(buttonCmd));

         // Add a dock panel next to it
         Panel torrentListPanel = new Panel();
         baseDockPanel.Controls.Add(torrentListPanel);

         // Set the child indexes because Microsoft C# forms suck ass and we have to go by a stupid Z-Order child index
         dbNav.BringToFront();
         torrentListPanel.BringToFront();
         baseDockPanel.Controls.SetChildIndex(torrentListPanel, 0);
         baseDockPanel.Controls.SetChildIndex(dbNav, 1);
         torrentListPanel.Dock = DockStyle.Fill;

         // Add the ToolBar Buttons
         toolBar = new tToolStrip(baseToolBar);
         toolBar.CreateButton(Actions.CMD_NEW, "Create a new Site", buttonCmd => HandleAction(buttonCmd));
         toolBar.CreateButton(Actions.CMD_EDIT, "Edit selected Site", buttonCmd => HandleAction(buttonCmd));
         toolBar.CreateButtonSep();
         toolBar.CreateButton(Actions.CMD_ACTIVITY, "Change Site and View Activity", buttonCmd => HandleAction(buttonCmd));
         toolBar.CreateButton(Actions.CMD_VIEW, "View Site Details", buttonCmd => HandleAction(buttonCmd));
         toolBar.CreateButton(Actions.CMD_WWW, "Open Browser and Visit Site", buttonCmd => HandleAction(buttonCmd));
         toolBar.CreateButton(Actions.CMD_URL, "Copy Site URL to Clipboard", buttonCmd => HandleAction(buttonCmd));
         toolBar.CreateButtonSep();
         toolBar.CreateButton(Actions.CMD_TOOLBOX, "Toolbox of Useful Tools", buttonCmd => HandleAction(buttonCmd));
         toolBar.CreateButtonSep();
         toolBar.CreateButton(Actions.CMD_DELETE, "Delete Site", buttonCmd => HandleAction(buttonCmd));

         // Add a sub menu to the Activity Box
         toolBar.AddPopupMenuToButton(Actions.CMD_ACTIVITY);
         toolBar.AddMenuItem(Actions.CMD_ACTIVITY, Actions.CMD_SHOW_ALL_SITES, "Show AlL Sites", cmd => HandleAction(cmd));
         toolBar.AddMenuItem(Actions.CMD_ACTIVITY, Actions.CMD_SHOW_ACTIVE_SITES, "Show Only Active Sites", cmd => HandleAction(cmd));
         toolBar.AddMenuItem(Actions.CMD_ACTIVITY, Actions.CMD_SHOW_INACTIVE_SITES, "Show Only Inactive Sites", cmd => HandleAction(cmd));
         toolBar.AddPopupMenuSep(Actions.CMD_ACTIVITY);
         toolBar.AddMenuItem(Actions.CMD_ACTIVITY, Actions.CMD_EDIT, "Activate Site", cmd => HandleAction(cmd));
         toolBar.AddPopupMenuSep(Actions.CMD_ACTIVITY);
         toolBar.AddMenuItem(Actions.CMD_ACTIVITY, Actions.CMD_ACTIVATE, "Activate Site", cmd => HandleAction(cmd));
         toolBar.AddMenuItem(Actions.CMD_ACTIVITY, Actions.CMD_DEACTIVATE, "Deactivate Site", cmd => HandleAction(cmd));
         toolBar.AddPopupMenuSep(Actions.CMD_ACTIVITY);
         toolBar.AddMenuItem(Actions.CMD_ACTIVITY, Actions.CMD_CANCEL, "Cancel", cmd => HandleAction(cmd));

         // Add a sub menu to the ToolBox
         toolBar.AddPopupMenuToButton(Actions.CMD_TOOLBOX);
         toolBar.AddMenuItem(Actions.CMD_TOOLBOX, Actions.CMD_EXPORT, "Export Database", cmd => HandleAction(cmd));

         // Database Grid
         DataListGrid.Init(torrentListPanel, "FNAME");
         DataListGrid.DataSource = dbVault.GridLoadData(dbActive);
         DataListGrid.BindingSource.DataSource = DataListGrid.DataSource;
         DataListGrid.AddColumn("SITENAME", "SITE NAME", 300, Color.Red);
         DataListGrid.SearchField = "SITENAME";

         // Add a Pop Menu to the Database Grid
         DataListGrid.AddMenu();
         DataListGrid.AddMenuItem(Actions.CMD_SHOW_ALL_SITES, HandleAction);
         DataListGrid.AddMenuItem(Actions.CMD_SHOW_ACTIVE_SITES, HandleAction);
         DataListGrid.AddMenuItem(Actions.CMD_SHOW_INACTIVE_SITES, HandleAction);
         DataListGrid.CreateButtonSep();
         DataListGrid.AddMenuItem(Actions.CMD_EDIT, HandleAction);
         DataListGrid.CreateButtonSep();
         DataListGrid.AddMenuItem(Actions.CMD_ACTIVATE, HandleAction);
         DataListGrid.AddMenuItem(Actions.CMD_DEACTIVATE, HandleAction);
         DataListGrid.CreateButtonSep();
         DataListGrid.AddMenuItem(Actions.CMD_CANCEL, HandleAction);

         // Database Grid
         DataListGrid.DataSourceChanged += (s, e) => UpdateDBState();
         DataListGrid.RowChanged += (s, e) => UpdateDBState();

         // Finished
         UpdateDBState();
      }

      //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//

      // Handles Button Click
      private void HandleAction(int buttonCmd)
      {
         switch (buttonCmd)
         {
            case Actions.CMD_VIEW:
               ViewSite();
               break;
            case Actions.CMD_TOOLBOX:
               break;
            case Actions.CMD_NEW:
               NewSite();
               break;
            case Actions.CMD_EDIT:
               EditSite();
               break;
            case Actions.CMD_DELETE:
               DeleteSelectedRows();
               break;
            case Actions.CMD_FIRST:
               DataListGrid.MoveFirstRow();
               break;
            case Actions.CMD_PREV:
               DataListGrid.MovePreviousRow();
               break;
            case Actions.CMD_NEXT:
               DataListGrid.MoveNextRow();
               break;
            case Actions.CMD_LAST:
               DataListGrid.MoveLastRow();
               break;
            case Actions.CMD_WWW:
               OpenWWW();
               break;
            case Actions.CMD_URL:
               CopyURL();
               break;
            case Actions.CMD_SHOW_ALL_SITES:
               dbActive = ActiveStates.StateAll;
               RefreshDB();
               break;
            case Actions.CMD_SHOW_ACTIVE_SITES:
               dbActive = ActiveStates.StateActive;
               RefreshDB();
               break;
            case Actions.CMD_SHOW_INACTIVE_SITES:
               dbActive = ActiveStates.StateInactive;
               RefreshDB();
               break;
            case Actions.CMD_ACTIVATE:
               ActivateDeactivate(ActiveStates.StateActive);
               break;
            case Actions.CMD_DEACTIVATE:
               ActivateDeactivate(ActiveStates.StateInactive);
               break;
            case Actions.CMD_EXPORT:
               ExportSites();
               break;
         }
      }

      //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//

      public string PasswordPhrase
      {
         get { return fPasswordPhrase; }
         set { fPasswordPhrase = value; }
      }

      /// <summary>
      /// Called whenever grid refreshes.
      /// </summary>
      public void RefreshDB()
      {
         var updatedData = dbVault.GridLoadData(dbActive);
         DataListGrid.DataSource = null;
         DataListGrid.DataSource = updatedData;
         UpdateDBState();
      }

      /// <summary>
      /// Called when row moves.
      /// </summary>
      private void UpdateDBState()
      {
         if (DataListGrid.Count == 0)
         {
            statBarLabel.Text = "0 Sites";
         }
         else
         {
            statBarLabel.Text = $"{DataListGrid.RowNum.ToString()} of {DataListGrid.Count} Vault Sites";
            switch (dbActive)
            {
               case ActiveStates.StateActive:
                  statBarLabel.Text += " | Active Sites Only";
                  break;
               case ActiveStates.StateInactive:
                  statBarLabel.Text += " | Inactive Sites Only";
                  break;
               case ActiveStates.StateAll:
                  statBarLabel.Text += " | All Sites";
                  break;
            }
         }

         // Is it empty?
         if (DataListGrid.Count == 0)
         {
            dbState = MasterData.dbState.dsInitialize;
         }

         // Enable and disable buttons depending on state of the DB
         toolBar.EnableButton(Actions.CMD_VIEW, DataListGrid.Count > 0);
         toolBar.EnableButton(Actions.CMD_EDIT, DataListGrid.Count > 0);
         toolBar.EnableButton(Actions.CMD_DELETE, DataListGrid.Count > 0);
         toolBar.EnableButton(Actions.CMD_FIRST, DataListGrid.Count > 0);
         toolBar.EnableButton(Actions.CMD_PREV, DataListGrid.Count > 0);
         toolBar.EnableButton(Actions.CMD_NEXT, DataListGrid.Count > 0);
         toolBar.EnableButton(Actions.CMD_LAST, DataListGrid.Count > 0);
         toolBar.EnableButton(Actions.CMD_DELETE, DataListGrid.Count > 0);
         toolBar.EnableButton(Actions.CMD_ACTIVATE, DataListGrid.Count > 0);
         toolBar.EnableButton(Actions.CMD_DEACTIVATE, DataListGrid.Count > 0);

         // DB specific
         tVaultRec t = dbVault.GetDTRow(DataListGrid, fPasswordPhrase);
         toolBar.EnableButton(Actions.CMD_URL, DataListGrid.Count > 0 && t.SITEURL != "");
         toolBar.EnableButton(Actions.CMD_WWW, DataListGrid.Count > 0 && t.SITEURL != "");
      }

      private void HandlePercentUpdate(object sender, string message)
      {
         MessageBox.Show($"Message from {sender.GetType().Name}: {message}");
      }

      //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//


      /// <summary>
      /// Deletes all of the selected rows in the grid.
      /// </summary>
      public void DeleteSelectedRows()
      {
         var selectedRows = DataListGrid.GetSelectedDataRows();
         if (selectedRows != null)
         {
            TaskDialogButton warning;
            warning = Dialog_Box("Warning", $"{selectedRows.Count} Rows Selected", "Delete Selected Rows?",
                new[] { DialogButton.OK, DialogButton.Cancel }, TaskDialogIcon.Information);
            if (warning.Text == DialogButton.Cancel.ToString())
               return;
            foreach (DataRow row in selectedRows)
            {
               MasterData.Delete(dbTypes.Vault, row["ID"].ToString());
            }
            RefreshDB();
         }
      }

      /// <summary>
      /// Deletes ALL of the rows in the grid.
      /// </summary>
      public void DeleteAllRows()
      {
         TaskDialogButton warning;
         warning = Dialog_Box("Warning", $"This will delete ALL Vault Items", "Are you sure?",
             new[] { DialogButton.OK, DialogButton.Cancel }, TaskDialogIcon.Information);
         if (warning.Text == DialogButton.Cancel.ToString())
            return;
         MasterData.DeleteAll(dbTypes.Vault);
         RefreshDB();
         RefreshDB();
      }


      public void ResizeEvent(object sender, EventArgs e)
      {
         // Resize the UN and PW buttons
         int parentHeight = this.ClientSize.Height;
         int parH = parentHeight / 2;
         parH -= 30;
         if (parH < 10)
         {
            parH = 10;
         }
         unButton.Height = parH;
         pwButton.Height = parentHeight / 2;

         // Resize the DB Column
         DataListGrid.ResizeColumn("SITE NAME", this.ClientSize.Width - 75);
      }

      public void NewSite()
      {
         tVaultRec t = new tVaultRec();
         AddEditSiteForm siteForm = new AddEditSiteForm(t);
         siteForm.ShowDialog();
         if (siteForm.PassResult == FormResult.Ok)
         {
            t.IsActive = siteForm.isActive;
            t.SITENAME = siteForm.SiteName;
            t.USERNAME = EncryptDecrypt.Encrypt(siteForm.UserName, fPasswordPhrase);
            t.SITEDESC = siteForm.Desc;
            t.PASSWORD = EncryptDecrypt.Encrypt(siteForm.Password, fPasswordPhrase);
            t.EMAIL = siteForm.Email;
            t.SITEURL = siteForm.URL;
            t.SECQUEST1 = EncryptDecrypt.Encrypt(siteForm.Question1, fPasswordPhrase);
            t.SECQUEST2 = EncryptDecrypt.Encrypt(siteForm.Question2, fPasswordPhrase);
            t.SECQUEST3 = EncryptDecrypt.Encrypt(siteForm.Question3, fPasswordPhrase);
            t.SECQUEST4 = EncryptDecrypt.Encrypt("", fPasswordPhrase);
            t.PASSHINT = siteForm.Hint;
            tErrorResult dbResult = dbVault.Add(t);
            DataListGrid.DataSource = dbVault.GridLoadData(dbActive);
            DataListGrid.MoveToPointer(dbResult.AsLong, "ID");
         }
         siteForm.Close();
      }

      public void EditSite()
      {
         if (DataListGrid.Count == 0)
            return;
         tVaultRec t = dbVault.GetDTRow(DataListGrid, fPasswordPhrase);
         AddEditSiteForm siteForm = new AddEditSiteForm(t);
         siteForm.ShowDialog();
         if (siteForm.PassResult == FormResult.Ok)
         {
            t.IsActive = siteForm.isActive;
            t.SITENAME = siteForm.SiteName;
            t.USERNAME = EncryptDecrypt.Encrypt(siteForm.UserName, fPasswordPhrase);
            t.SITEDESC = siteForm.Desc;
            t.PASSWORD = EncryptDecrypt.Encrypt(siteForm.Password, fPasswordPhrase);
            t.EMAIL = siteForm.Email;
            t.SITEURL = siteForm.URL;
            t.SECQUEST1 = EncryptDecrypt.Encrypt(siteForm.Question1, fPasswordPhrase);
            t.SECQUEST2 = EncryptDecrypt.Encrypt(siteForm.Question2, fPasswordPhrase);
            t.SECQUEST3 = EncryptDecrypt.Encrypt(siteForm.Question3, fPasswordPhrase);
            t.SECQUEST4 = EncryptDecrypt.Encrypt("", fPasswordPhrase);
            t.PASSHINT = siteForm.Hint;
            tErrorResult dbResult = dbVault.Update(t);
            DataListGrid.DataSource = dbVault.GridLoadData(dbActive);
            DataListGrid.MoveToPointer(dbResult.AsLong, "ID");
         }
         siteForm.Close();
      }

      public void ActivateDeactivate(ActiveStates inState)
      {
         tVaultRec t = dbVault.GetDTRow(DataListGrid, fPasswordPhrase);
         if (inState == ActiveStates.StateActive)
            t.IsActive = 1;
         if (inState == ActiveStates.StateInactive)
            t.IsActive = 0;
         dbVault.Encrypt(ref t, fPasswordPhrase);
         tErrorResult dbResult = dbVault.Update(t);
         DataListGrid.DataSource = dbVault.GridLoadData(dbActive);
         DataListGrid.MoveToPointer(dbResult.AsLong, "ID");
      }

      public void ViewSite()
      {
         tVaultRec t = dbVault.GetDTRow(DataListGrid, fPasswordPhrase);
         ViewSiteForm siteViewForm = new ViewSiteForm();
         siteViewForm.UserName = t.USERNAME;
         siteViewForm.Sitename = t.SITENAME;
         siteViewForm.Password = t.PASSWORD;
         siteViewForm.isActive = t.IsActive == 1 ? true : false;
         siteViewForm.SiteURL = t.SITEURL;
         siteViewForm.SecQuest1 = t.SECQUEST1;
         siteViewForm.SecQuest2 = t.SECQUEST2;
         siteViewForm.SecQuest3 = t.SECQUEST3;
         siteViewForm.PassHint = t.PASSHINT;
         siteViewForm.UpdateDB();
         siteViewForm.ShowDialog();
         siteViewForm.Close();
      }

      public void CopyURL()
      {
         tVaultRec t = dbVault.GetDTRow(DataListGrid, fPasswordPhrase);
         if (t.SITEURL != "")
            Clipboard.SetText(t.SITEURL);
      }

      public void OpenWWW()
      {
         tVaultRec t = dbVault.GetDTRow(DataListGrid, fPasswordPhrase);
         if (t.SITEURL != "")
         {
            Process.Start(new ProcessStartInfo
            {
               FileName = t.SITEURL,
               UseShellExecute = true
            });
         }
      }
      private void unButton_Click(object sender, EventArgs e)
      {
         tVaultRec t = dbVault.GetDTRow(DataListGrid, fPasswordPhrase);
         Clipboard.SetText(t.USERNAME);
      }

      private void pwButton_Click(object sender, EventArgs e)
      {
         tVaultRec t = dbVault.GetDTRow(DataListGrid, fPasswordPhrase);
         Clipboard.SetText(t.PASSWORD);
      }

      public void ExportSites()
      {
         TaskDialogButton warning;
         warning = Dialog_Box("Warning", $"WARNING: It is risky to export your Vault Site Database to an unencrypted JSON file!", "Are you sure?",
                      new[] { DialogButton.OK, DialogButton.Cancel }, TaskDialogIcon.Information);
         if (warning.Text == DialogButton.Cancel.ToString())
            return;
         
         open a dialog form, if they click save, then save it, else cancel it

         dbVault.ExportDatabase(fPasswordPhrase);
      }

   }
}
