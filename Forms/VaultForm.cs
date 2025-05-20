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
using VaultASaur.Objects;
using TaskDialogButton = Ookii.Dialogs.WinForms.TaskDialogButton;

namespace VaultASaur.Forms
{
    public partial class frm_VaultForm : BaseForm
    {
        public tDataGridView DataListGrid = new tDataGridView();
        public delegate void UpdateStuff(int updateCMD);

        public frm_VaultForm()
        {
            InitializeComponent();

            // Set the Caption
            SetCaptionName("VAULT");

            tToolStrip toolBar = new tToolStrip(baseToolBar);

            //
            toolBar.CreateButton(Actions.CMD_NEW, "", buttonCmd => HandleAction(buttonCmd));
            toolBar.CreateButton(Actions.CMD_EDIT, "", buttonCmd => HandleAction(buttonCmd));
            toolBar.CreateButtonSep();
            toolBar.CreateButton(Actions.CMD_ACTIVITY, "", buttonCmd => HandleAction(buttonCmd));
            toolBar.CreateButton(Actions.CMD_VIEW, "", buttonCmd => HandleAction(buttonCmd));
            toolBar.CreateButton(Actions.CMD_OPEN_IN_BROWSER, "", buttonCmd => HandleAction(buttonCmd));
            toolBar.CreateButton(Actions.CMD_URL, "", buttonCmd => HandleAction(buttonCmd));
            toolBar.CreateButtonSep();
            toolBar.CreateButton(Actions.CMD_TOOLBOX, "Toolbox of Useful Tools", buttonCmd => HandleAction(buttonCmd));
            toolBar.AddPopupMenuToButton(Actions.CMD_TOOLBOX);
            toolBar.AddMenuItem(Actions.CMD_TOOLBOX, Actions.CMD_TEST_EXPRESSION, "", cmd => HandleMenuClick(cmd));
            toolBar.CreateButtonSep();
            toolBar.CreateButton(Actions.CMD_DELETE, "", buttonCmd => HandleAction(buttonCmd));

            // Database Grid
            DataListGrid.Init(baseDockPanel);
            DataListGrid.DataSource = dbVault.GridLoadData();
            DataListGrid.AddColumn("DLTYPETEXT", "EN", 25, Color.Black);
            DataListGrid.AddColumn("TITLE", "TITLE", 500, Color.Red);
            DataListGrid.AddColumn("FEEDNAME", "FEED", 120, Color.Red);
            DataListGrid.AddColumn("CATEGORYNAME", "CAT", 120, Color.Red);
            DataListGrid.AddColumn("FEEDDATE", "DATE", 80, Color.Black);
            //
            DataListGrid.AddMenu();
            DataListGrid.AddMenuItem(Actions.CMD_DOWNLOAD_NOW, HandleMenuClick);
            DataListGrid.AddMenuItem(Actions.CMD_DOWNLOAD_QUEUE, HandleMenuClick);
            DataListGrid.CreateButtonSep();
            DataListGrid.AddMenuItem(Actions.CMD_CREATE_FILTER, HandleMenuClick);
            DataListGrid.AddMenuItem(Actions.CMD_OPEN_IN_BROWSER, HandleMenuClick);
            DataListGrid.CreateButtonSep();
            DataListGrid.AddMenuItem(Actions.CMD_VIEW, HandleMenuClick);
            DataListGrid.AddMenuItem(Actions.CMD_EDIT, HandleMenuClick);
            DataListGrid.AddMenuItem(Actions.CMD_DELETE, HandleMenuClick);
            DataListGrid.CreateButtonSep();
            DataListGrid.AddMenuItem(Actions.CMD_CLIPBOARD_ENCLOSURE, HandleMenuClick);
            DataListGrid.AddMenuItem(Actions.CMD_CLIPBOARD_TITLE, HandleMenuClick);
            DataListGrid.CreateButtonSep();
            DataListGrid.AddMenuItem(Actions.CMD_CANCEL, HandleMenuClick);
            statBarLabel.Text = $"{DataListGrid.RowNum.ToString()} of {DataListGrid.Count}";
            DataListGrid.DataSourceChanged += (s, e) => UpdateStatusBar();
            DataListGrid.RowChanged += (s, e) => UpdateStatusBar();
        }

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//

        # region Handle Button and Menu Clicks

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
                case Actions.CMD_VIEW:
                    break;
            }
        }

        #endregion

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//

        #region Event Handlers for Form Designers

        public void RefreshDB()
        {
            var updatedData = dbVault.GridLoadData();
            DataListGrid.DataSource = null;
            DataListGrid.DataSource = updatedData;
            statBarLabel.Text = $"{DataListGrid.RowNum.ToString()} of {DataListGrid.Count}";
        }

        private void UpdateStatusBar()
        {
            statBarLabel.Text = $"{DataListGrid.RowNum.ToString()} of {DataListGrid.Count}";
        }

        private void HandlePercentUpdate(object sender, string message)
        {
            MessageBox.Show($"Message from {sender.GetType().Name}: {message}");
        }

        #endregion

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//




    }
}