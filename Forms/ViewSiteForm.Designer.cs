namespace VaultASaur3.Forms
{
   partial class ViewSiteForm
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
         db_PasswordHint = new TextBox();
         label11 = new Label();
         db_Question3 = new TextBox();
         label10 = new Label();
         db_Question2 = new TextBox();
         label9 = new Label();
         db_Question1 = new TextBox();
         label8 = new Label();
         db_URL = new TextBox();
         label7 = new Label();
         db_Email = new TextBox();
         label6 = new Label();
         db_active = new CheckBox();
         db_Desc = new TextBox();
         label5 = new Label();
         db_Username = new TextBox();
         label1 = new Label();
         db_SiteName = new TextBox();
         passLabel = new Label();
         db_Password1 = new TextBox();
         label2 = new Label();
         ShowPasswordCheck = new CheckBox();
         topNamePanel.SuspendLayout();
         workPanel.SuspendLayout();
         baseBackPanel.SuspendLayout();
         baseDockPanel.SuspendLayout();
         bottomDockPanel.SuspendLayout();
         SuspendLayout();
         // 
         // baseToolBar
         // 
         baseToolBar.Size = new Size(583, 48);
         // 
         // topNamePanel
         // 
         topNamePanel.Size = new Size(583, 16);
         // 
         // workPanel
         // 
         workPanel.Controls.Add(ShowPasswordCheck);
         workPanel.Controls.Add(db_active);
         workPanel.Size = new Size(583, 26);
         // 
         // baseBackPanel
         // 
         baseBackPanel.Size = new Size(583, 468);
         // 
         // baseSepPanel
         // 
         baseSepPanel.Size = new Size(583, 1);
         // 
         // baseDockPanel
         // 
         baseDockPanel.BackColor = Color.White;
         baseDockPanel.Controls.Add(db_Password1);
         baseDockPanel.Controls.Add(label2);
         baseDockPanel.Controls.Add(db_PasswordHint);
         baseDockPanel.Controls.Add(label11);
         baseDockPanel.Controls.Add(db_Question3);
         baseDockPanel.Controls.Add(label10);
         baseDockPanel.Controls.Add(db_Question2);
         baseDockPanel.Controls.Add(label9);
         baseDockPanel.Controls.Add(db_Question1);
         baseDockPanel.Controls.Add(label8);
         baseDockPanel.Controls.Add(db_URL);
         baseDockPanel.Controls.Add(label7);
         baseDockPanel.Controls.Add(db_Email);
         baseDockPanel.Controls.Add(label6);
         baseDockPanel.Controls.Add(db_Desc);
         baseDockPanel.Controls.Add(label5);
         baseDockPanel.Controls.Add(db_Username);
         baseDockPanel.Controls.Add(label1);
         baseDockPanel.Controls.Add(db_SiteName);
         baseDockPanel.Controls.Add(passLabel);
         baseDockPanel.Location = new Point(0, 91);
         baseDockPanel.Size = new Size(583, 360);
         // 
         // bottomDockPanel
         // 
         bottomDockPanel.Location = new Point(0, 451);
         bottomDockPanel.Size = new Size(583, 17);
         // 
         // db_PasswordHint
         // 
         db_PasswordHint.BackColor = Color.White;
         db_PasswordHint.BorderStyle = BorderStyle.FixedSingle;
         db_PasswordHint.Font = new Font("Verdana", 9F, FontStyle.Bold);
         db_PasswordHint.ForeColor = Color.Black;
         db_PasswordHint.Location = new Point(9, 344);
         db_PasswordHint.Margin = new Padding(4, 3, 4, 3);
         db_PasswordHint.Name = "db_PasswordHint";
         db_PasswordHint.ReadOnly = true;
         db_PasswordHint.Size = new Size(278, 22);
         db_PasswordHint.TabIndex = 44;
         // 
         // label11
         // 
         label11.AutoSize = true;
         label11.Font = new Font("Verdana", 9F, FontStyle.Bold);
         label11.Location = new Point(9, 327);
         label11.Margin = new Padding(4, 0, 4, 0);
         label11.Name = "label11";
         label11.Size = new Size(108, 14);
         label11.TabIndex = 43;
         label11.Text = "Password Hint:";
         // 
         // db_Question3
         // 
         db_Question3.BackColor = Color.Red;
         db_Question3.BorderStyle = BorderStyle.FixedSingle;
         db_Question3.Font = new Font("Verdana", 9F, FontStyle.Bold);
         db_Question3.ForeColor = Color.White;
         db_Question3.Location = new Point(387, 302);
         db_Question3.Margin = new Padding(4, 3, 4, 3);
         db_Question3.Name = "db_Question3";
         db_Question3.ReadOnly = true;
         db_Question3.Size = new Size(180, 22);
         db_Question3.TabIndex = 42;
         // 
         // label10
         // 
         label10.AutoSize = true;
         label10.Font = new Font("Verdana", 9F, FontStyle.Bold);
         label10.Location = new Point(387, 285);
         label10.Margin = new Padding(4, 0, 4, 0);
         label10.Name = "label10";
         label10.Size = new Size(143, 14);
         label10.TabIndex = 41;
         label10.Text = "Security Question 3:";
         // 
         // db_Question2
         // 
         db_Question2.BackColor = Color.Red;
         db_Question2.BorderStyle = BorderStyle.FixedSingle;
         db_Question2.Font = new Font("Verdana", 9F, FontStyle.Bold);
         db_Question2.ForeColor = Color.White;
         db_Question2.Location = new Point(199, 302);
         db_Question2.Margin = new Padding(4, 3, 4, 3);
         db_Question2.Name = "db_Question2";
         db_Question2.ReadOnly = true;
         db_Question2.Size = new Size(180, 22);
         db_Question2.TabIndex = 40;
         // 
         // label9
         // 
         label9.AutoSize = true;
         label9.Font = new Font("Verdana", 9F, FontStyle.Bold);
         label9.Location = new Point(199, 285);
         label9.Margin = new Padding(4, 0, 4, 0);
         label9.Name = "label9";
         label9.Size = new Size(143, 14);
         label9.TabIndex = 39;
         label9.Text = "Security Question 2:";
         // 
         // db_Question1
         // 
         db_Question1.BackColor = Color.Red;
         db_Question1.BorderStyle = BorderStyle.FixedSingle;
         db_Question1.Font = new Font("Verdana", 9F, FontStyle.Bold);
         db_Question1.ForeColor = Color.White;
         db_Question1.Location = new Point(9, 302);
         db_Question1.Margin = new Padding(4, 3, 4, 3);
         db_Question1.Name = "db_Question1";
         db_Question1.ReadOnly = true;
         db_Question1.Size = new Size(180, 22);
         db_Question1.TabIndex = 38;
         // 
         // label8
         // 
         label8.AutoSize = true;
         label8.Font = new Font("Verdana", 9F, FontStyle.Bold);
         label8.Location = new Point(9, 285);
         label8.Margin = new Padding(4, 0, 4, 0);
         label8.Name = "label8";
         label8.Size = new Size(143, 14);
         label8.TabIndex = 37;
         label8.Text = "Security Question 1:";
         // 
         // db_URL
         // 
         db_URL.BackColor = Color.White;
         db_URL.BorderStyle = BorderStyle.FixedSingle;
         db_URL.Font = new Font("Verdana", 9F, FontStyle.Bold);
         db_URL.ForeColor = Color.Black;
         db_URL.Location = new Point(9, 260);
         db_URL.Margin = new Padding(4, 3, 4, 3);
         db_URL.Name = "db_URL";
         db_URL.ReadOnly = true;
         db_URL.Size = new Size(278, 22);
         db_URL.TabIndex = 36;
         // 
         // label7
         // 
         label7.AutoSize = true;
         label7.Font = new Font("Verdana", 9F, FontStyle.Bold);
         label7.Location = new Point(9, 243);
         label7.Margin = new Padding(4, 0, 4, 0);
         label7.Name = "label7";
         label7.Size = new Size(69, 14);
         label7.TabIndex = 35;
         label7.Text = "Site URL:";
         // 
         // db_Email
         // 
         db_Email.BackColor = Color.White;
         db_Email.BorderStyle = BorderStyle.FixedSingle;
         db_Email.Font = new Font("Verdana", 9F, FontStyle.Bold);
         db_Email.ForeColor = Color.Black;
         db_Email.Location = new Point(9, 218);
         db_Email.Margin = new Padding(4, 3, 4, 3);
         db_Email.Name = "db_Email";
         db_Email.ReadOnly = true;
         db_Email.Size = new Size(278, 22);
         db_Email.TabIndex = 34;
         // 
         // label6
         // 
         label6.AutoSize = true;
         label6.Font = new Font("Verdana", 9F, FontStyle.Bold);
         label6.Location = new Point(9, 201);
         label6.Margin = new Padding(4, 0, 4, 0);
         label6.Name = "label6";
         label6.Size = new Size(164, 14);
         label6.TabIndex = 33;
         label6.Text = "Email Used To Register:";
         // 
         // db_active
         // 
         db_active.AutoSize = true;
         db_active.BackColor = Color.LemonChiffon;
         db_active.FlatStyle = FlatStyle.Flat;
         db_active.Font = new Font("Verdana", 8F, FontStyle.Bold);
         db_active.Location = new Point(147, 4);
         db_active.Margin = new Padding(4, 3, 4, 3);
         db_active.Name = "db_active";
         db_active.Size = new Size(93, 17);
         db_active.TabIndex = 32;
         db_active.Text = "Site Active";
         db_active.UseVisualStyleBackColor = false;
         db_active.Click += db_active_Click;
         // 
         // db_Desc
         // 
         db_Desc.BackColor = Color.White;
         db_Desc.BorderStyle = BorderStyle.FixedSingle;
         db_Desc.Font = new Font("Verdana", 9F, FontStyle.Bold);
         db_Desc.ForeColor = Color.Black;
         db_Desc.Location = new Point(9, 176);
         db_Desc.Margin = new Padding(4, 3, 4, 3);
         db_Desc.Name = "db_Desc";
         db_Desc.ReadOnly = true;
         db_Desc.Size = new Size(278, 22);
         db_Desc.TabIndex = 31;
         // 
         // label5
         // 
         label5.AutoSize = true;
         label5.Font = new Font("Verdana", 9F, FontStyle.Bold);
         label5.Location = new Point(6, 159);
         label5.Margin = new Padding(4, 0, 4, 0);
         label5.Name = "label5";
         label5.Size = new Size(117, 14);
         label5.TabIndex = 30;
         label5.Text = "Site Description:";
         // 
         // db_Username
         // 
         db_Username.BackColor = Color.Red;
         db_Username.BorderStyle = BorderStyle.FixedSingle;
         db_Username.Font = new Font("Verdana", 9F, FontStyle.Bold);
         db_Username.ForeColor = Color.White;
         db_Username.Location = new Point(9, 87);
         db_Username.Margin = new Padding(4, 3, 4, 3);
         db_Username.Name = "db_Username";
         db_Username.ReadOnly = true;
         db_Username.Size = new Size(278, 22);
         db_Username.TabIndex = 29;
         // 
         // label1
         // 
         label1.AutoSize = true;
         label1.Font = new Font("Verdana", 9F, FontStyle.Bold);
         label1.Location = new Point(4, 61);
         label1.Margin = new Padding(4, 0, 4, 0);
         label1.Name = "label1";
         label1.Size = new Size(85, 14);
         label1.TabIndex = 28;
         label1.Text = "User Name:";
         // 
         // db_SiteName
         // 
         db_SiteName.BackColor = Color.White;
         db_SiteName.BorderStyle = BorderStyle.FixedSingle;
         db_SiteName.Font = new Font("Verdana", 9F, FontStyle.Bold);
         db_SiteName.ForeColor = Color.Black;
         db_SiteName.Location = new Point(9, 33);
         db_SiteName.Margin = new Padding(4, 3, 4, 3);
         db_SiteName.Name = "db_SiteName";
         db_SiteName.ReadOnly = true;
         db_SiteName.Size = new Size(567, 22);
         db_SiteName.TabIndex = 27;
         // 
         // passLabel
         // 
         passLabel.AutoSize = true;
         passLabel.Font = new Font("Verdana", 9F, FontStyle.Bold);
         passLabel.Location = new Point(4, 14);
         passLabel.Margin = new Padding(4, 0, 4, 0);
         passLabel.Name = "passLabel";
         passLabel.Size = new Size(80, 14);
         passLabel.TabIndex = 26;
         passLabel.Text = "Site Name:";
         // 
         // db_Password1
         // 
         db_Password1.BackColor = Color.Red;
         db_Password1.BorderStyle = BorderStyle.FixedSingle;
         db_Password1.Font = new Font("Verdana", 9F, FontStyle.Bold);
         db_Password1.ForeColor = Color.White;
         db_Password1.Location = new Point(9, 129);
         db_Password1.Margin = new Padding(4, 3, 4, 3);
         db_Password1.Name = "db_Password1";
         db_Password1.ReadOnly = true;
         db_Password1.Size = new Size(276, 22);
         db_Password1.TabIndex = 46;
         // 
         // label2
         // 
         label2.AutoSize = true;
         label2.Font = new Font("Verdana", 9F, FontStyle.Bold);
         label2.Location = new Point(4, 112);
         label2.Margin = new Padding(4, 0, 4, 0);
         label2.Name = "label2";
         label2.Size = new Size(154, 14);
         label2.TabIndex = 45;
         label2.Text = "Enter Vault Password:";
         // 
         // ShowPasswordCheck
         // 
         ShowPasswordCheck.AutoSize = true;
         ShowPasswordCheck.BackColor = Color.FromArgb(255, 255, 192);
         ShowPasswordCheck.Font = new Font("Verdana", 8F, FontStyle.Bold);
         ShowPasswordCheck.Location = new Point(6, 5);
         ShowPasswordCheck.Margin = new Padding(4, 3, 4, 3);
         ShowPasswordCheck.Name = "ShowPasswordCheck";
         ShowPasswordCheck.Size = new Size(133, 17);
         ShowPasswordCheck.TabIndex = 48;
         ShowPasswordCheck.Text = "Show Passwords";
         ShowPasswordCheck.UseVisualStyleBackColor = false;
         ShowPasswordCheck.CheckedChanged += ShowPasswordCheck_CheckedChanged;
         // 
         // ViewSiteForm
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(583, 468);
         FormBorderStyle = FormBorderStyle.FixedSingle;
         MaximizeBox = false;
         MinimizeBox = false;
         Name = "ViewSiteForm";
         StartPosition = FormStartPosition.CenterScreen;
         Text = "ViewSiteForm";
         topNamePanel.ResumeLayout(false);
         workPanel.ResumeLayout(false);
         workPanel.PerformLayout();
         baseBackPanel.ResumeLayout(false);
         baseDockPanel.ResumeLayout(false);
         baseDockPanel.PerformLayout();
         bottomDockPanel.ResumeLayout(false);
         ResumeLayout(false);
      }

      #endregion

      private TextBox db_PasswordHint;
      private Label label11;
      private TextBox db_Question3;
      private Label label10;
      private TextBox db_Question2;
      private Label label9;
      private TextBox db_Question1;
      private Label label8;
      private TextBox db_URL;
      private Label label7;
      private TextBox db_Email;
      private Label label6;
      private CheckBox db_active;
      private TextBox db_Desc;
      private Label label5;
      private TextBox db_Username;
      private Label label1;
      private TextBox db_SiteName;
      private Label passLabel;
      private TextBox db_Password1;
      private Label label2;
      private CheckBox ShowPasswordCheck;
   }
}