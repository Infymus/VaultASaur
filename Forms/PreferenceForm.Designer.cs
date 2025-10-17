namespace VaultASaur3.Forms
{
    partial class frm_PreferenceForm
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
         groupBox1 = new GroupBox();
         label2 = new Label();
         pKeepDays = new TextBox();
         label1 = new Label();
         topNamePanel.SuspendLayout();
         baseBackPanel.SuspendLayout();
         baseDockPanel.SuspendLayout();
         bottomDockPanel.SuspendLayout();
         groupBox1.SuspendLayout();
         SuspendLayout();
         // 
         // baseToolBar
         // 
         baseToolBar.Size = new Size(800, 48);
         // 
         // topNamePanel
         // 
         topNamePanel.Size = new Size(800, 16);
         // 
         // workPanel
         // 
         workPanel.Size = new Size(800, 36);
         // 
         // baseBackPanel
         // 
         baseBackPanel.Size = new Size(800, 450);
         // 
         // baseSepPanel
         // 
         baseSepPanel.Size = new Size(800, 1);
         // 
         // baseDockPanel
         // 
         baseDockPanel.AutoScroll = true;
         baseDockPanel.Controls.Add(groupBox1);
         baseDockPanel.Location = new Point(0, 101);
         baseDockPanel.Size = new Size(800, 332);
         // 
         // bottomDockPanel
         // 
         bottomDockPanel.Location = new Point(0, 433);
         bottomDockPanel.Size = new Size(800, 17);
         // 
         // groupBox1
         // 
         groupBox1.Controls.Add(label2);
         groupBox1.Controls.Add(pKeepDays);
         groupBox1.Controls.Add(label1);
         groupBox1.Dock = DockStyle.Top;
         groupBox1.Location = new Point(0, 0);
         groupBox1.Name = "groupBox1";
         groupBox1.Size = new Size(800, 67);
         groupBox1.TabIndex = 3;
         groupBox1.TabStop = false;
         groupBox1.Text = "General Settings";
         // 
         // label2
         // 
         label2.AutoSize = true;
         label2.Location = new Point(49, 33);
         label2.Name = "label2";
         label2.Size = new Size(111, 13);
         label2.TabIndex = 5;
         label2.Text = "(0 = Never Close)";
         // 
         // pKeepDays
         // 
         pKeepDays.Location = new Point(6, 32);
         pKeepDays.Name = "pKeepDays";
         pKeepDays.Size = new Size(36, 20);
         pKeepDays.TabIndex = 4;
         // 
         // label1
         // 
         label1.AutoSize = true;
         label1.Location = new Point(3, 16);
         label1.Name = "label1";
         label1.Size = new Size(330, 13);
         label1.TabIndex = 3;
         label1.Text = "Total seconds of non-use before VaultASaur Auto-Closes";
         // 
         // frm_PreferenceForm
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(800, 450);
         Name = "frm_PreferenceForm";
         Text = "Form1";
         topNamePanel.ResumeLayout(false);
         baseBackPanel.ResumeLayout(false);
         baseDockPanel.ResumeLayout(false);
         bottomDockPanel.ResumeLayout(false);
         groupBox1.ResumeLayout(false);
         groupBox1.PerformLayout();
         ResumeLayout(false);
      }

      #endregion

      private GroupBox groupBox1;
        private Label label2;
        private TextBox pKeepDays;
        private Label label1;
    }
}