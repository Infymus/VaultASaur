using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VaultASaur.Forms
{
    public partial class BaseForm : Form
    {
        // Define the delegate type
        public delegate void BaseFormDelegate(int eventCMD);


        // Define an event of that delegate type
        public event BaseFormDelegate BaseFormDelegateEvent;

        public BaseForm()
        {
            InitializeComponent();
        }

        public void SetCaptionName(string inName)
        {
            baseFormCaption.Text = inName;
        }

        // To execute this use:
        // RaiseUpdateStuff(Actions.CMD_VIEW);
        protected void BaseFormDelegateEventHandle(int eventCMD)
        {
            BaseFormDelegateEvent?.Invoke(eventCMD);
        }


    }


}
