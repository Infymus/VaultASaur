/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/

using System.Text;

namespace VaultASaur3.Globals
{
   public static class Constants
   {
      // NOTE: Version is handled by Build Settings
      public const int AppWidth = 1024;
      public const int AppHeight = 768;
      public const int StartFormCount = 7;
      public const int UpdateRuntimes = 10;

      public const string VaultPasswordGuid = "AF4FCD01-B71C-451B-9387-233F7312F575";
      public const string DatabaseSessionName = "VaultSession";
      public const string AppBackupDir = "backups";
      public const string AppDatabaseDir = "database";
      public const string ProgramName = "VaultASaur";
      public const string ProgramMutex = "VaultASaurMutex";
      public const string ProgramCaption = "Simple to use encrypted password vault system.";
      public static string AppConfigHeader = "VaultASaur";
      public static string appConfigFile = "appsettings.json";
      public static string appConfigDir = AppContext.BaseDirectory;
      public const string ProgramLog = "VaultASaur.log";
      public static byte[] charCodes = new byte[]
      {
          88, 90, 120, 112, 115, 121, 97, 117, 75, 110,
          101, 84, 57, 90, 101, 84, 104, 51, 100, 119,
          99, 120, 114, 106, 116, 110, 68, 117, 81, 114,
          114, 71, 110, 114, 97, 102
      };
      public static string bktkobj711A = Encoding.ASCII.GetString(charCodes);
   }
}

