using VaultASaur3.DataBase;
using VaultASaur3.Enums;
using VaultASaur3.ErrorHandling;
using VaultASaur3.Extensions;
using VaultASaur3.Globals;
using VaultASaur3.Objects;
using VaultASaur3.ToolsBox;
using static VaultASaur3.Extensions.tDialogBox;
using TaskDialogIcon = Ookii.Dialogs.WinForms.TaskDialogIcon;

namespace VaultASaur3.Forms
{
   public partial class GeneratePasswordForm : Form
   {
      private FormResult _PassResult;
      private tToolStrip toolBar;


      public GeneratePasswordForm()
      {

         InitializeComponent();

         this.Text = $"{Constants.ProgramName} {ToolBox.GetBuildInfoAsString()}";

         toolBar = new tToolStrip(baseToolBar);
         toolBar.RightToLeft = RightToLeft.Yes;
         toolBar.CreateButton(Actions.CMD_CANCEL, "Cancel", buttonCmd => HandleAction(buttonCmd));
         toolBar.CreateButton(Actions.CMD_OK, "Ok", buttonCmd => HandleAction(buttonCmd));
         toolBar.CreateButtonSep();
         toolBar.CreateButton(Actions.CMD_GENERATE, "Generate", buttonCmd => HandleAction(buttonCmd));


         statusLabel.Text = $"A strong password has at least 15 characters, uppercase letters, lowercase letters, numbers, symbols, is not like your previous "+
            "passwords, your name or your login, Is not a keyboard pattern, such as qwerty, asdfghjkl, or 12345 and"+
            "Passphrases are best";

         ShowPasswordCheck.Checked = false;
      }

      private void HandleAction(int buttonCmd)
      {
         switch (buttonCmd)
         {
            case Actions.CMD_OK:
               _PassResult = FormResult.Ok;
               Close();
               break;
            case Actions.CMD_CANCEL:
               _PassResult = FormResult.Cancel;
               Close();
               break;
            case Actions.CMD_GENERATE:
               db_Password1.Text = ToolBox.GetRandomPassword(punctCheckBox.Checked, TrackBar.Value);
               break;
         }
      }

      private void ShowPasswordCheck_CheckedChanged(object sender, EventArgs e)
      {
         if (ShowPasswordCheck.Checked == false)
         {
            db_Password1.PasswordChar = '*';
         }
         else
         {
            db_Password1.PasswordChar = '\0';
         }
      }

      private void TrackBar_Scroll(object sender, EventArgs e)
      {
         GenLengthLabel.Text = TrackBar.Value.ToString();
      }

      public string Password
      {
         get { return db_Password1.Text; }
      }
                                  public FormResult PassResult
      {
         get { return _PassResult; }
      }

   }
}
