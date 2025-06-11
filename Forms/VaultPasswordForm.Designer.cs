namespace VaultASaur.Forms
{
    partial class VaultPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VaultPasswordForm));
            VaultImage = new PictureBox();
            VaultPWLabel = new Label();
            EnterPwLabel = new Label();
            PasswordGroupBox = new GroupBox();
            PasswordDialog = new TextBox();
            HintLabel = new Label();
            HintHeaderLabel = new Label();
            label3 = new Label();
            OkButton = new Button();
            CancelButton = new Button();
            ((System.ComponentModel.ISupportInitialize)VaultImage).BeginInit();
            PasswordGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // VaultImage
            // 
            VaultImage.Image = (Image)resources.GetObject("VaultImage.Image");
            VaultImage.Location = new Point(12, 12);
            VaultImage.Name = "VaultImage";
            VaultImage.Size = new Size(50, 50);
            VaultImage.TabIndex = 0;
            VaultImage.TabStop = false;
            // 
            // VaultPWLabel
            // 
            VaultPWLabel.AutoSize = true;
            VaultPWLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            VaultPWLabel.ForeColor = Color.DarkBlue;
            VaultPWLabel.Location = new Point(71, 21);
            VaultPWLabel.Name = "VaultPWLabel";
            VaultPWLabel.Size = new Size(155, 28);
            VaultPWLabel.TabIndex = 1;
            VaultPWLabel.Text = "Vault Password";
            // 
            // EnterPwLabel
            // 
            EnterPwLabel.AutoSize = true;
            EnterPwLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            EnterPwLabel.Location = new Point(12, 73);
            EnterPwLabel.Name = "EnterPwLabel";
            EnterPwLabel.Size = new Size(382, 15);
            EnterPwLabel.TabIndex = 2;
            EnterPwLabel.Text = "Please enter your Vault Password in order to access your Vault Sites:";
            // 
            // PasswordGroupBox
            // 
            PasswordGroupBox.Controls.Add(PasswordDialog);
            PasswordGroupBox.Controls.Add(HintLabel);
            PasswordGroupBox.Controls.Add(HintHeaderLabel);
            PasswordGroupBox.Controls.Add(label3);
            PasswordGroupBox.Location = new Point(14, 95);
            PasswordGroupBox.Name = "PasswordGroupBox";
            PasswordGroupBox.Size = new Size(390, 145);
            PasswordGroupBox.TabIndex = 3;
            PasswordGroupBox.TabStop = false;
            // 
            // PasswordDialog
            // 
            PasswordDialog.BackColor = Color.FromArgb(255, 128, 128);
            PasswordDialog.ForeColor = Color.White;
            PasswordDialog.Location = new Point(16, 41);
            PasswordDialog.Name = "PasswordDialog";
            PasswordDialog.PasswordChar = '*';
            PasswordDialog.Size = new Size(361, 23);
            PasswordDialog.TabIndex = 3;
            // 
            // HintLabel
            // 
            HintLabel.AutoSize = true;
            HintLabel.Location = new Point(15, 96);
            HintLabel.Name = "HintLabel";
            HintLabel.Size = new Size(99, 15);
            HintLabel.TabIndex = 2;
            HintLabel.Text = "No hint available.";
            // 
            // HintHeaderLabel
            // 
            HintHeaderLabel.AutoSize = true;
            HintHeaderLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            HintHeaderLabel.Location = new Point(13, 76);
            HintHeaderLabel.Name = "HintHeaderLabel";
            HintHeaderLabel.Size = new Size(34, 15);
            HintHeaderLabel.TabIndex = 1;
            HintHeaderLabel.Text = "Hint:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(10, 19);
            label3.Name = "label3";
            label3.Size = new Size(77, 19);
            label3.TabIndex = 0;
            label3.Text = "Password:";
            // 
            // OkButton
            // 
            OkButton.FlatStyle = FlatStyle.Flat;
            OkButton.Image = (Image)resources.GetObject("OkButton.Image");
            OkButton.ImageAlign = ContentAlignment.TopCenter;
            OkButton.Location = new Point(283, 249);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(55, 55);
            OkButton.TabIndex = 4;
            OkButton.Text = "OK";
            OkButton.TextAlign = ContentAlignment.BottomCenter;
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += button1_Click;
            // 
            // CancelButton
            // 
            CancelButton.FlatStyle = FlatStyle.Flat;
            CancelButton.Image = (Image)resources.GetObject("CancelButton.Image");
            CancelButton.ImageAlign = ContentAlignment.TopCenter;
            CancelButton.Location = new Point(344, 249);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(55, 55);
            CancelButton.TabIndex = 5;
            CancelButton.Text = "Cancel";
            CancelButton.TextAlign = ContentAlignment.BottomCenter;
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += button2_Click;
            // 
            // VaultPasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(418, 318);
            Controls.Add(CancelButton);
            Controls.Add(OkButton);
            Controls.Add(PasswordGroupBox);
            Controls.Add(EnterPwLabel);
            Controls.Add(VaultPWLabel);
            Controls.Add(VaultImage);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "VaultPasswordForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "VaultPasswordForm";
            ((System.ComponentModel.ISupportInitialize)VaultImage).EndInit();
            PasswordGroupBox.ResumeLayout(false);
            PasswordGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox VaultImage;
        private Label VaultPWLabel;
        private Label EnterPwLabel;
        private GroupBox PasswordGroupBox;
        private TextBox PasswordDialog;
        private Label HintLabel;
        private Label HintHeaderLabel;
        private Label label3;
        private Button OkButton;
        private Button CancelButton;
    }
}