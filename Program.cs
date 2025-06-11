using VaultASaur.DataBase;
using VaultASaur.ErrorHandling;
using VaultASaur.Forms;
using VaultASaur.Globals;

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

                // New Database so we need a new PassPhrase
                if (t.NewDataBase)
                {

                }

                // Show the VaultPasswordForm as a dialog
                using (VaultPasswordForm passwordForm = new VaultPasswordForm())
                {
                    DialogResult result = passwordForm.ShowDialog();

                    // Only run MainForm if the password was correct
                    if (result == DialogResult.OK)
                    {
                        Application.Run(new MainForm());
                    }
                    else
                    {
                        // Optionally log or notify failed attempt
                        MessageBox.Show("Access denied. Exiting application.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // Run the Forms
                Application.Run(new MainForm());
            }
        }
    }
}