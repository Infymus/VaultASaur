using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaultASaur.Config;
using System.Diagnostics;
using VaultASaur.DataBase;
using VaultASaur.Enums;
using VaultASaur.Globals;
using VaultASaur.ToolsBox;
using VaultASaur.Config;

namespace VaultASaur.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Get the Version
            this.Text = $"{Constants.ProgramName} {ToolBox.GetBuildInfoAsString()}";

            // set the form margines, top, left, height, width and then do some checking
            ToolBox.WindowSizePosition(this, Constants.ProgramName, Constants.AppWidth, Constants.AppHeight);

            // create any associated forms { they are done in order!!! }

            // Create Torrents
            this.Shown += MainForm_Shown;

            //StartPercentForm_Update();


            // Check to see if it should start minimized
            /*
            fShowTaskBarIcon := Pref_GetBoolean(tPrefConstants.StartMinimized, False );
            if ( fShowTaskBarIcon ) then
            begin
              Shell_Build_NOTIFYICONDATA;
              Shell_NotifyIcon(NIM_ADD, @IconData);
            end;
            SysTrayTimer.Enabled := true;
          end;
            */
        }

        // #### Events #################################################################################

        private void MainForm_Shown(object sender, EventArgs e)
        {
            MainFormControl.CreateItem(FormControls.FormVault, this.mainDockPanel);
        }

        private void closeButton_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Events
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

        private void HandlePercentUpdate(object sender, string message)
        {
            MessageBox.Show($"Message from {sender.GetType().Name}: {message}");
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainFormControl.CreateItem(FormControls.FormPreferences, this.mainDockPanel);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonVaultClick(object sender, EventArgs e)
        {

        }

        private void buttonLockClick(object sender, EventArgs e)
        {

        }

        private void buttonPasswordClick(object sender, EventArgs e)
        {

        }
    }
}
