using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaultASaur3.DataBase;
using VaultASaur3.Enums;
using VaultASaur3.Extensions;
using VaultASaur3.Images;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Ookii.Dialogs.WinForms;
using static VaultASaur3.Extensions.tDialogBox;
using TaskDialogIcon = Ookii.Dialogs.WinForms.TaskDialogIcon;

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
      //                public enum tPrefConstants
                //{
                //    // General Preferences
                //    RegionCode,
                //    dbGridColorGridLines,
                //    CheckForUpdates,
                //    EditorLoadSaveButtons,
                //    // Topics
                //    topicSortView,
                //    topicIsActive,
                //    DBTopicGridWidth,
                //    //
                //    TorrentApp,
                //    TorrentParam,
                //    PromptDownload,
                //    TorrentFilterAdd,
                //    FeedDBNavPanelVisible,
                //    KeepDay,
                //    TorrentSaveDirectory,
                //    TorrentSaveType,
                //    AskToQuit,
                //    LogFile,
                //    AllowDuplicateFeedTitles,
                //    FilterMatchDownloadOrQueue,
                //    StartMinimized,
                //    DeepLogging,
                //    StopOnRSSGetFailure,
                //    ReProcessRSSFeeds,
                //    RSSOptionTorrentOrMagnet,
                //    DownloadFeedQueueDelay,
                //    StripTorrentEnclosures
                //}
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
