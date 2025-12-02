/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/

using VaultASaur3.DataBase;
using VaultASaur3.Forms;
using VaultASaur3.Globals;
using VaultASaur3.ErrorHandling;

namespace VaultASaur3
{
   internal static class Program
   {
      private const string MutexName = $"{Constants.ProgramMutex}";

      /// <summary>
      ///  The main entry point for the application.
      /// </summary>
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

            // Clear the ClipBoard
            try
            {
               Clipboard.Clear();
            }
            catch (Exception ex)
            {
            }

         }

      }
   }
}