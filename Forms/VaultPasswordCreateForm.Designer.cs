namespace VaultASaur3.Forms
{
   partial class VaultPasswordCreateForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VaultPasswordCreateForm));
         statusLabel = new Label();
         passGroupBox = new GroupBox();
         LabelPasswordMatch = new Label();
         db_PasswordHint = new TextBox();
         hintLabel = new Label();
         db_Password2 = new TextBox();
         retypeLabel = new Label();
         db_Password1 = new TextBox();
         passLabel = new Label();
         passVaultLabel = new Label();
         baseToolBar = new Panel();
         vaultImage = new PictureBox();
         passGroupBox.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)vaultImage).BeginInit();
         SuspendLayout();
         // 
         // statusLabel
         // 
         statusLabel.Font = new Font("Verdana", 8F);
         statusLabel.Location = new Point(10, 65);
         statusLabel.Name = "statusLabel";
         statusLabel.Size = new Size(437, 78);
         statusLabel.TabIndex = 9;
         // 
         // passGroupBox
         // 
         passGroupBox.Controls.Add(LabelPasswordMatch);
         passGroupBox.Controls.Add(db_PasswordHint);
         passGroupBox.Controls.Add(hintLabel);
         passGroupBox.Controls.Add(db_Password2);
         passGroupBox.Controls.Add(retypeLabel);
         passGroupBox.Controls.Add(db_Password1);
         passGroupBox.Controls.Add(passLabel);
         passGroupBox.Location = new Point(8, 151);
         passGroupBox.Name = "passGroupBox";
         passGroupBox.Size = new Size(444, 187);
         passGroupBox.TabIndex = 8;
         passGroupBox.TabStop = false;
         // 
         // LabelPasswordMatch
         // 
         LabelPasswordMatch.AutoSize = true;
         LabelPasswordMatch.Font = new Font("Verdana", 9F, FontStyle.Bold);
         LabelPasswordMatch.ForeColor = Color.Red;
         LabelPasswordMatch.Location = new Point(7, 147);
         LabelPasswordMatch.Name = "LabelPasswordMatch";
         LabelPasswordMatch.Size = new Size(147, 14);
         LabelPasswordMatch.TabIndex = 8;
         LabelPasswordMatch.Text = "LabelPasswordMatch";
         // 
         // db_PasswordHint
         // 
         db_PasswordHint.BackColor = Color.FromArgb(255, 128, 128);
         db_PasswordHint.Font = new Font("Verdana", 9F);
         db_PasswordHint.Location = new Point(6, 122);
         db_PasswordHint.Name = "db_PasswordHint";
         db_PasswordHint.Size = new Size(432, 22);
         db_PasswordHint.TabIndex = 3;
         // 
         // hintLabel
         // 
         hintLabel.AutoSize = true;
         hintLabel.Font = new Font("Verdana", 9F, FontStyle.Bold);
         hintLabel.Location = new Point(0, 105);
         hintLabel.Name = "hintLabel";
         hintLabel.Size = new Size(108, 14);
         hintLabel.TabIndex = 6;
         hintLabel.Text = "Password Hint:";
         // 
         // db_Password2
         // 
         db_Password2.BackColor = Color.FromArgb(255, 128, 128);
         db_Password2.Font = new Font("Verdana", 9F);
         db_Password2.Location = new Point(6, 79);
         db_Password2.Name = "db_Password2";
         db_Password2.PasswordChar = '*';
         db_Password2.Size = new Size(432, 22);
         db_Password2.TabIndex = 2;
         db_Password2.TextChanged += PasswordTextChanged;
         db_Password2.KeyDown += db_Password2_KeyDown;
         // 
         // retypeLabel
         // 
         retypeLabel.AutoSize = true;
         retypeLabel.Font = new Font("Verdana", 9F, FontStyle.Bold);
         retypeLabel.Location = new Point(0, 62);
         retypeLabel.Name = "retypeLabel";
         retypeLabel.Size = new Size(136, 14);
         retypeLabel.TabIndex = 4;
         retypeLabel.Text = "Re-Type Password:";
         // 
         // db_Password1
         // 
         db_Password1.BackColor = Color.FromArgb(255, 128, 128);
         db_Password1.Font = new Font("Verdana", 9F);
         db_Password1.Location = new Point(6, 36);
         db_Password1.Name = "db_Password1";
         db_Password1.PasswordChar = '*';
         db_Password1.Size = new Size(432, 22);
         db_Password1.TabIndex = 1;
         db_Password1.TextChanged += PasswordTextChanged;
         db_Password1.KeyDown += db_Password1_KeyDown;
         // 
         // passLabel
         // 
         passLabel.AutoSize = true;
         passLabel.Font = new Font("Verdana", 9F, FontStyle.Bold);
         passLabel.Location = new Point(0, 19);
         passLabel.Name = "passLabel";
         passLabel.Size = new Size(116, 14);
         passLabel.TabIndex = 0;
         passLabel.Text = "Enter Password:";
         // 
         // passVaultLabel
         // 
         passVaultLabel.AutoSize = true;
         passVaultLabel.Font = new Font("Verdana", 12F, FontStyle.Bold);
         passVaultLabel.ForeColor = Color.Navy;
         passVaultLabel.Location = new Point(59, 17);
         passVaultLabel.Name = "passVaultLabel";
         passVaultLabel.Size = new Size(225, 18);
         passVaultLabel.TabIndex = 7;
         passVaultLabel.Text = "Vault Password Creation";
         // 
         // baseToolBar
         // 
         baseToolBar.Dock = DockStyle.Bottom;
         baseToolBar.Location = new Point(0, 354);
         baseToolBar.Name = "baseToolBar";
         baseToolBar.Size = new Size(463, 48);
         baseToolBar.TabIndex = 4;
         // 
         // vaultImage
         // 
         vaultImage.Image = (Image)resources.GetObject("vaultImage.Image");
         vaultImage.Location = new Point(3, 2);
         vaultImage.Name = "vaultImage";
         vaultImage.Size = new Size(50, 50);
         vaultImage.SizeMode = PictureBoxSizeMode.AutoSize;
         vaultImage.TabIndex = 5;
         vaultImage.TabStop = false;
         // 
         // VaultPasswordCreateForm
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         BackColor = Color.White;
         ClientSize = new Size(463, 402);
         ControlBox = false;
         Controls.Add(statusLabel);
         Controls.Add(passGroupBox);
         Controls.Add(passVaultLabel);
         Controls.Add(baseToolBar);
         Controls.Add(vaultImage);
         Name = "VaultPasswordCreateForm";
         StartPosition = FormStartPosition.CenterScreen;
         Text = "VaultPasswordCreateForm";
         passGroupBox.ResumeLayout(false);
         passGroupBox.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)vaultImage).EndInit();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private Label statusLabel;
      private GroupBox passGroupBox;
      private Label LabelPasswordMatch;
      private TextBox db_PasswordHint;
      private Label hintLabel;
      private TextBox db_Password2;
      private Label retypeLabel;
      private TextBox db_Password1;
      private Label passLabel;
      private Label passVaultLabel;
      private Panel baseToolBar;
      private PictureBox vaultImage;
   }
}