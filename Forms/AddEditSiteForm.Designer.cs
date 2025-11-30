namespace VaultASaur3.Forms
{
   partial class AddEditSiteForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditSiteForm));
         baseToolBar = new Panel();
         db_SiteName = new TextBox();
         passLabel = new Label();
         db_Username = new TextBox();
         label1 = new Label();
         passGroupBox = new GroupBox();
         generatePasswordBtn = new Button();
         ShowPasswordCheck = new CheckBox();
         LabelPasswordMatch = new Label();
         db_Password2 = new TextBox();
         label3 = new Label();
         db_Password1 = new TextBox();
         label2 = new Label();
         db_Desc = new TextBox();
         label5 = new Label();
         db_active = new CheckBox();
         db_Email = new TextBox();
         label6 = new Label();
         db_URL = new TextBox();
         label7 = new Label();
         db_Question1 = new TextBox();
         label8 = new Label();
         db_Question2 = new TextBox();
         label9 = new Label();
         db_Question3 = new TextBox();
         label10 = new Label();
         db_PasswordHint = new TextBox();
         label11 = new Label();
         passGroupBox.SuspendLayout();
         SuspendLayout();
         // 
         // baseToolBar
         // 
         baseToolBar.Dock = DockStyle.Bottom;
         baseToolBar.Location = new Point(0, 462);
         baseToolBar.Margin = new Padding(4, 3, 4, 3);
         baseToolBar.Name = "baseToolBar";
         baseToolBar.Size = new Size(586, 48);
         baseToolBar.TabIndex = 2;
         // 
         // db_SiteName
         // 
         db_SiteName.BackColor = Color.Red;
         db_SiteName.BorderStyle = BorderStyle.FixedSingle;
         db_SiteName.Font = new Font("Verdana", 9F, FontStyle.Bold);
         db_SiteName.ForeColor = Color.White;
         db_SiteName.Location = new Point(10, 23);
         db_SiteName.Margin = new Padding(4, 3, 4, 3);
         db_SiteName.Name = "db_SiteName";
         db_SiteName.Size = new Size(567, 22);
         db_SiteName.TabIndex = 4;
         db_SiteName.TextChanged += PasswordTextChanged;
         // 
         // passLabel
         // 
         passLabel.AutoSize = true;
         passLabel.Font = new Font("Verdana", 9F, FontStyle.Bold);
         passLabel.Location = new Point(8, 4);
         passLabel.Margin = new Padding(4, 0, 4, 0);
         passLabel.Name = "passLabel";
         passLabel.Size = new Size(80, 14);
         passLabel.TabIndex = 3;
         passLabel.Text = "Site Name:";
         // 
         // db_Username
         // 
         db_Username.BackColor = Color.Red;
         db_Username.BorderStyle = BorderStyle.FixedSingle;
         db_Username.Font = new Font("Verdana", 9F, FontStyle.Bold);
         db_Username.ForeColor = Color.White;
         db_Username.Location = new Point(10, 70);
         db_Username.Margin = new Padding(4, 3, 4, 3);
         db_Username.Name = "db_Username";
         db_Username.Size = new Size(278, 22);
         db_Username.TabIndex = 6;
         db_Username.TextChanged += PasswordTextChanged;
         // 
         // label1
         // 
         label1.AutoSize = true;
         label1.Font = new Font("Verdana", 9F, FontStyle.Bold);
         label1.Location = new Point(8, 51);
         label1.Margin = new Padding(4, 0, 4, 0);
         label1.Name = "label1";
         label1.Size = new Size(85, 14);
         label1.TabIndex = 5;
         label1.Text = "User Name:";
         // 
         // passGroupBox
         // 
         passGroupBox.Controls.Add(generatePasswordBtn);
         passGroupBox.Controls.Add(ShowPasswordCheck);
         passGroupBox.Controls.Add(LabelPasswordMatch);
         passGroupBox.Controls.Add(db_Password2);
         passGroupBox.Controls.Add(label3);
         passGroupBox.Controls.Add(db_Password1);
         passGroupBox.Controls.Add(label2);
         passGroupBox.Location = new Point(8, 98);
         passGroupBox.Margin = new Padding(4, 3, 4, 3);
         passGroupBox.Name = "passGroupBox";
         passGroupBox.Padding = new Padding(4, 3, 4, 3);
         passGroupBox.Size = new Size(569, 136);
         passGroupBox.TabIndex = 7;
         passGroupBox.TabStop = false;
         // 
         // generatePasswordBtn
         // 
         generatePasswordBtn.FlatStyle = FlatStyle.Flat;
         generatePasswordBtn.Font = new Font("Tahoma", 8F, FontStyle.Bold);
         generatePasswordBtn.Image = (Image)resources.GetObject("generatePasswordBtn.Image");
         generatePasswordBtn.ImageAlign = ContentAlignment.TopCenter;
         generatePasswordBtn.Location = new Point(297, 31);
         generatePasswordBtn.Margin = new Padding(4, 3, 4, 3);
         generatePasswordBtn.Name = "generatePasswordBtn";
         generatePasswordBtn.Size = new Size(71, 74);
         generatePasswordBtn.TabIndex = 11;
         generatePasswordBtn.Text = "Generate";
         generatePasswordBtn.TextAlign = ContentAlignment.BottomCenter;
         generatePasswordBtn.UseVisualStyleBackColor = true;
         generatePasswordBtn.Click += generatePasswordBtn_Click;
         // 
         // ShowPasswordCheck
         // 
         ShowPasswordCheck.AutoSize = true;
         ShowPasswordCheck.Location = new Point(383, 59);
         ShowPasswordCheck.Margin = new Padding(4, 3, 4, 3);
         ShowPasswordCheck.Name = "ShowPasswordCheck";
         ShowPasswordCheck.Size = new Size(113, 19);
         ShowPasswordCheck.TabIndex = 10;
         ShowPasswordCheck.Text = "Show Passwords";
         ShowPasswordCheck.UseVisualStyleBackColor = true;
         ShowPasswordCheck.CheckedChanged += ShowPasswordChanged;
         // 
         // LabelPasswordMatch
         // 
         LabelPasswordMatch.AutoSize = true;
         LabelPasswordMatch.Font = new Font("Verdana", 9F, FontStyle.Bold);
         LabelPasswordMatch.ForeColor = Color.Red;
         LabelPasswordMatch.Location = new Point(13, 109);
         LabelPasswordMatch.Margin = new Padding(4, 0, 4, 0);
         LabelPasswordMatch.Name = "LabelPasswordMatch";
         LabelPasswordMatch.Size = new Size(147, 14);
         LabelPasswordMatch.TabIndex = 9;
         LabelPasswordMatch.Text = "LabelPasswordMatch";
         // 
         // db_Password2
         // 
         db_Password2.BackColor = Color.Red;
         db_Password2.BorderStyle = BorderStyle.FixedSingle;
         db_Password2.Font = new Font("Tahoma", 9F, FontStyle.Bold);
         db_Password2.ForeColor = Color.White;
         db_Password2.Location = new Point(10, 78);
         db_Password2.Margin = new Padding(4, 3, 4, 3);
         db_Password2.Name = "db_Password2";
         db_Password2.PasswordChar = '#';
         db_Password2.Size = new Size(278, 22);
         db_Password2.TabIndex = 3;
         db_Password2.TextChanged += PasswordTextChanged;
         db_Password2.KeyDown += db_Password2_KeyDown;
         // 
         // label3
         // 
         label3.AutoSize = true;
         label3.Font = new Font("Verdana", 9F, FontStyle.Bold);
         label3.Location = new Point(8, 59);
         label3.Margin = new Padding(4, 0, 4, 0);
         label3.Name = "label3";
         label3.Size = new Size(136, 14);
         label3.TabIndex = 2;
         label3.Text = "Re-Type Password:";
         // 
         // db_Password1
         // 
         db_Password1.BackColor = Color.Red;
         db_Password1.BorderStyle = BorderStyle.FixedSingle;
         db_Password1.Font = new Font("Tahoma", 9F, FontStyle.Bold);
         db_Password1.ForeColor = Color.White;
         db_Password1.Location = new Point(10, 34);
         db_Password1.Margin = new Padding(4, 3, 4, 3);
         db_Password1.Name = "db_Password1";
         db_Password1.PasswordChar = '#';
         db_Password1.Size = new Size(276, 22);
         db_Password1.TabIndex = 1;
         db_Password1.TextChanged += PasswordTextChanged;
         db_Password1.KeyDown += db_Password1_KeyDown;
         // 
         // label2
         // 
         label2.AutoSize = true;
         label2.Font = new Font("Verdana", 9F, FontStyle.Bold);
         label2.Location = new Point(8, 15);
         label2.Margin = new Padding(4, 0, 4, 0);
         label2.Name = "label2";
         label2.Size = new Size(154, 14);
         label2.TabIndex = 0;
         label2.Text = "Enter Vault Password:";
         // 
         // db_Desc
         // 
         db_Desc.BackColor = Color.White;
         db_Desc.BorderStyle = BorderStyle.FixedSingle;
         db_Desc.Font = new Font("Verdana", 9F, FontStyle.Bold);
         db_Desc.ForeColor = Color.Black;
         db_Desc.Location = new Point(13, 266);
         db_Desc.Margin = new Padding(4, 3, 4, 3);
         db_Desc.Name = "db_Desc";
         db_Desc.Size = new Size(278, 22);
         db_Desc.TabIndex = 12;
         // 
         // label5
         // 
         label5.AutoSize = true;
         label5.Font = new Font("Verdana", 9F, FontStyle.Bold);
         label5.Location = new Point(10, 249);
         label5.Margin = new Padding(4, 0, 4, 0);
         label5.Name = "label5";
         label5.Size = new Size(117, 14);
         label5.TabIndex = 11;
         label5.Text = "Site Description:";
         // 
         // db_active
         // 
         db_active.AutoSize = true;
         db_active.Location = new Point(497, 51);
         db_active.Margin = new Padding(4, 3, 4, 3);
         db_active.Name = "db_active";
         db_active.Size = new Size(81, 19);
         db_active.TabIndex = 13;
         db_active.Text = "Site Active";
         db_active.UseVisualStyleBackColor = true;
         // 
         // db_Email
         // 
         db_Email.BackColor = Color.White;
         db_Email.BorderStyle = BorderStyle.FixedSingle;
         db_Email.Font = new Font("Verdana", 9F, FontStyle.Bold);
         db_Email.ForeColor = Color.Black;
         db_Email.Location = new Point(13, 308);
         db_Email.Margin = new Padding(4, 3, 4, 3);
         db_Email.Name = "db_Email";
         db_Email.Size = new Size(278, 22);
         db_Email.TabIndex = 15;
         // 
         // label6
         // 
         label6.AutoSize = true;
         label6.Font = new Font("Verdana", 9F, FontStyle.Bold);
         label6.Location = new Point(13, 291);
         label6.Margin = new Padding(4, 0, 4, 0);
         label6.Name = "label6";
         label6.Size = new Size(164, 14);
         label6.TabIndex = 14;
         label6.Text = "Email Used To Register:";
         // 
         // db_URL
         // 
         db_URL.BackColor = Color.White;
         db_URL.BorderStyle = BorderStyle.FixedSingle;
         db_URL.Font = new Font("Verdana", 9F, FontStyle.Bold);
         db_URL.ForeColor = Color.Black;
         db_URL.Location = new Point(13, 350);
         db_URL.Margin = new Padding(4, 3, 4, 3);
         db_URL.Name = "db_URL";
         db_URL.Size = new Size(278, 22);
         db_URL.TabIndex = 17;
         // 
         // label7
         // 
         label7.AutoSize = true;
         label7.Font = new Font("Verdana", 9F, FontStyle.Bold);
         label7.Location = new Point(13, 333);
         label7.Margin = new Padding(4, 0, 4, 0);
         label7.Name = "label7";
         label7.Size = new Size(69, 14);
         label7.TabIndex = 16;
         label7.Text = "Site URL:";
         // 
         // db_Question1
         // 
         db_Question1.BackColor = Color.White;
         db_Question1.BorderStyle = BorderStyle.FixedSingle;
         db_Question1.Font = new Font("Verdana", 9F, FontStyle.Bold);
         db_Question1.ForeColor = Color.Black;
         db_Question1.Location = new Point(13, 392);
         db_Question1.Margin = new Padding(4, 3, 4, 3);
         db_Question1.Name = "db_Question1";
         db_Question1.PasswordChar = '#';
         db_Question1.Size = new Size(180, 22);
         db_Question1.TabIndex = 19;
         // 
         // label8
         // 
         label8.AutoSize = true;
         label8.Font = new Font("Verdana", 9F, FontStyle.Bold);
         label8.Location = new Point(13, 375);
         label8.Margin = new Padding(4, 0, 4, 0);
         label8.Name = "label8";
         label8.Size = new Size(143, 14);
         label8.TabIndex = 18;
         label8.Text = "Security Question 1:";
         // 
         // db_Question2
         // 
         db_Question2.BackColor = Color.White;
         db_Question2.BorderStyle = BorderStyle.FixedSingle;
         db_Question2.Font = new Font("Verdana", 9F, FontStyle.Bold);
         db_Question2.ForeColor = Color.Black;
         db_Question2.Location = new Point(203, 392);
         db_Question2.Margin = new Padding(4, 3, 4, 3);
         db_Question2.Name = "db_Question2";
         db_Question2.PasswordChar = '#';
         db_Question2.Size = new Size(180, 22);
         db_Question2.TabIndex = 21;
         // 
         // label9
         // 
         label9.AutoSize = true;
         label9.Font = new Font("Verdana", 9F, FontStyle.Bold);
         label9.Location = new Point(203, 375);
         label9.Margin = new Padding(4, 0, 4, 0);
         label9.Name = "label9";
         label9.Size = new Size(143, 14);
         label9.TabIndex = 20;
         label9.Text = "Security Question 2:";
         // 
         // db_Question3
         // 
         db_Question3.BackColor = Color.White;
         db_Question3.BorderStyle = BorderStyle.FixedSingle;
         db_Question3.Font = new Font("Verdana", 9F, FontStyle.Bold);
         db_Question3.ForeColor = Color.Black;
         db_Question3.Location = new Point(391, 392);
         db_Question3.Margin = new Padding(4, 3, 4, 3);
         db_Question3.Name = "db_Question3";
         db_Question3.PasswordChar = '#';
         db_Question3.Size = new Size(180, 22);
         db_Question3.TabIndex = 23;
         // 
         // label10
         // 
         label10.AutoSize = true;
         label10.Font = new Font("Verdana", 9F, FontStyle.Bold);
         label10.Location = new Point(391, 375);
         label10.Margin = new Padding(4, 0, 4, 0);
         label10.Name = "label10";
         label10.Size = new Size(143, 14);
         label10.TabIndex = 22;
         label10.Text = "Security Question 3:";
         // 
         // db_PasswordHint
         // 
         db_PasswordHint.BackColor = Color.White;
         db_PasswordHint.BorderStyle = BorderStyle.FixedSingle;
         db_PasswordHint.Font = new Font("Verdana", 9F, FontStyle.Bold);
         db_PasswordHint.ForeColor = Color.Black;
         db_PasswordHint.Location = new Point(13, 434);
         db_PasswordHint.Margin = new Padding(4, 3, 4, 3);
         db_PasswordHint.Name = "db_PasswordHint";
         db_PasswordHint.Size = new Size(278, 22);
         db_PasswordHint.TabIndex = 25;
         // 
         // label11
         // 
         label11.AutoSize = true;
         label11.Font = new Font("Verdana", 9F, FontStyle.Bold);
         label11.Location = new Point(13, 417);
         label11.Margin = new Padding(4, 0, 4, 0);
         label11.Name = "label11";
         label11.Size = new Size(108, 14);
         label11.TabIndex = 24;
         label11.Text = "Password Hint:";
         // 
         // AddEditSiteForm
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         BackColor = Color.White;
         ClientSize = new Size(586, 510);
         ControlBox = false;
         Controls.Add(db_PasswordHint);
         Controls.Add(label11);
         Controls.Add(db_Question3);
         Controls.Add(label10);
         Controls.Add(db_Question2);
         Controls.Add(label9);
         Controls.Add(db_Question1);
         Controls.Add(label8);
         Controls.Add(db_URL);
         Controls.Add(label7);
         Controls.Add(db_Email);
         Controls.Add(label6);
         Controls.Add(db_active);
         Controls.Add(db_Desc);
         Controls.Add(label5);
         Controls.Add(passGroupBox);
         Controls.Add(db_Username);
         Controls.Add(label1);
         Controls.Add(db_SiteName);
         Controls.Add(passLabel);
         Controls.Add(baseToolBar);
         FormBorderStyle = FormBorderStyle.FixedSingle;
         Margin = new Padding(4, 3, 4, 3);
         Name = "AddEditSiteForm";
         StartPosition = FormStartPosition.CenterScreen;
         Text = "AddSiteForm";
         passGroupBox.ResumeLayout(false);
         passGroupBox.PerformLayout();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private Panel baseToolBar;
      private TextBox db_SiteName;
      private Label passLabel;
      private TextBox db_Username;
      private Label label1;
      private GroupBox passGroupBox;
      private TextBox db_Password2;
      private Label label3;
      private TextBox db_Password1;
      private Label label2;
      private Button generatePasswordBtn;
      private CheckBox ShowPasswordCheck;
      private Label LabelPasswordMatch;
      private TextBox db_Desc;
      private Label label5;
      private CheckBox db_active;
      private TextBox db_Email;
      private Label label6;
      private TextBox db_URL;
      private Label label7;
      private TextBox db_Question1;
      private Label label8;
      private TextBox db_Question2;
      private Label label9;
      private TextBox db_Question3;
      private Label label10;
      private TextBox db_PasswordHint;
      private Label label11;
   }
}