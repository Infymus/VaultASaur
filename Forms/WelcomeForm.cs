using VaultASaur3.ToolsBox;
using VaultASaur3.Globals;

namespace VaultASaur3.Forms
{
   public partial class WelcomeForm : Form
   {
      public WelcomeForm()
      {
         InitializeComponent();

         this.FormBorderStyle = FormBorderStyle.None;

         System.Windows.Forms.Timer closeTimer = new System.Windows.Forms.Timer();
         closeTimer.Interval = 2000;
         closeTimer.Tick += (sender, e) =>
         {
            closeTimer.Stop();
            this.Close();
         };
         closeTimer.Start();
      }
   }
}
