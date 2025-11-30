using System;
using System.Runtime.InteropServices;
using VaultASaur3.DataBase;
using VaultASaur3.Encryption;
using VaultASaur3.Enums;
using VaultASaur3.Extensions;
using VaultASaur3.FormControl;
using VaultASaur3.Forms;
using VaultASaur3.Globals;
using VaultASaur3.ToolsBox;
using static VaultASaur3.Extensions.tDialogBox;
using static VaultASaur3.Forms.MainForm.IdleTimeChecker;
using TaskDialogIcon = Ookii.Dialogs.WinForms.TaskDialogIcon;

namespace VaultASaur3.Forms
{
   public partial class MainForm : Form
   {
      private string fPasswordPhrase = string.Empty;
      private bool fPasswordCreated = false;
      private int fVaultSecondsLimit = 300;
      private int fVaultSecondsToLive = 300;

      public MainForm()
      {
         InitializeComponent();
         this.Text = $"{Constants.ProgramName} {ToolBox.GetBuildInfoAsString()}";
         ToolBox.WindowSizePosition(this, Constants.ProgramName, Constants.AppWidth, Constants.AppHeight);
         buttonVault.Enabled = true;
         buttonLock.Enabled = false;
         OpenVault();
      }

      // ##########################################################################################

      private void closeButton_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         // Save the window state as a string ("Normal", "Maximized", "Minimized")
         Properties.Settings.Default.FormState = this.WindowState.ToString();

         // Save the size and location only when the window is in normal state
         if (this.WindowState == FormWindowState.Normal)
         {
            Properties.Settings.Default.FormLocation = this.Location;
            Properties.Settings.Default.FormSize = this.Size;
         }
         else if (this.WindowState == FormWindowState.Maximized)
         {
            Properties.Settings.Default.FormLocation = this.RestoreBounds.Location;
            Properties.Settings.Default.FormSize = this.RestoreBounds.Size;
         }

         // Save the settings
         Properties.Settings.Default.Save();
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         // Restore the window state (normal, maximized, minimized)
         string windowState = Properties.Settings.Default.FormState;

         if (!string.IsNullOrEmpty(windowState))
         {
            switch (windowState)
            {
               case "Maximized":
                  this.WindowState = FormWindowState.Maximized;
                  break;
               case "Minimized":
                  this.WindowState = FormWindowState.Minimized;
                  break;
               default:
                  this.WindowState = FormWindowState.Normal;
                  break;
            }
         }

         // Restore the form size and location if available
         if (Properties.Settings.Default.FormLocation != null &&
             Properties.Settings.Default.FormSize != null)
         {
            this.Location = Properties.Settings.Default.FormLocation;
            this.Size = Properties.Settings.Default.FormSize;
         }
      }

