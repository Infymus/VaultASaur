namespace VaultASaur.Extensions
{
    partial class dbGridForm
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
            ControlPanel = new Panel();
            GridPanel = new Panel();
            dataGridView1 = new DataGridView();
            GridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // ControlPanel
            // 
            ControlPanel.Dock = DockStyle.Left;
            ControlPanel.Location = new Point(0, 0);
            ControlPanel.Name = "ControlPanel";
            ControlPanel.Size = new Size(59, 450);
            ControlPanel.TabIndex = 0;
            // 
            // GridPanel
            // 
            GridPanel.Controls.Add(dataGridView1);
            GridPanel.Dock = DockStyle.Fill;
            GridPanel.Location = new Point(59, 0);
            GridPanel.Name = "GridPanel";
            GridPanel.Size = new Size(741, 450);
            GridPanel.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(741, 450);
            dataGridView1.TabIndex = 1;
            // 
            // dbGridForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(GridPanel);
            Controls.Add(ControlPanel);
            Name = "dbGridForm";
            Text = "dbGridForm";
            GridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel ControlPanel;
        private Panel GridPanel;
        private DataGridView dataGridView1;
    }
}