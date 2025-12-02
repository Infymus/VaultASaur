/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/

using VaultASaur3.DataBase;
using VaultASaur3.Enums;
using VaultASaur3.Extensions;

namespace VaultASaur3.Forms
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
            pKeepDays.Text = dbPreference.GetInt(tPrefConstants.AutoClose).ToString();
        }

        private void SetPreferences()
        {
            dbPreference.SetInt(tPrefConstants.AutoClose, Convert.ToInt32(pKeepDays.Text));
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
