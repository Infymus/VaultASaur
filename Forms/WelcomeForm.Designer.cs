namespace VaultASaur3.Forms
{
   partial class WelcomeForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
         vaultPic = new PictureBox();
         ((System.ComponentModel.ISupportInitialize)vaultPic).BeginInit();
         SuspendLayout();
         // 
         // vaultPic
         // 
         vaultPic.BackgroundImage = (Image)resources.GetObject("vaultPic.BackgroundImage");
         vaultPic.BackgroundImageLayout = ImageLayout.Stretch;
         vaultPic.BorderStyle = BorderStyle.FixedSingle;
         vaultPic.Dock = DockStyle.Fill;
         vaultPic.Location = new Point(0, 0);
         vaultPic.Name = "vaultPic";
         vaultPic.Size = new Size(578, 296);
         vaultPic.TabIndex = 2;
         vaultPic.TabStop = false;
         // 
         // WelcomeForm
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         AutoSize = true;
         ClientSize = new Size(578, 296);
         ControlBox = false;
         Controls.Add(vaultPic);
         FormBorderStyle = FormBorderStyle.FixedSingle;
         Name = "WelcomeForm";
         StartPosition = FormStartPosition.CenterScreen;
         ((System.ComponentModel.ISupportInitialize)vaultPic).EndInit();
         ResumeLayout(false);
      }

      #endregion

      private PictureBox vaultPic;
   }
}