using VaultASaur.DataBase;
using VaultASaur.Forms;
using VaultASaur.Globals;
using VaultASaur.ErrorHandling;
using VaultASaur.DataBase;
using VaultASaur.Forms;
using VaultASaur.ErrorHandling;

namespace VaultASaur
{
    internal static class Program
    {
        private const string MutexName = $"{Constants.ProgramMutex}";
        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(true, MutexName, out bool isNewInstance))
            {
                if (!isNewInstance)
                {
                    // If not, show a message and exit
                    MessageBox.Show("The application is already running.", "Single Instance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // Run the application
                ApplicationConfiguration.Initialize();

                // Update the Database
                tErrorResult t = MasterDataUpdateUnit.UpdateTables();
                if (t.errorResult)
                    throw new Exception(t.errorMessage);

                // Run the Forms
                Application.Run(new MainForm());
            }
        }
    }
}