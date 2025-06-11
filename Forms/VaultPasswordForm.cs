using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaultASaur.Globals;

namespace VaultASaur.Forms
{
    public partial class VaultPasswordForm : Form
    {
        public VaultPasswordForm()
        {
            InitializeComponent();
            this.Text = $"{Constants.ProgramName} {Constants.ver_num}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Constants.VaultPassword = PasswordDialog.Text;
            //this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Constants.VaultPassword = "";
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
