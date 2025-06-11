using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaultASaur.Globals
{
    public static class Constants
    {
        // NOTE: Version is handled by Build Settings
        public const int AppWidth = 1024;
        public const int AppHeight = 768;
        public const int StartFormCount = 7;
        public const int UpdateRuntimes = 10;

        public const double ver_num = 2.0;
        public const string AppBackupDir = "backups";
        public const string AppDatabaseDir = "database";
        public const string SiteNoError = "NO ERROR";
        public const string ExpressionSep = "^EXP|SEP^";
        public const string ProgramName = "VaultASaur";
        public const string ProgramMutex = "VaultASaurMutex";
        public const string ProgramCopyright = "(c)2015-2025 Infymus";
        public static string AppConfigHeader = "VaultASaur";
        public static string appConfigFile = "appsettings.json";
        public static string appConfigDir = AppContext.BaseDirectory;
        public const string VAULTASAUR_PASSWORD_GUID = "AF4FCD01-B71C-451B-9387-233F7312F575";

        public static string VaultPassword = "";

    }
}