      private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         MainFormControl.CreateItem(FormControls.FormPreferences, this.mainDockPanel);
      }

      private void buttonLockClick(object sender, EventArgs e)
      {
         LockVault();
      }

      private void buttonVault_Click(object sender, EventArgs e)
      {
         OpenVault();
      }

      private void buttonChangePasswordClick(object sender, EventArgs e)
      {
         ChangePassword();
      }

      /// <summary>
      /// Changes the Vault Password.
      /// </summary>
      public void ChangePassword()
      {
         string fOldPassword = string.Empty;
         string fPassHint = string.Empty;

         CheckForPassword();

         if (fPasswordPhrase == "")
         {
            Dialog_Box("Warning", "Vault Access Denied", "A password has never been created. Open the vault to create one.",
                  new[] { DialogButton.OK }, TaskDialogIcon.Shield);
            return;
         }

         // Grab their old password
         PasswordForm passForm = new PasswordForm();
         passForm.ShowDialog();
         if (passForm.PassResult == FormResult.Ok)
         {
            fOldPassword = passForm.Password;
         }
         passForm.Close();

         if (fOldPassword == "")
            return;

         string DecKeyStr = string.Empty;
         string dbPwGuid = dbPreference.GetString(tPrefConstants.GuidPassword);

         try
         {
            DecKeyStr = EncryptDecrypt.Decrypt(dbPwGuid, fOldPassword);
         }
         catch
         {
            // Do Nothing. If the encryption is wrong we mask it.
         }

         // Check to see if they match
         if (DecKeyStr == Constants.VaultPasswordGuid)
         {
            // we can now change the password
            VaultPasswordCreateForm passChangeForm = new VaultPasswordCreateForm();
            passChangeForm.ShowDialog();
            passChangeForm.Close();
            if (passChangeForm.PassResult == FormResult.Ok)
            {
               fPasswordPhrase = passChangeForm.Password;
               fPassHint = passChangeForm.Hint;
            }
            else
            {
               return;
            }

            // Save out the new password
            if (fPasswordPhrase != "")
            {
               SavePassword(fPassHint);
               fPasswordCreated = true;
               dbVault.UpdatePassword(fOldPassword, fPasswordPhrase);
               Dialog_Box("Password Changed", "Password Changed", "VaultASaur Vault Password Created! Don''t Forget It!",
                  new[] { DialogButton.OK }, TaskDialogIcon.Shield);
            }
            else
            {
               Dialog_Box("Warning", "Vault Access Denied", "Password must be set before vault can be accessed. Access to the vault is denied.",
                  new[] { DialogButton.OK }, TaskDialogIcon.Shield);
            }

         }
         else
         {
            Dialog_Box("Warning", "Vault Access Denied", "The password you entered is incorrect. Cannot change Passwords.",
               new[] { DialogButton.OK }, TaskDialogIcon.Shield);
         }
      }

      private void CheckForPassword()
      {
         string passCheckGuid = dbPreference.GetString(tPrefConstants.GuidPassword);
         string fPassHint = string.Empty;

         // If the preference for our Guid check is empty, they haen't created a password yet
         if (passCheckGuid == "")
         {
            // Create a new Password
            VaultPasswordCreateForm passForm = new VaultPasswordCreateForm();
            passForm.ShowDialog();
            if (passForm.PassResult == FormResult.Ok)
            {
               fPasswordPhrase = passForm.Password;
               fPassHint = passForm.Hint;
            }
            passForm.Close();

            if (fPasswordPhrase != "")
            {
               SavePassword(fPassHint);
               fPasswordCreated = true;
               Dialog_Box("Password Changed", "Password Changed", "VaultASaur Vault Password Created! Don''t Forget It!",
                  new[] { DialogButton.OK }, TaskDialogIcon.Shield);
            }
            else
            {
               Dialog_Box("Warning", "Vault Access Denied", "Password must be set before vault can be accessed. Access to the vault is denied.",
                  new[] { DialogButton.OK }, TaskDialogIcon.Shield);
            }
         }
         else
         {
            fPasswordCreated = true;
         }
      }

      public void LockVault()
      {
         fPasswordPhrase = "";
         fPasswordCreated = false;
         MainFormControl.CloseVault();
         buttonVault.Enabled = true;
         buttonLock.Enabled = false;
      }

      /// <summary>
      /// Opens the Vault.
      /// </summary>
      public void OpenVault()
      {
         // Make sure they've actually created a passphrase first
         CheckForPassword();

         // Now ask them for their passphrase
         if (fPasswordCreated == true)
         {
            PasswordForm passForm = new PasswordForm();
            passForm.ShowDialog();
            if (passForm.PassResult == FormResult.Ok)
            {
               fPasswordPhrase = passForm.Password;
            }
            passForm.Close();
         }
         else
         {
            return;
         }

         if (fPasswordPhrase != "")
         {
            // Open the vault if their phassphrase unencrpyts our internal guid correctly
            string dbPwGuid = dbPreference.GetString(tPrefConstants.GuidPassword);
            string DecKeyStr = string.Empty;
            try
            {
               DecKeyStr = EncryptDecrypt.Decrypt(dbPwGuid, fPasswordPhrase);
            }
            catch
            {
               // Do Nothing. If the encryption is wrong we mask it.
            }

            // We have an internal GUID that if it matches, we know they have the right password. Even if
            // they hack this, it would display the vault form - but it would be a massive jumble of garbage.
            // The password/Passphrase is never saved anywhere.
            // They would have to brute force against the GUID and this is the only weakness.
            if (DecKeyStr == Constants.VaultPasswordGuid)
            {
               MainFormControl.PasswordPhrase = fPasswordPhrase;

               MainFormControl.CreateItem(FormControls.FormVault, this.mainDockPanel);
               buttonVault.Enabled = false;
               buttonLock.Enabled = true;
            }
            else
            {
               Dialog_Box("Warning", "Vault Access Denied", "The password you entered is incorrect. Access to the vault is denied.",
                  new[] { DialogButton.OK }, TaskDialogIcon.Shield);
               fPasswordPhrase = "";
            }
         }
         else
         {
            Dialog_Box("Warning", "Vault Access Denied", "The password you entered is incorrect. Access to the vault is denied.",
                  new[] { DialogButton.OK }, TaskDialogIcon.Shield);
            fPasswordPhrase = "";
         }
      }

      private void SavePassword(string fPassHint)
      {
         if (fPasswordPhrase != "")
         {
            // Encrypt our guid with their passphrase and save it
            string DecKeyStr = EncryptDecrypt.Encrypt(Constants.VaultPasswordGuid, fPasswordPhrase);
            dbPreference.SetString(tPrefConstants.GuidPassword, DecKeyStr);
            // Encrypt their password hint with our password and save it
            DecKeyStr = EncryptDecrypt.Encrypt(fPassHint, Constants.bktkobj711A);
            dbPreference.SetString(tPrefConstants.Hint, DecKeyStr);
         }
      }

      /// <summary>
      /// This timer when it counts down to 0 will automatically lock the vault. 
      /// </summary>
      private void Timer_Tick(object sender, EventArgs e)
      {
         if (fPasswordPhrase == "")
         {
            LockLabel.Text = "Vault: LOCKED";
            countDownLabel.Text = "";
            fVaultSecondsToLive = fVaultSecondsLimit;
         }
         else
         {
            LockLabel.Text = "Vault: UNLOCKED";
            // This will get the system idle time.
            // If the system has been idle for more than 1 second, then we count down to 0.

            int fVaultSecondsIdle = IdleTimeChecker.GetIdleTimeSeconds();
            if (fVaultSecondsIdle > 1)
            {
               fVaultSecondsToLive--;
            }
            else
            {
               fVaultSecondsToLive = fVaultSecondsLimit;
            }
            // Update the Label
            countDownLabel.Text = $"Closing in {fVaultSecondsToLive} Seconds";
            if (fVaultSecondsToLive <= 0)
            {
               LockVault();
            }
         }
      }

      /// <summary>
      /// This class checks the idle time of the operating system. We use this so we can close the
      /// vault if they idle for 300 seconds.
      /// </summary>
      public static class IdleTimeChecker
      {
         [StructLayout(LayoutKind.Sequential)]
         public struct LASTINPUTINFO
         {
            public uint cbSize;
            public uint dwTime;
         }

         [DllImport("user32.dll")]
         public static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

         public static int GetIdleTimeSeconds()
         {
            LASTINPUTINFO lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)Marshal.SizeOf(lastInPut);

            if (GetLastInputInfo(ref lastInPut))
            {
               uint tickCount = (uint)Environment.TickCount;
               uint idleTimeMilliseconds = tickCount - lastInPut.dwTime;
               return (int)(idleTimeMilliseconds / 1000);
            }
            else
            {
               return 0;
            }
         }

      }

   }
}