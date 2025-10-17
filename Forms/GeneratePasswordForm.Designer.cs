namespace VaultASaur3.Forms
{
   partial class GeneratePasswordForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneratePasswordForm));
         statusLabel = new Label();
         passGroupBox = new GroupBox();
         GenLengthLabel = new Label();
         lengthLabel = new Label();
         TrackBar = new TrackBar();
         punctCheckBox = new CheckBox();
         ShowPasswordCheck = new CheckBox();
         db_Password1 = new TextBox();
         passLabel = new Label();
         passVaultLabel = new Label();
         baseToolBar = new Panel();
         vaultImage = new PictureBox();
         label1 = new Label();
         passGroupBox.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)TrackBar).BeginInit();
         ((System.ComponentModel.ISupportInitialize)vaultImage).BeginInit();
         SuspendLayout();
         // 
         // statusLabel
         // 
         statusLabel.Font = new Font("Verdana", 8F);
         statusLabel.Location = new Point(42, 86);
         statusLabel.Name = "statusLabel";
         statusLabel.Size = new Size(417, 94);
         statusLabel.TabIndex = 14;
         // 
         // passGroupBox
         // 
         passGroupBox.Controls.Add(GenLengthLabel);
         passGroupBox.Controls.Add(lengthLabel);
         passGroupBox.Controls.Add(TrackBar);
         passGroupBox.Controls.Add(punctCheckBox);
         passGroupBox.Controls.Add(ShowPasswordCheck);
         passGroupBox.Controls.Add(db_Password1);
         passGroupBox.Controls.Add(passLabel);
         passGroupBox.Location = new Point(12, 183);
         passGroupBox.Name = "passGroupBox";
         passGroupBox.Size = new Size(447, 178);
         passGroupBox.TabIndex = 13;
         passGroupBox.TabStop = false;
         // 
         // GenLengthLabel
         // 
         GenLengthLabel.AutoSize = true;
         GenLengthLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
         GenLengthLabel.Location = new Point(416, 143);
         GenLengthLabel.Name = "GenLengthLabel";
         GenLengthLabel.Size = new Size(21, 15);
         GenLengthLabel.TabIndex = 15;
         GenLengthLabel.Text = "15";
         // 
         // lengthLabel
         // 
         lengthLabel.AutoSize = true;
         lengthLabel.Font = new Font("Verdana", 12F, FontStyle.Bold);
         lengthLabel.Location = new Point(12, 136);
         lengthLabel.Name = "lengthLabel";
         lengthLabel.Size = new Size(75, 18);
         lengthLabel.TabIndex = 14;
         lengthLabel.Text = "Length:";
         // 
         // TrackBar
         // 
         TrackBar.Location = new Point(93, 125);
         TrackBar.Maximum = 30;
         TrackBar.Name = "TrackBar";
         TrackBar.Size = new Size(317, 45);
         TrackBar.TabIndex = 13;
         TrackBar.TickStyle = TickStyle.Both;
         TrackBar.Value = 15;
         TrackBar.Scroll += TrackBar_Scroll;
         // 
         // punctCheckBox
         // 
         punctCheckBox.AutoSize = true;
         punctCheckBox.Location = new Point(148, 100);
         punctCheckBox.Margin = new Padding(4, 3, 4, 3);
         punctCheckBox.Name = "punctCheckBox";
         punctCheckBox.Size = new Size(228, 19);
         punctCheckBox.TabIndex = 12;
         punctCheckBox.Text = "Include Punctuation (!, \", $, and so on)";
         punctCheckBox.UseVisualStyleBackColor = true;
         // 
         // ShowPasswordCheck
         // 
         ShowPasswordCheck.AutoSize = true;
         ShowPasswordCheck.Location = new Point(7, 64);
         ShowPasswordCheck.Margin = new Padding(4, 3, 4, 3);
         ShowPasswordCheck.Name = "ShowPasswordCheck";
         ShowPasswordCheck.Size = new Size(113, 19);
         ShowPasswordCheck.TabIndex = 11;
         ShowPasswordCheck.Text = "Show Passwords";
         ShowPasswordCheck.UseVisualStyleBackColor = true;
         ShowPasswordCheck.CheckedChanged += ShowPasswordCheck_CheckedChanged;
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
         passVaultLabel.Location = new Point(59, 16);
         passVaultLabel.Name = "passVaultLabel";
         passVaultLabel.Size = new Size(225, 18);
         passVaultLabel.TabIndex = 12;
         passVaultLabel.Text = "Vault Password Creation";
         // 
         // baseToolBar
         // 
         baseToolBar.Dock = DockStyle.Bottom;
         baseToolBar.Location = new Point(0, 372);
         baseToolBar.Name = "baseToolBar";
         baseToolBar.Size = new Size(470, 48);
         baseToolBar.TabIndex = 10;
         // 
         // vaultImage
         // 
         vaultImage.Image = (Image)resources.GetObject("vaultImage.Image");
         vaultImage.Location = new Point(3, 1);
         vaultImage.Name = "vaultImage";
         vaultImage.Size = new Size(50, 50);
         vaultImage.SizeMode = PictureBoxSizeMode.AutoSize;
         vaultImage.TabIndex = 11;
         vaultImage.TabStop = false;
         // 
         // label1
         // 
         label1.AutoSize = true;
         label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
         label1.Location = new Point(19, 66);
         label1.Name = "label1";
         label1.Size = new Size(114, 15);
         label1.TabIndex = 15;
         label1.Text = "A Strong Password:";
         // 
         // GeneratePasswordForm
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         BackColor = Color.White;
         ClientSize = new Size(470, 420);
         ControlBox = false;
         Controls.Add(label1);
         Controls.Add(statusLabel);
         Controls.Add(passGroupBox);
         Controls.Add(passVaultLabel);
         Controls.Add(baseToolBar);
         Controls.Add(vaultImage);
         FormBorderStyle = FormBorderStyle.FixedSingle;
         Name = "GeneratePasswordForm";
         StartPosition = FormStartPosition.CenterScreen;
         Text = "GeneratePasswordForm";
         passGroupBox.ResumeLayout(false);
         passGroupBox.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)TrackBar).EndInit();
         ((System.ComponentModel.ISupportInitialize)vaultImage).EndInit();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private Label statusLabel;
      private GroupBox passGroupBox;
      private TextBox db_Password1;
      private Label passLabel;
      private Label passVaultLabel;
      private Panel baseToolBar;
      private PictureBox vaultImage;
      private CheckBox punctCheckBox;
      private CheckBox ShowPasswordCheck;
      private Label lengthLabel;
      private TrackBar TrackBar;
      private Label label1;
      private Label GenLengthLabel;
   }
}