namespace VaultASaur3.Forms
{
    partial class frm_VaultForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_VaultForm));
         userpassPanel = new Panel();
         pwButton = new Button();
         unButton = new Button();
         topNamePanel.SuspendLayout();
         baseBackPanel.SuspendLayout();
         baseDockPanel.SuspendLayout();
         bottomDockPanel.SuspendLayout();
         userpassPanel.SuspendLayout();
         SuspendLayout();
         // 
         // baseToolBar
         // 
         baseToolBar.Size = new Size(386, 48);
         // 
         // topNamePanel
         // 
         topNamePanel.Size = new Size(386, 16);
         // 
         // workPanel
         // 
         workPanel.Size = new Size(386, 25);
         // 
         // baseBackPanel
         // 
         baseBackPanel.Size = new Size(386, 502);
         // 
         // baseSepPanel
         // 
         baseSepPanel.Size = new Size(386, 1);
         // 
         // baseDockPanel
         // 
         baseDockPanel.Controls.Add(userpassPanel);
         baseDockPanel.Location = new Point(0, 90);
         baseDockPanel.Size = new Size(386, 393);
         // 
         // bottomDockPanel
         // 
         bottomDockPanel.Location = new Point(0, 483);
         bottomDockPanel.Size = new Size(386, 19);
         // 
         // statBarLabel
         // 
         statBarLabel.Size = new Size(138, 19);
         // 
         // userpassPanel
         // 
         userpassPanel.Controls.Add(pwButton);
         userpassPanel.Controls.Add(unButton);
         userpassPanel.Dock = DockStyle.Right;
         userpassPanel.Location = new Point(351, 0);
         userpassPanel.Name = "userpassPanel";
         userpassPanel.Size = new Size(35, 393);
         userpassPanel.TabIndex = 0;
         // 
         // pwButton
         // 
         pwButton.BackColor = Color.White;
         pwButton.Dock = DockStyle.Fill;
         pwButton.Font = new Font("Verdana", 8F, FontStyle.Bold);
         pwButton.Image = (Image)resources.GetObject("pwButton.Image");
         pwButton.Location = new Point(0, 144);
         pwButton.Name = "pwButton";
         pwButton.Size = new Size(35, 249);
         pwButton.TabIndex = 1;
         pwButton.Text = "PW";
         pwButton.TextAlign = ContentAlignment.BottomCenter;
         pwButton.TextImageRelation = TextImageRelation.ImageAboveText;
         pwButton.UseVisualStyleBackColor = false;
         // 
         // unButton
         // 
         unButton.BackColor = Color.White;
         unButton.Dock = DockStyle.Top;
         unButton.Font = new Font("Verdana", 8F, FontStyle.Bold);
         unButton.Image = (Image)resources.GetObject("unButton.Image");
         unButton.Location = new Point(0, 0);
         unButton.Name = "unButton";
         unButton.Size = new Size(35, 144);
         unButton.TabIndex = 0;
         unButton.Text = "UN";
         unButton.TextAlign = ContentAlignment.BottomCenter;
         unButton.TextImageRelation = TextImageRelation.ImageAboveText;
         unButton.UseVisualStyleBackColor = false;
         // 
         // frm_VaultForm
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(386, 502);
         Icon = (Icon)resources.GetObject("$this.Icon");
         Name = "frm_VaultForm";
         Text = "vaultForm";
         ResizeEnd += ResizeEvent;
         topNamePanel.ResumeLayout(false);
         baseBackPanel.ResumeLayout(false);
         baseDockPanel.ResumeLayout(false);
         bottomDockPanel.ResumeLayout(false);
         userpassPanel.ResumeLayout(false);
         ResumeLayout(false);
      }

      #endregion

      private Panel userpassPanel;
      private Button pwButton;
      private Button unButton;
   }
}