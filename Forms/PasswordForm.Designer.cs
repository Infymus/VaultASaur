namespace VaultASaur3.Forms
{
   partial class PasswordForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordForm));
         vaultPictureBox = new PictureBox();
         baseToolBar = new Panel();
         vaultTopLabel = new Label();
         passGroupBox = new GroupBox();
         hintDisplayLabel = new Label();
         hintLabel = new Label();
         pwTextBox = new TextBox();
         passLabel = new Label();
         vaultCredsLabel = new Label();
         ((System.ComponentModel.ISupportInitialize)vaultPictureBox).BeginInit();
         passGroupBox.SuspendLayout();
         SuspendLayout();
         // 
         // vaultPictureBox
         // 
         vaultPictureBox.Image = (Image)resources.GetObject("vaultPictureBox.Image");
         vaultPictureBox.Location = new Point(3, 4);
         vaultPictureBox.Name = "vaultPictureBox";
         vaultPictureBox.Size = new Size(50, 50);
         vaultPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
         vaultPictureBox.TabIndex = 0;
         vaultPictureBox.TabStop = false;
         // 
         // baseToolBar
         // 
         baseToolBar.Dock = DockStyle.Bottom;
         baseToolBar.Location = new Point(0, 231);
         baseToolBar.Name = "baseToolBar";
         baseToolBar.Size = new Size(318, 48);
         baseToolBar.TabIndex = 1;
         // 
         // vaultTopLabel
         // 
         vaultTopLabel.AutoSize = true;
         vaultTopLabel.Font = new Font("Verdana", 12F, FontStyle.Bold);
         vaultTopLabel.ForeColor = Color.Navy;
         vaultTopLabel.Location = new Point(59, 19);
         vaultTopLabel.Name = "vaultTopLabel";
         vaultTopLabel.Size = new Size(248, 18);
         vaultTopLabel.TabIndex = 2;
         vaultTopLabel.Text = "VaultASaur Vault Password";
         // 
         // passGroupBox
         // 
         passGroupBox.Controls.Add(hintDisplayLabel);
         passGroupBox.Controls.Add(hintLabel);
         passGroupBox.Controls.Add(pwTextBox);
         passGroupBox.Controls.Add(passLabel);
         passGroupBox.Location = new Point(3, 101);
         passGroupBox.Name = "passGroupBox";
         passGroupBox.Size = new Size(312, 125);
         passGroupBox.TabIndex = 3;
         passGroupBox.TabStop = false;
         // 
         // hintDisplayLabel
         // 
         hintDisplayLabel.Font = new Font("Verdana", 8F);
         hintDisplayLabel.Location = new Point(8, 83);
         hintDisplayLabel.Name = "hintDisplayLabel";
         hintDisplayLabel.Size = new Size(273, 35);
         hintDisplayLabel.TabIndex = 3;
         hintDisplayLabel.Text = "No hint available.";
         // 
         // hintLabel
         // 
         hintLabel.AutoSize = true;
         hintLabel.Font = new Font("Verdana", 8F, FontStyle.Bold);
         hintLabel.Location = new Point(8, 63);
         hintLabel.Name = "hintLabel";
         hintLabel.Size = new Size(37, 13);
         hintLabel.TabIndex = 2;
         hintLabel.Text = "Hint:";
         // 
         // pwTextBox
         // 
         pwTextBox.BackColor = Color.Red;
         pwTextBox.BorderStyle = BorderStyle.FixedSingle;
         pwTextBox.Font = new Font("Verdana", 9F, FontStyle.Bold);
         pwTextBox.ForeColor = Color.White;
         pwTextBox.Location = new Point(11, 36);
         pwTextBox.Name = "pwTextBox";
         pwTextBox.PasswordChar = '#';
         pwTextBox.Size = new Size(279, 22);
         pwTextBox.TabIndex = 1;
         pwTextBox.KeyPress += pwTextBox_KeyPress;
         // 
         // passLabel
         // 
         passLabel.AutoSize = true;
         passLabel.Font = new Font("Verdana", 9F, FontStyle.Bold);
         passLabel.Location = new Point(8, 19);
         passLabel.Name = "passLabel";
         passLabel.Size = new Size(154, 14);
         passLabel.TabIndex = 0;
         passLabel.Text = "Enter Vault Password:";
         // 
         // vaultCredsLabel
         // 
         vaultCredsLabel.Font = new Font("Verdana", 8F, FontStyle.Bold);
         vaultCredsLabel.Location = new Point(3, 67);
         vaultCredsLabel.Name = "vaultCredsLabel";
         vaultCredsLabel.Size = new Size(311, 31);
         vaultCredsLabel.TabIndex = 4;
         vaultCredsLabel.Text = "Please enter your Vault Password in order to access your Vault Sites.";
         // 
         // PasswordForm
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         BackColor = Color.White;
         ClientSize = new Size(318, 279);
         ControlBox = false;
         Controls.Add(vaultCredsLabel);
         Controls.Add(passGroupBox);
         Controls.Add(vaultTopLabel);
         Controls.Add(baseToolBar);
         Controls.Add(vaultPictureBox);
         FormBorderStyle = FormBorderStyle.FixedDialog;
         Name = "PasswordForm";
         StartPosition = FormStartPosition.CenterScreen;
         ((System.ComponentModel.ISupportInitialize)vaultPictureBox).EndInit();
         passGroupBox.ResumeLayout(false);
         passGroupBox.PerformLayout();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private PictureBox vaultPictureBox;
      private Panel baseToolBar;
      private Label vaultTopLabel;
      private GroupBox passGroupBox;
      private Label hintDisplayLabel;
      private Label hintLabel;
      private TextBox pwTextBox;
      private Label passLabel;
      private Label vaultCredsLabel;
   }
}