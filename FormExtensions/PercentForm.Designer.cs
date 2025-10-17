namespace VaultASaur3.Extensions
{
    partial class PercentForm
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
            progressBar = new ProgressBar();
            headerLabel = new Label();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Dock = DockStyle.Bottom;
            progressBar.Location = new Point(2, 46);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(305, 25);
            progressBar.TabIndex = 0;
            // 
            // headerLabel
            // 
            headerLabel.Dock = DockStyle.Top;
            headerLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            headerLabel.Location = new Point(2, 2);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(305, 41);
            headerLabel.TabIndex = 1;
            headerLabel.Text = "Processing";
            // 
            // PercentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 73);
            Controls.Add(headerLabel);
            Controls.Add(progressBar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "PercentForm";
            Padding = new Padding(2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PercentForm";
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar;
        private Label headerLabel;
    }
}