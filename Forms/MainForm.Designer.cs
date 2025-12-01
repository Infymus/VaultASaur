namespace VaultASaur3.Forms
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
         components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         menuStrip = new MenuStrip();
         fileToolStripMenuItem = new ToolStripMenuItem();
         preferencesToolStripMenuItem = new ToolStripMenuItem();
         exitToolStripMenuItem = new ToolStripMenuItem();
         helpToolStripMenuItem = new ToolStripMenuItem();
         toolStrip = new ToolStrip();
         buttonVault = new ToolStripButton();
         buttonLock = new ToolStripButton();
         toolStripSeparator1 = new ToolStripSeparator();
         buttonChangePassword = new ToolStripButton();
         toolStripSeparator2 = new ToolStripSeparator();
         buttonClose = new ToolStripButton();
         Timer = new System.Windows.Forms.Timer(components);
         statusStrip1 = new StatusStrip();
         LockLabel = new ToolStripStatusLabel();
         countDownLabel = new ToolStripStatusLabel();
         mainDockPanel = new Panel();
         menuStrip.SuspendLayout();
         toolStrip.SuspendLayout();
         statusStrip1.SuspendLayout();
         SuspendLayout();
         // 
         // menuStrip
         // 
         menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
         menuStrip.Location = new Point(0, 0);
         menuStrip.Name = "menuStrip";
         menuStrip.Size = new Size(330, 24);
         menuStrip.TabIndex = 3;
         menuStrip.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { preferencesToolStripMenuItem, exitToolStripMenuItem });
         fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         fileToolStripMenuItem.Size = new Size(37, 20);
         fileToolStripMenuItem.Text = "File";
         // 
         // preferencesToolStripMenuItem
         // 
         preferencesToolStripMenuItem.Image = (Image)resources.GetObject("preferencesToolStripMenuItem.Image");
         preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
         preferencesToolStripMenuItem.Size = new Size(135, 22);
         preferencesToolStripMenuItem.Text = "Preferences";
         preferencesToolStripMenuItem.Click += preferencesToolStripMenuItem_Click;
         // 
         // exitToolStripMenuItem
         // 
         exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         exitToolStripMenuItem.Size = new Size(135, 22);
         // 
         // helpToolStripMenuItem
         // 
         helpToolStripMenuItem.Name = "helpToolStripMenuItem";
         helpToolStripMenuItem.Size = new Size(44, 20);
         helpToolStripMenuItem.Text = "Help";
         // 
         // toolStrip
         // 
         toolStrip.BackColor = Color.White;
         toolStrip.ImageScalingSize = new Size(50, 50);
         toolStrip.Items.AddRange(new ToolStripItem[] { buttonVault, buttonLock, toolStripSeparator1, buttonChangePassword, toolStripSeparator2, buttonClose });
         toolStrip.Location = new Point(0, 24);
         toolStrip.Name = "toolStrip";
         toolStrip.RenderMode = ToolStripRenderMode.Professional;
         toolStrip.Size = new Size(330, 72);
         toolStrip.TabIndex = 4;
         toolStrip.Text = "toolStrip1";
         // 
         // buttonVault
         // 
         buttonVault.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
         buttonVault.Image = (Image)resources.GetObject("buttonVault.Image");
         buttonVault.ImageAlign = ContentAlignment.TopCenter;
         buttonVault.ImageTransparentColor = Color.Magenta;
         buttonVault.Name = "buttonVault";
         buttonVault.Size = new Size(54, 69);
         buttonVault.Text = "Vault";
         buttonVault.TextAlign = ContentAlignment.BottomCenter;
         buttonVault.TextImageRelation = TextImageRelation.ImageAboveText;
         buttonVault.Click += buttonVault_Click;
         // 
         // buttonLock
         // 
         buttonLock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
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
         // buttonChangePassword
         // 
         buttonChangePassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
         buttonChangePassword.Image = (Image)resources.GetObject("buttonChangePassword.Image");
         buttonChangePassword.ImageAlign = ContentAlignment.TopCenter;
         buttonChangePassword.ImageTransparentColor = Color.Magenta;
         buttonChangePassword.Name = "buttonChangePassword";
         buttonChangePassword.Size = new Size(63, 69);
         buttonChangePassword.Text = "Password";
         buttonChangePassword.TextAlign = ContentAlignment.BottomCenter;
         buttonChangePassword.TextImageRelation = TextImageRelation.ImageAboveText;
         buttonChangePassword.Click += buttonChangePasswordClick;
         // 
         // toolStripSeparator2
         // 
         toolStripSeparator2.Name = "toolStripSeparator2";
         toolStripSeparator2.Size = new Size(6, 72);
         // 
         // buttonClose
         // 
         buttonClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
         buttonClose.Image = (Image)resources.GetObject("buttonClose.Image");
         buttonClose.ImageAlign = ContentAlignment.TopCenter;
         buttonClose.ImageTransparentColor = Color.Magenta;
         buttonClose.Name = "buttonClose";
         buttonClose.Size = new Size(54, 69);
         buttonClose.Text = "Close";
         buttonClose.TextAlign = ContentAlignment.BottomCenter;
         buttonClose.TextImageRelation = TextImageRelation.ImageAboveText;
         buttonClose.Click += closeButton_Click;
         // 
         // Timer
         // 
         Timer.Enabled = true;
         Timer.Interval = 1000;
         Timer.Tick += Timer_Tick;
         // 
         // statusStrip1
         // 
         statusStrip1.BackColor = Color.IndianRed;
         statusStrip1.Font = new Font("Tahoma", 9F, FontStyle.Bold);
         statusStrip1.Items.AddRange(new ToolStripItem[] { LockLabel, countDownLabel });
         statusStrip1.Location = new Point(0, 250);
         statusStrip1.Name = "statusStrip1";
         statusStrip1.Size = new Size(330, 22);
         statusStrip1.TabIndex = 6;
         statusStrip1.Text = "statusStrip1";
         // 
         // LockLabel
         // 
         LockLabel.ForeColor = Color.Yellow;
         LockLabel.Name = "LockLabel";
         LockLabel.Size = new Size(67, 17);
         LockLabel.Text = "LockLabel";
         // 
         // countDownLabel
         // 
         countDownLabel.Name = "countDownLabel";
         countDownLabel.Size = new Size(0, 17);
         // 
         // mainDockPanel
         // 
         mainDockPanel.Dock = DockStyle.Fill;
         mainDockPanel.Location = new Point(0, 96);
         mainDockPanel.Name = "mainDockPanel";
         mainDockPanel.Size = new Size(330, 154);
         mainDockPanel.TabIndex = 7;
         // 
         // MainForm
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(330, 272);
         Controls.Add(mainDockPanel);
         Controls.Add(statusStrip1);
         Controls.Add(toolStrip);
         Controls.Add(menuStrip);
         Icon = (Icon)resources.GetObject("$this.Icon");
         Name = "MainForm";
         Text = "MainForm";
         FormClosing += MainForm_FormClosing;
         Load += MainForm_Load;
         menuStrip.ResumeLayout(false);
         menuStrip.PerformLayout();
         toolStrip.ResumeLayout(false);
         toolStrip.PerformLayout();
         statusStrip1.ResumeLayout(false);
         statusStrip1.PerformLayout();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion
      private MenuStrip menuStrip;
    private ToolStrip toolStrip;
    private ToolStripButton buttonVault;
    private ToolStripButton buttonLock;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton buttonChangePassword;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripButton buttonClose;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem preferencesToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.Timer Timer;
      private StatusStrip statusStrip1;
      private ToolStripStatusLabel LockLabel;
      private ToolStripStatusLabel countDownLabel;
      private Panel mainDockPanel;
   }
}