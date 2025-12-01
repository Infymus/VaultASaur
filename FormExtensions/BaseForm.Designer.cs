namespace VaultASaur3.Forms
{
    partial class BaseForm
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
         baseBackPanel = new Panel();
         baseDockPanel = new Panel();
         bottomDockPanel = new Panel();
         statBarLabel = new Label();
         workPanel = new Panel();
         baseSepPanel = new Panel();
         baseToolBar = new Panel();
         topNamePanel = new Panel();
         baseFormCaption = new Label();
         baseBackPanel.SuspendLayout();
         bottomDockPanel.SuspendLayout();
         topNamePanel.SuspendLayout();
         SuspendLayout();
         // 
         // baseBackPanel
         // 
         baseBackPanel.BackColor = Color.White;
         baseBackPanel.Controls.Add(baseDockPanel);
         baseBackPanel.Controls.Add(bottomDockPanel);
         baseBackPanel.Controls.Add(workPanel);
         baseBackPanel.Controls.Add(baseSepPanel);
         baseBackPanel.Controls.Add(baseToolBar);
         baseBackPanel.Controls.Add(topNamePanel);
         baseBackPanel.Dock = DockStyle.Fill;
         baseBackPanel.Font = new Font("Verdana", 8F);
         baseBackPanel.Location = new Point(0, 0);
         baseBackPanel.Margin = new Padding(1);
         baseBackPanel.Name = "baseBackPanel";
         baseBackPanel.Size = new Size(566, 443);
         baseBackPanel.TabIndex = 8;
         // 
         // baseDockPanel
         // 
         baseDockPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
         baseDockPanel.Dock = DockStyle.Fill;
         baseDockPanel.Location = new Point(0, 115);
         baseDockPanel.Name = "baseDockPanel";
         baseDockPanel.Size = new Size(566, 311);
         baseDockPanel.TabIndex = 15;
         // 
         // bottomDockPanel
         // 
         bottomDockPanel.BackColor = SystemColors.GradientInactiveCaption;
         bottomDockPanel.Controls.Add(statBarLabel);
         bottomDockPanel.Dock = DockStyle.Bottom;
         bottomDockPanel.Location = new Point(0, 426);
         bottomDockPanel.Name = "bottomDockPanel";
         bottomDockPanel.Size = new Size(566, 17);
         bottomDockPanel.TabIndex = 14;
         // 
         // statBarLabel
         // 
         statBarLabel.BackColor = Color.Transparent;
         statBarLabel.Dock = DockStyle.Left;
         statBarLabel.Font = new Font("Verdana", 9F, FontStyle.Bold);
         statBarLabel.ForeColor = Color.Black;
         statBarLabel.Location = new Point(0, 0);
         statBarLabel.Name = "statBarLabel";
         statBarLabel.Size = new Size(138, 17);
         statBarLabel.TabIndex = 0;
         statBarLabel.Text = "STAT BAR CAPTION";
         // 
         // workPanel
         // 
         workPanel.Dock = DockStyle.Top;
         workPanel.Location = new Point(0, 65);
         workPanel.Name = "workPanel";
         workPanel.Size = new Size(566, 50);
         workPanel.TabIndex = 12;
         // 
         // baseSepPanel
         // 
         baseSepPanel.BackColor = Color.Black;
         baseSepPanel.Dock = DockStyle.Top;
         baseSepPanel.Location = new Point(0, 64);
         baseSepPanel.Name = "baseSepPanel";
         baseSepPanel.Size = new Size(566, 1);
         baseSepPanel.TabIndex = 10;
         // 
         // baseToolBar
         // 
         baseToolBar.BackColor = Color.White;
         baseToolBar.Dock = DockStyle.Top;
         baseToolBar.Location = new Point(0, 16);
         baseToolBar.Name = "baseToolBar";
         baseToolBar.Size = new Size(566, 48);
         baseToolBar.TabIndex = 9;
         // 
         // topNamePanel
         // 
         topNamePanel.BackColor = Color.Maroon;
         topNamePanel.Controls.Add(baseFormCaption);
         topNamePanel.Dock = DockStyle.Top;
         topNamePanel.Location = new Point(0, 0);
         topNamePanel.Name = "topNamePanel";
         topNamePanel.Size = new Size(566, 16);
         topNamePanel.TabIndex = 8;
         // 
         // baseFormCaption
         // 
         baseFormCaption.Dock = DockStyle.Left;
         baseFormCaption.Font = new Font("Verdana", 9F, FontStyle.Bold);
         baseFormCaption.ForeColor = Color.White;
         baseFormCaption.Location = new Point(0, 0);
         baseFormCaption.Name = "baseFormCaption";
         baseFormCaption.Size = new Size(151, 16);
         baseFormCaption.TabIndex = 0;
         baseFormCaption.Text = "BASE FORM CAPTION";
         // 
         // BaseForm
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(566, 443);
         Controls.Add(baseBackPanel);
         Name = "BaseForm";
         Text = "BaseForm";
         baseBackPanel.ResumeLayout(false);
         bottomDockPanel.ResumeLayout(false);
         topNamePanel.ResumeLayout(false);
         ResumeLayout(false);
      }

      #endregion
      public Panel baseToolBar;
        public Panel topNamePanel;
        public Label baseFormCaption;
        public Panel workPanel;
        public Panel baseBackPanel;
        public Panel baseSepPanel;
        public Panel baseDockPanel;
        public Panel bottomDockPanel;
        public Label statBarLabel;
    }
}