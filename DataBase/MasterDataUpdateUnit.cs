using VaultASaur.Enums;
using VaultASaur.ErrorHandling;
using VaultASaur.Objects;
using VaultASaur.ToolsBox;

namespace VaultASaur.DataBase
{
    public static class MasterDataUpdateUnit
    {
        private static int File_Struct_Count = 1;
        private static int Start_DB_Version = 100;
        private static int Next_DB_Version = 101;
        private static string sqlStr = "";

        //
        public static tErrorResult UpdateTables()
        {
            tErrorResult t = new tErrorResult();

            if (!MasterData.TableExists(MasterData.GetTableName_Vault))
                t.NewDataBase = true;

            // ===========================================================================================
            // create the initial table_main - It contains the DBID or Database Version id.
            sqlStr = $@"CREATE TABLE IF NOT EXISTS {MasterData.GetTableName_Main} (DBID INTEGER PRIMARY KEY);";
            t = MasterData.ExecuteSQL(sqlStr, null);
            int dbVersion = MasterData.GetDataBaseVersion();
            if (dbVersion < Start_DB_Version)
            {
                MasterData.StartDBVersion();
                MasterData.SetDBVersion(Start_DB_Version);
            }
            if (t.errorResult)
                return t;

            // ===========================================================================================
            // FILTER
            sqlStr = $@"CREATE TABLE IF NOT EXISTS {MasterData.GetTableName_Vault}  
                (ID INTEGER PRIMARY KEY AUTOINCREMENT,
                 SITENAME TEXT,
                 USERNAME TEXT,
                 PASSWORD TEXT,
                 PASSWORDHINT TEXT,
                 EMAIL TEXT,
                 QUESTION1 TEXT,
                 QUESTION2 TEXT,
                 QUESTION3 TEXT,
                 URL TEXT,
                 DESCRIPT TEXT,
                 ISACTIVE INT);";
            t = MasterData.ExecuteSQL(sqlStr, null);
            if (t.errorResult)
                return t;

            // ===========================================================================================
            // PREFERENCES
            sqlStr = $@"CREATE TABLE IF NOT EXISTS {MasterData.GetTableName_Preference}
                (ID INTEGER PRIMARY KEY AUTOINCREMENT,
                PNAME TEXT,      
                ASSTR TEXT,      
                ASBOOL INT,  
                ASGUID TEXT,     
                ASMEMO BLOB,     
                ASINT INT,   
                ASCURR REAL);";
            t = MasterData.ExecuteSQL(sqlStr, null);
            if (t.errorResult)
                return t;

            // %%%%%%%%%%%%%%% UPDATES FROM HERE ON ONLY %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% //


            // UPDATE 101
            if (MasterData.CompareVersion(101))
            {
                // Add the default preferences
                // Preferences
                //dbPreference.SetInt(tPrefConstants.KeepDay, 365);
            }


            // %%%%%%%%%%%%%%% NO MORE UPDATES AFTER THIS %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% //

            MasterData.SetDBVersion(Next_DB_Version);

            return new tErrorResult();
        }


    }
}






