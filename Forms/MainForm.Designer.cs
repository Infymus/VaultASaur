namespace VaultASaur.Forms
{
  partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            preferencesToolStripMenuItem = new ToolStripMenuItem();
            torrentCategoriesToolStripMenuItem = new ToolStripMenuItem();
            expressionSetsToolStripMenuItem = new ToolStripMenuItem();
            hideAndSendToTaskbarToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolboxToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            toolStrip = new ToolStrip();
            buttonVault = new ToolStripButton();
            buttonLock = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            buttonPassword = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            buttonClose = new ToolStripButton();
            mainDockPanel = new Panel();
            menuStrip.SuspendLayout();
            toolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolboxToolStripMenuItem, helpToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 24);
            menuStrip.TabIndex = 3;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { preferencesToolStripMenuItem, torrentCategoriesToolStripMenuItem, expressionSetsToolStripMenuItem, hideAndSendToTaskbarToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // preferencesToolStripMenuItem
            // 
            preferencesToolStripMenuItem.Image = (Image)resources.GetObject("preferencesToolStripMenuItem.Image");
            preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            preferencesToolStripMenuItem.Size = new Size(207, 22);
            preferencesToolStripMenuItem.Text = "Preferences";
            preferencesToolStripMenuItem.Click += preferencesToolStripMenuItem_Click;
            // 
            // torrentCategoriesToolStripMenuItem
            // 
            torrentCategoriesToolStripMenuItem.Name = "torrentCategoriesToolStripMenuItem";
            torrentCategoriesToolStripMenuItem.Size = new Size(207, 22);
            torrentCategoriesToolStripMenuItem.Text = "Torrent Categories";
            // 
            // expressionSetsToolStripMenuItem
            // 
            expressionSetsToolStripMenuItem.Name = "expressionSetsToolStripMenuItem";
            expressionSetsToolStripMenuItem.Size = new Size(207, 22);
            expressionSetsToolStripMenuItem.Text = "Expression Sets";
            // 
            // hideAndSendToTaskbarToolStripMenuItem
            // 
            hideAndSendToTaskbarToolStripMenuItem.Name = "hideAndSendToTaskbarToolStripMenuItem";
            hideAndSendToTaskbarToolStripMenuItem.Size = new Size(207, 22);
            hideAndSendToTaskbarToolStripMenuItem.Text = "Hide and Send to Taskbar";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Image = (Image)resources.GetObject("exitToolStripMenuItem.Image");
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(207, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // toolboxToolStripMenuItem
            // 
            toolboxToolStripMenuItem.Name = "toolboxToolStripMenuItem";
            toolboxToolStripMenuItem.Size = new Size(61, 20);
            toolboxToolStripMenuItem.Text = "Toolbox";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // toolStrip
            // 
            toolStrip.ImageScalingSize = new Size(50, 50);
            toolStrip.Items.AddRange(new ToolStripItem[] { buttonVault, buttonLock, toolStripSeparator1, buttonPassword, toolStripSeparator5, buttonClose });
            toolStrip.Location = new Point(0, 24);
            toolStrip.Name = "toolStrip";
            toolStrip.RenderMode = ToolStripRenderMode.Professional;
            toolStrip.Size = new Size(800, 72);
            toolStrip.TabIndex = 4;
            toolStrip.Text = "toolStrip1";
            // 
            // buttonVault
            // 
            buttonVault.Image = (Image)resources.GetObject("buttonVault.Image");
            buttonVault.ImageAlign = ContentAlignment.TopCenter;
            buttonVault.ImageTransparentColor = Color.Magenta;
            buttonVault.Name = "buttonVault";
            buttonVault.Size = new Size(54, 69);
            buttonVault.Text = "Vault";
            buttonVault.TextAlign = ContentAlignment.BottomCenter;
            buttonVault.TextImageRelation = TextImageRelation.ImageAboveText;
            buttonVault.Click += buttonVaultClick;
            // 
            // buttonLock
            // 
            buttonLock.Image = (Image)resources.GetObject("buttonLock.Image");
            buttonLock.ImageAlign = ContentAlignment.TopCenter;
            buttonLock.ImageTransparentColor = Color.Magenta;
            buttonLock.Name = "buttonLock";
            buttonLock.Size = new Size(54, 69);
            buttonLock.Text = "Lock";
            buttonLock.TextAlign = ContentAlignment.BottomCenter;
            buttonLock.TextImageRelation = TextImageRelation.ImageAboveText;
            buttonLock.Click += buttonLockClick;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 72);
            // 
            // buttonPassword
            // 
            buttonPassword.Image = (Image)resources.GetObject("buttonPassword.Image");
            buttonPassword.ImageAlign = ContentAlignment.TopCenter;
            buttonPassword.ImageTransparentColor = Color.Magenta;
            buttonPassword.Name = "buttonPassword";
            buttonPassword.Size = new Size(61, 69);
            buttonPassword.Text = "Password";
            buttonPassword.TextAlign = ContentAlignment.BottomCenter;
            buttonPassword.TextImageRelation = TextImageRelation.ImageAboveText;
            buttonPassword.Click += buttonPasswordClick;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 72);
            // 
            // buttonClose
            // 
            buttonClose.Image = (Image)resources.GetObject("buttonClose.Image");
            buttonClose.ImageAlign = ContentAlignment.TopCenter;
            buttonClose.ImageTransparentColor = Color.Magenta;
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(54, 69);
            buttonClose.Text = "Close";
            buttonClose.TextAlign = ContentAlignment.BottomCenter;
            buttonClose.TextImageRelation = TextImageRelation.ImageAboveText;
            buttonClose.Click += closeButton_Click_1;
            // 
            // mainDockPanel
            // 
            mainDockPanel.Dock = DockStyle.Fill;
            mainDockPanel.Location = new Point(0, 96);
            mainDockPanel.Name = "mainDockPanel";
            mainDockPanel.Size = new Size(800, 354);
            mainDockPanel.TabIndex = 5;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mainDockPanel);
            Controls.Add(toolStrip);
            Controls.Add(menuStrip);
            Name = "MainForm";
            Text = "MainForm";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip;
    private ToolStrip toolStrip;
    private ToolStripButton buttonVault;
    private ToolStripButton buttonLock;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton buttonPassword;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripButton buttonClose;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem toolboxToolStripMenuItem;
    private ToolStripMenuItem helpToolStripMenuItem;
    private Panel mainDockPanel;
        private ToolStripMenuItem preferencesToolStripMenuItem;
        private ToolStripMenuItem torrentCategoriesToolStripMenuItem;
        private ToolStripMenuItem expressionSetsToolStripMenuItem;
        private ToolStripMenuItem hideAndSendToTaskbarToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}