using VaultASaur3.DataBase;
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
   public partial class AddEditSiteForm : Form
   {
      private FormResult _PassResult;
      private tToolStrip toolBar;

      public AddEditSiteForm(tVaultRec t)
      {
         InitializeComponent();

         this.Text = $"{Constants.ProgramName} {ToolBox.GetBuildInfoAsString()}";

         toolBar = new tToolStrip(baseToolBar);
         toolBar.RightToLeft = RightToLeft.Yes;
         toolBar.CreateButton(Actions.CMD_CANCEL, "Cancel", buttonCmd => HandleAction(buttonCmd));
         toolBar.CreateButton(Actions.CMD_SAVE, "Save", buttonCmd => HandleAction(buttonCmd));

         db_Password1.Text = t.PASSWORD;
         db_Password2.Text = t.PASSWORD;
         db_PasswordHint.Text = t.PASSHINT;
         db_SiteName.Text = t.SITENAME;
         db_Username.Text = t.USERNAME;
         db_Desc.Text = t.SITEDESC;
         db_Email.Text = t.EMAIL;
         db_URL.Text = t.SITEURL;
         db_Question1.Text = t.SECQUEST1;
         db_Question2.Text = t.SECQUEST2;
         db_Question3.Text = t.SECQUEST3;
         db_active.Checked = (t.IsActive == 1) ? true : false;

         LabelPasswordMatch.Text = errorMessages();
         ShowPasswordCheck.Checked = false;
      }

      private void HandleAction(int buttonCmd)
      {
         switch (buttonCmd)
         {
            case Actions.CMD_SAVE:
               // Validate Passwords are good
               string errMsg = errorMessages();
               if (errMsg != "")
               {
                  Dialog_Box("Warning", "Issues preventing save", $"{errMsg}", new[] { DialogButton.OK }, TaskDialogIcon.Information);
                  return;
               }
               else
               {
                  _PassResult = FormResult.Ok;
                  Close();
               }
               break;
            case Actions.CMD_CANCEL:
               TaskDialogButton cancelBtn;
               cancelBtn = Dialog_Box("Warning", "All changes will be discarded.", "Discard Changes?", new[] { DialogButton.Yes, DialogButton.No }, TaskDialogIcon.Warning);
               if (cancelBtn.Text == DialogButton.No.ToString())
                  return;
               _PassResult = FormResult.Cancel;
               Close();
               break;
         }
      }

      private string errorMessages()
      {
         string errorString = string.Empty;
         if (Password.Length < 8)
            errorString = "* Password must be 8 characters or greater";
         if (!Password.Any(char.IsUpper))
            errorString = "Must contain at least 1 UPPERcase letter (A-Z)";
         if (!Password.Any(char.IsDigit))
            errorString = "* Must contain at least 1 numeric character (0-9)";
         if (Password != PasswordMatch)
            errorString = "* Passwords do NOT match - check validation";
         if (db_Username.Text == "")
            errorString = "* User Name cannot be blank. ";
         if (db_SiteName.Text == "")
            errorString = "* Site Name cannot be blank. ";
         return errorString;
      }

      private void PasswordTextChanged(object sender, EventArgs e)
      {
         LabelPasswordMatch.Text = errorMessages();
      }

      private void db_Password1_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyValue == (char)Keys.Tab)
         {
            db_Password2.Focus();
         }
      }

      private void db_Password2_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyValue == (char)Keys.Tab)
         {
            db_PasswordHint.Focus();
         }
      }

      private void ShowPasswordChanged(object sender, EventArgs e)
      {
         if (ShowPasswordCheck.Checked == false)
         {
            db_Password1.PasswordChar = '*';
            db_Password2.PasswordChar = '*';
            db_Question1.PasswordChar = '*';
            db_Question2.PasswordChar = '*';
            db_Question3.PasswordChar = '*';

         }
         else
         {
            db_Password1.PasswordChar = '\0';
            db_Password2.PasswordChar = '\0';
            db_Question1.PasswordChar = '\0';
            db_Question2.PasswordChar = '\0';
            db_Question3.PasswordChar = '\0';
         }
      }

      private void generatePasswordBtn_Click(object sender, EventArgs e)
      {
         GeneratePasswordForm pwGenerateForm = new GeneratePasswordForm();
         pwGenerateForm.ShowDialog();
         if (pwGenerateForm.PassResult == FormResult.Ok)
         {
            db_Password1.Text = pwGenerateForm.Password;
            db_Password2.Text = pwGenerateForm.Password;
         }
         pwGenerateForm.Close();
      }

      public string Password
      {
         get { return db_Password1.Text; }
      }

      private string PasswordMatch
      {
         get { return db_Password2.Text; }
      }

      public string Hint
      {
         get { return db_PasswordHint.Text; }
      }

      public FormResult PassResult
      {
         get { return _PassResult; }
      }

      public string SiteName
      {
         get { return db_SiteName.Text; }
      }

      public string UserName
      {
         get { return db_Username.Text; }
      }

      public string Desc
      {
         get { return db_Desc.Text; }
      }

      public string Email
      {
         get { return db_Email.Text; }
      }

      public string URL
      {
         get { return db_URL.Text; }
      }

      public string Question1
      {
         get { return db_Question1.Text; }
      }

      public string Question2
      {
         get { return db_Question2.Text; }
      }

      public string Question3
      {
         get { return db_Question3.Text; }
      }

      public int isActive
      {
         get { if (db_active.Checked == true) return 1; else return 0; }
      }

   }
}
