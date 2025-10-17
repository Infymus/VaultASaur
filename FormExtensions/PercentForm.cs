using VaultASaur3.Enums;
using VaultASaur3.Forms;
using VaultASaur3.Globals;
using VaultASaur3.ToolsBox;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VaultASaur3.Extensions
{
    public partial class PercentForm : Form
    {
        public PercentForm()
        {
            InitializeComponent();
        }

        public void SetProgress(int startPos, int endPos)
        {
            progressBar.Maximum = endPos;
            progressBar.Minimum = 0;
            progressBar.Step = 1;
            progressBar.Value = startPos;
        }

        public void UpdateProgress()
        {
            progressBar.PerformStep();
        }

        public void IncreaseTotal(int inInc)
        {
            progressBar.Maximum += inInc;
        }

        public void UpdateHeader(string inHeader)
        {
            headerLabel.Text = inHeader;
        }

    }

    public static class tPercentForm
    {
        private static PercentForm frm_PercentForm;

        public static void Create(string inHeader, int startPos, int endPos)
        {
            if (frm_PercentForm == null || frm_PercentForm.IsDisposed)
            {
                frm_PercentForm = new PercentForm();
            }

            frm_PercentForm.UpdateHeader(inHeader);
            frm_PercentForm.SetProgress(startPos, endPos);
            
            frm_PercentForm.Show();
            frm_PercentForm.BringToFront();
            frm_PercentForm.Refresh();

        }

        public static void Close()
        {
            frm_PercentForm.Close();
        }

        public static void UpdateHeader(string inHeader)
        {
            frm_PercentForm.UpdateHeader(inHeader);
        }

        public static void IncreaseTotal(int inInc)
        {
            frm_PercentForm.IncreaseTotal(inInc);
        }

        public static void UpdateProgress()
        {
            frm_PercentForm.UpdateProgress();
        }

    }
}
