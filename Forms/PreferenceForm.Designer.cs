namespace VaultASaur.Forms
{
    partial class frm_PreferenceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            label2 = new Label();
            pKeepDays = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            selectDLDirButton = new Button();
            label5 = new Label();
            pTorrentSaveDirectory = new TextBox();
            button1 = new Button();
            label4 = new Label();
            label3 = new Label();
            pTorrentParam = new TextBox();
            pTorrentApp = new TextBox();
            topNamePanel.SuspendLayout();
            baseBackPanel.SuspendLayout();
            baseDockPanel.SuspendLayout();
            bottomDockPanel.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // baseToolBar
            // 
            baseToolBar.Size = new Size(800, 48);
            // 
            // topNamePanel
            // 
            topNamePanel.Size = new Size(800, 16);
            // 
            // workPanel
            // 
            workPanel.Size = new Size(800, 36);
            // 
            // baseBackPanel
            // 
            baseBackPanel.Size = new Size(800, 450);
            // 
            // baseSepPanel
            // 
            baseSepPanel.Size = new Size(800, 1);
            // 
            // baseDockPanel
            // 
            baseDockPanel.AutoScroll = true;
            baseDockPanel.Controls.Add(groupBox2);
            baseDockPanel.Controls.Add(groupBox1);
            baseDockPanel.Size = new Size(800, 332);
            // 
            // bottomDockPanel
            // 
            bottomDockPanel.Location = new Point(0, 433);
            bottomDockPanel.Size = new Size(800, 17);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(pKeepDays);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(800, 67);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "General Settings";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 33);
            label2.Name = "label2";
            label2.Size = new Size(118, 13);
            label2.TabIndex = 5;
            label2.Text = "(0 = Keep Forever)";
            // 
            // pKeepDays
            // 
            pKeepDays.Location = new Point(6, 32);
            pKeepDays.Name = "pKeepDays";
            pKeepDays.Size = new Size(36, 20);
            pKeepDays.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 16);
            label1.Name = "label1";
            label1.Size = new Size(326, 13);
            label1.TabIndex = 3;
            label1.Text = "Default Number of days to keep Torrent Feed List Items";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(selectDLDirButton);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(pTorrentSaveDirectory);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(pTorrentParam);
            groupBox2.Controls.Add(pTorrentApp);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 67);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(800, 151);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Torrent Application, Parameters and Save Location";
            // 
            // selectDLDirButton
            // 
            selectDLDirButton.Location = new Point(539, 119);
            selectDLDirButton.Name = "selectDLDirButton";
            selectDLDirButton.Size = new Size(75, 23);
            selectDLDirButton.TabIndex = 7;
            selectDLDirButton.Text = "Find";
            selectDLDirButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 104);
            label5.Name = "label5";
            label5.Size = new Size(385, 13);
            label5.TabIndex = 6;
            label5.Text = "Directory to store .Torrent Files (Note: will not work with Magnets)";
            // 
            // pTorrentSaveDirectory
            // 
            pTorrentSaveDirectory.Location = new Point(6, 121);
            pTorrentSaveDirectory.Name = "pTorrentSaveDirectory";
            pTorrentSaveDirectory.Size = new Size(527, 20);
            pTorrentSaveDirectory.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(540, 33);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Find";
            button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 60);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.No;
            label4.Size = new Size(527, 13);
            label4.TabIndex = 3;
            label4.Text = "Torrent Application % Parameters (%T = Torrent Name/Enclosure - %SD = Save Diretory)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 19);
            label3.Name = "label3";
            label3.Size = new Size(199, 13);
            label3.TabIndex = 2;
            label3.Text = "Name and location of Torrent App";
            // 
            // pTorrentParam
            // 
            pTorrentParam.Location = new Point(6, 77);
            pTorrentParam.Name = "pTorrentParam";
            pTorrentParam.Size = new Size(179, 20);
            pTorrentParam.TabIndex = 1;
            // 
            // pTorrentApp
            // 
            pTorrentApp.Location = new Point(6, 35);
            pTorrentApp.Name = "pTorrentApp";
            pTorrentApp.Size = new Size(528, 20);
            pTorrentApp.TabIndex = 0;
            // 
            // frm_PreferenceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "frm_PreferenceForm";
            Text = "Form1";
            topNamePanel.ResumeLayout(false);
            baseBackPanel.ResumeLayout(false);
            baseDockPanel.ResumeLayout(false);
            bottomDockPanel.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button button1;
        private Label label4;
        private Label label3;
        private TextBox pTorrentParam;
        private TextBox pTorrentApp;
        private Label label2;
        private TextBox pKeepDays;
        private Label label1;
        private Button selectDLDirButton;
        private Label label5;
        private TextBox pTorrentSaveDirectory;
    }
}