using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaultASaur.DataBase;
using VaultASaur.Enums;
using VaultASaur.Extensions;
using VaultASaur.Images;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Ookii.Dialogs.WinForms;
using static VaultASaur.Extensions.tDialogBox;
using TaskDialogIcon = Ookii.Dialogs.WinForms.TaskDialogIcon;

namespace VaultASaur.Forms
{
    public partial class frm_PreferenceForm : BaseForm
    {
        public frm_PreferenceForm()
        {
            InitializeComponent();

            // Set the Caption
            SetCaptionName("RSS TORRENTS");

            // All Else
            this.bottomDockPanel.Visible = false;
            tToolStrip toolBar = new tToolStrip(baseToolBar);

            // Menu 
            toolBar.CreateButton(Actions.CMD_SAVE, "", buttonCmd => HandleAction(buttonCmd));

            // Get the Preferences
            GetPreferences();
        }

        // Handle Menu Click
        private void HandleMenuClick(int inCommandCMD)
        {
            switch (inCommandCMD)
            {
                case Actions.CMD_TORRENT_WEBSITE_SCRAPE:
                    break;
            }
        }

        // Handles Button Click
        private void HandleAction(int buttonCmd)
        {
            switch (buttonCmd)
            {
                case Actions.CMD_SAVE:
                    SetPreferences();
                    break;
            }
        }

        private void GetPreferences()
        {
            //pKeepDays.Text = dbPreference.GetInt(tPrefConstants.KeepDay).ToString();
            //pTorrentApp.Text = dbPreference.GetString(tPrefConstants.TorrentApp);
            //pTorrentParam.Text = dbPreference.GetString(tPrefConstants.TorrentParam);
            //pTorrentSaveDirectory.Text = dbPreference.GetString(tPrefConstants.TorrentSaveDirectory);
        }

        private void SetPreferences()
        {
            //dbPreference.SetInt(tPrefConstants.KeepDay, Convert.ToInt32(pKeepDays.Text));
            //dbPreference.SetString(tPrefConstants.TorrentApp, pTorrentApp.Text);
            //dbPreference.SetString(tPrefConstants.TorrentParam, pTorrentParam.Text);
            //dbPreference.SetString(tPrefConstants.TorrentSaveDirectory, pTorrentSaveDirectory.Text);
        }

        private void pKeepDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Suppress the key
            }
        }
    }
}
