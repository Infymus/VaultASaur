using System.Data;
using VaultASaur3.DataBase;
using VaultASaur3.Encryption;
using VaultASaur3.Enums;
using VaultASaur3.ErrorHandling;
using VaultASaur3.Extensions;
using VaultASaur3.Objects;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
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

      public frm_VaultForm()
      {
         InitializeComponent();

         // Set the Caption
         SetCaptionName("VAULT");

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
         toolBar.AddMenuItem(Actions.CMD_ACTIVITY, Actions.CMD_ACTIVATE, "Activate Site", cmd => HandleAction(cmd));
         toolBar.AddMenuItem(Actions.CMD_ACTIVITY, Actions.CMD_DEACTIVATE, "Deactivate Site", cmd => HandleAction(cmd));
         toolBar.AddPopupMenuSep(Actions.CMD_ACTIVITY);
         toolBar.AddMenuItem(Actions.CMD_ACTIVITY, Actions.CMD_CANCEL, "Cancel", cmd => HandleAction(cmd));

         // Add a sub menu to the ToolBox
         toolBar.AddPopupMenuToButton(Actions.CMD_TOOLBOX);
         toolBar.AddMenuItem(Actions.CMD_TOOLBOX, Actions.CMD_EXPORT, "Export Database", cmd => HandleAction(cmd));

         // Database Grid
         DataListGrid.Init(torrentListPanel);
         DataListGrid.DataSource = dbVault.GridLoadData();
         DataListGrid.BindingSource.DataSource = DataListGrid.DataSource;
         DataListGrid.AddColumn("SITENAME", "SITE NAME", 300, Color.Red);
         DataListGrid.SearchField = "SITENAME";

         // Add a Pop Menu to the Database Grid
         DataListGrid.AddMenu();
         DataListGrid.AddMenuItem(Actions.CMD_DOWNLOAD_NOW, HandleAction);
         DataListGrid.AddMenuItem(Actions.CMD_DOWNLOAD_QUEUE, HandleAction);
         DataListGrid.CreateButtonSep();
         DataListGrid.AddMenuItem(Actions.CMD_CREATE_FILTER, HandleAction);
         DataListGrid.AddMenuItem(Actions.CMD_OPEN_IN_BROWSER, HandleAction);
         DataListGrid.CreateButtonSep();
         DataListGrid.AddMenuItem(Actions.CMD_VIEW, HandleAction);
         DataListGrid.AddMenuItem(Actions.CMD_EDIT, HandleAction);
         DataListGrid.AddMenuItem(Actions.CMD_DELETE, HandleAction);
         DataListGrid.CreateButtonSep();
         DataListGrid.AddMenuItem(Actions.CMD_CLIPBOARD_ENCLOSURE, HandleAction);
         DataListGrid.AddMenuItem(Actions.CMD_CLIPBOARD_TITLE, HandleAction);
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
               MessageBox.Show("This will CMD_VIEW rss");
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
            case Actions.CMD_HELP:
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
         var updatedData = dbVault.GridLoadData();
         DataListGrid.DataSource = null;
         DataListGrid.DataSource = updatedData;
         UpdateDBState();
      }

      /// <summary>
      /// Called when row moves.
      /// </summary>
      private void UpdateDBState()
      {
         MasterData.UpdateGridCount(ref statBarLabel, ref DataListGrid);

         // Is it empty?
         if (DataListGrid.Count == 0)
         {
            dbState = MasterData.dbState.dsInitialize;
         }

         // enable and disable buttons
         //toolBar.EnableButton(Actions.CMD_DOWNLOAD_NOW, dbEditing);
         //toolBar.EnableButton(Actions.CMD_DOWNLOAD_QUEUE, dbEditing);
         //toolBar.EnableButton(Actions.CMD_EDIT, DataListGrid.Count != 0);
         //toolBar.EnableButton(Actions.CMD_ACTIVITY, dbEditing);
         //toolBar.EnableButton(Actions.CMD_DELETE, dbEditing);
         //toolBar.EnableButton(Actions.CMD_CREATE_FILTER, dbEditing);
         //toolBar.EnableButton(Actions.CMD_VIEW, dbEditing);
         //toolBar.EnableButton(Actions.CMD_OPEN_IN_BROWSER, dbEditing);
         //toolBar.EnableButton(Actions.CMD_URL, dbEditing);
         //toolBar.EnableButton(Actions.CMD_WWW, dbEditing);

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
         AddSiteForm siteForm = new AddSiteForm(t);
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
            DataListGrid.DataSource = dbVault.GridLoadData();
            DataListGrid.MoveToPointer(dbResult.AsLong, "ID");
         }
         siteForm.Close();
      }

      public void EditSite()
      {
         DataRow reader = DataListGrid.GetDataRow();
         tVaultRec t = new tVaultRec
         {
            ID = Convert.ToInt64(reader["ID"]),
            SITENAME = reader["SITENAME"].ToString() ?? string.Empty,
            USERNAME = EncryptDecrypt.Decrypt(reader["USERNAME"].ToString() ?? string.Empty, fPasswordPhrase), 
            PASSWORD = EncryptDecrypt.Decrypt(reader["PASSWORD"].ToString() ?? string.Empty, fPasswordPhrase), 
            EMAIL = reader["EMAIL"].ToString() ?? string.Empty,
            SITEURL = reader["SITEURL"].ToString() ?? string.Empty,
            SECQUEST1 = EncryptDecrypt.Decrypt(reader["SECQUEST1"].ToString() ?? string.Empty, fPasswordPhrase),
            SECQUEST2 = EncryptDecrypt.Decrypt(reader["SECQUEST2"].ToString() ?? string.Empty, fPasswordPhrase),
            SECQUEST3 = EncryptDecrypt.Decrypt(reader["SECQUEST3"].ToString() ?? string.Empty, fPasswordPhrase),
            SECQUEST4 = EncryptDecrypt.Decrypt(reader["SECQUEST4"].ToString() ?? string.Empty, fPasswordPhrase),
            PASSHINT = reader["PASSHINT"].ToString() ?? string.Empty,
            SITEDESC = reader["SITEDESC"].ToString() ?? string.Empty,
            IsActive = Convert.ToInt32(reader["ISACTIVE"])
         };
         AddSiteForm siteForm = new AddSiteForm(t);
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
            DataListGrid.DataSource = dbVault.GridLoadData();
            DataListGrid.MoveToPointer(dbResult.AsLong, "ID");
         }
         siteForm.Close();
      }

      
   }
}
