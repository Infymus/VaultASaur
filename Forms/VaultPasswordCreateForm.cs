/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/

using VaultASaur3.Enums;
using VaultASaur3.Extensions;
using VaultASaur3.Globals;
using VaultASaur3.ToolsBox;
using static VaultASaur3.Extensions.tDialogBox;
using TaskDialogIcon = Ookii.Dialogs.WinForms.TaskDialogIcon;

namespace VaultASaur3.Forms
{
   public partial class VaultPasswordCreateForm : Form
   {
      private FormResult _PassResult;
      private tToolStrip toolBar;

      public VaultPasswordCreateForm()
      {
         InitializeComponent();

         this.Text = $"{Constants.ProgramName} {ToolBox.GetBuildInfoAsString()}";

         statusLabel.Text = "The Vault Password is used to encrypt and decrypt using Org.BouncyCastle.Crypto encryption. The " +
            "password is not stored anywhere in VaultASaur - you must type your password in each time you run " +
            "VaultASaur. If you lose this password - you will never be able to view your Vault Items. Passwords " +
            "must contain an uppercase letter (A-Z), a numeric character (0-9) and be a length of 8 or greater. " +
            "Password Phrases are recommended.";

         toolBar = new tToolStrip(baseToolBar);
         toolBar.RightToLeft = RightToLeft.Yes;
         toolBar.CreateButton(Actions.CMD_CANCEL, "Cancel", buttonCmd => HandleAction(buttonCmd));
         toolBar.CreateButton(Actions.CMD_OK, "Ok", buttonCmd => HandleAction(buttonCmd));

         LabelPasswordMatch.Text = errorMessages();
      }

      private void HandleAction(int buttonCmd)
      {
         switch (buttonCmd)
         {
            case Actions.CMD_OK:
               if (ValidatePassword())
               {
                  _PassResult = FormResult.Ok;
                  Close();
               }
               break;
            case Actions.CMD_CANCEL:
               _PassResult = FormResult.Cancel;
               Close();
               break;
         }
      }

      private string errorMessages()
      {
         string errorString = string.Empty;
         if (Password != PasswordMatch)
            errorString = "* Passwords do NOT match - check validation";
         if (Password.Length < 8)
            errorString = "* Password must be 8 characters or greater";
         if (!Password.Any(char.IsUpper))
            errorString = "Must contain at least 1 UPPERcase letter (A-Z)";
         if (!Password.Any(char.IsDigit))
            errorString = "* Must contain at least 1 numeric character (0-9)";
         return errorString;
      }

      private bool ValidatePassword()
      {
         bool validated = true;
         string errorString = errorMessages();
         if (errorString != "")
         {
            Dialog_Box("Password Validation", "Re-Type Passsword", errorString,
                new[] { DialogButton.OK }, TaskDialogIcon.Shield);
            validated = false;
         }

         return validated;
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

   }
}
