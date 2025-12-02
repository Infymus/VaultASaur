/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/

using VaultASaur3.DataBase;
using VaultASaur3.Encryption;
using VaultASaur3.Enums;
using VaultASaur3.Extensions;
using VaultASaur3.Globals;
using VaultASaur3.ToolsBox;

namespace VaultASaur3.Forms
{
   public partial class PasswordForm : Form
   {
      private FormResult _PassResult;
      private tToolStrip toolBar;

      public PasswordForm()
      {
         InitializeComponent();
         this.Text = $"{Constants.ProgramName} {ToolBox.GetBuildInfoAsString()}";

         string DecKeyStr = dbPreference.GetString(tPrefConstants.Hint);
         string PasswordHint = EncryptDecrypt.Decrypt(DecKeyStr, Constants.bktkobj711A);

         if (PasswordHint != "")
            hintDisplayLabel.Text = PasswordHint;
         else
            hintDisplayLabel.Text = "No Hint Avaialable.";

         toolBar = new tToolStrip(baseToolBar);
         toolBar.RightToLeft = RightToLeft.Yes;
         toolBar.CreateButton(Actions.CMD_CANCEL, "Cancel", buttonCmd => HandleAction(buttonCmd));
         toolBar.CreateButton(Actions.CMD_OK, "Ok", buttonCmd => HandleAction(buttonCmd));

         capsLockWarningLabel.Visible = false;
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
         }
      }

      private void pwTextBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (Control.IsKeyLocked(Keys.CapsLock))
         {
            capsLockWarningLabel.Visible = true;
            capsLockWarningLabel.Text = "Warning: Caps Lock is on!";
         }
         else
         {
            capsLockWarningLabel.Visible = false;
         }

         if (e.KeyChar == (char)Keys.Return)
         {
            if (pwTextBox.Text.Length > 0)
            {
               HandleAction(Actions.CMD_OK);
            }
            else
            {
               HandleAction(Actions.CMD_CANCEL);
            }

         }
      }

      public string Password
      {
         get { return pwTextBox.Text; }
      }

      public FormResult PassResult
      {
         get { return _PassResult; }
      }

   }
}

