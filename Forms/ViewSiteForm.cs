/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/

using VaultASaur3.Extensions;
using VaultASaur3.Globals;
using VaultASaur3.ToolsBox;

namespace VaultASaur3.Forms
{
   public partial class ViewSiteForm : BaseForm
   {
      private tToolStrip toolBar;
      private string fPasswordPhrase;

      public ViewSiteForm()
      {
         InitializeComponent();

         // Set the Caption
         this.Text = $"View Site - {Constants.ProgramName} {ToolBox.GetBuildInfoAsString()}";

         // Hide Some Defaults
         topNamePanel.Visible = false;
         bottomDockPanel.Visible = false;

         // Add the ToolBar Buttons
         toolBar = new tToolStrip(baseToolBar);
         toolBar.CreateButton(Actions.CMD_COPY_USERNAME, "Open Browser and Visit Site", buttonCmd => HandleAction(buttonCmd));
         toolBar.CreateButton(Actions.CMD_COPY_PASSWORD, "View Site Details", buttonCmd => HandleAction(buttonCmd));
         toolBar.CreateButtonSep();
         toolBar.CreateButton(Actions.CMD_COPY_URL, "Change Site and View Activity", buttonCmd => HandleAction(buttonCmd));
         toolBar.CreateButtonSep();
         toolBar.CreateButton(Actions.CMD_CLOSE, "Close", buttonCmd => HandleAction(buttonCmd));

         // Hide Everything
         db_Password1.PasswordChar = '#';
         db_Question1.PasswordChar = '#';
         db_Question2.PasswordChar = '#';
         db_Question3.PasswordChar = '#';
      }

      // Handles Button Click
      private void HandleAction(int buttonCmd)
      {
         switch (buttonCmd)
         {
            case Actions.CMD_CLOSE:
               Close();
               break;
            case Actions.CMD_COPY_URL:
               Clipboard.SetText(db_URL.Text);
               break;
            case Actions.CMD_COPY_PASSWORD:
               Clipboard.SetText(db_Password1.Text);
               break;
            case Actions.CMD_COPY_USERNAME:
               Clipboard.SetText(db_Username.Text);
               break;
         }
      }

      private void ShowPasswordCheck_CheckedChanged(object sender, EventArgs e)
      {
         if (ShowPasswordCheck.Checked == false)
         {
            db_Password1.PasswordChar = '#';
            db_Question1.PasswordChar = '#';
            db_Question2.PasswordChar = '#';
            db_Question3.PasswordChar = '#';

         }
         else
         {
            db_Password1.PasswordChar = '\0';
            db_Question1.PasswordChar = '\0';
            db_Question2.PasswordChar = '\0';
            db_Question3.PasswordChar = '\0';
         }
      }

      public void UpdateDB()
      {
         if (db_Password1.Text == "")
            toolBar.EnableButton(Actions.CMD_COPY_PASSWORD, false);
         if (db_URL.Text == "")
            toolBar.EnableButton(Actions.CMD_COPY_URL, false);
         if (db_Username.Text == "")
            toolBar.EnableButton(Actions.CMD_COPY_USERNAME, false);
      }

      private void db_active_Click(object sender, EventArgs e)
      {
         db_active.SuspendLayout();

         db_active.Checked = !db_active.Checked;
         db_active.ResumeLayout();
      }

      public string PasswordPhrase
      {
         get { return fPasswordPhrase; }
         set { fPasswordPhrase = value; }
      }

      public string UserName
      {
         set { db_Username.Text = value; }
      }

      public string Sitename
      {
         set { db_SiteName.Text = value; }
      }

      public string Password
      {
         set { db_Password1.Text = value; }
      }

      public bool isActive
      {
         set { db_active.Checked = value; }
      }

      public string SiteURL
      {
         set { db_URL.Text = value; }
      }

      public string SecQuest1
      {
         set { db_Question1.Text = value; }
      }

      public string SecQuest2
      {
         set { db_Question2.Text = value; }
      }

      public string SecQuest3
      {
         set { db_Question3.Text = value; }
      }

      public string PassHint
      {
         set { db_PasswordHint.Text = value; }
      }

   }
}
