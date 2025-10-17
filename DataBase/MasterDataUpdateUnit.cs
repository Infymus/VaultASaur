using VaultASaur3.Enums;
using VaultASaur3.ErrorHandling;
using VaultASaur3.Objects;
using VaultASaur3.ToolsBox;

namespace VaultASaur3.DataBase
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
         tErrorResult t;

         // ===========================================================================================
         // create the initial table_main - It contains the DBID or Database Version id.
         sqlStr = $@"CREATE TABLE IF NOT EXISTS {MasterData.GetTableName_Main} 
                (DBID INTEGER PRIMARY KEY);";
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
         // VAULT
         sqlStr = $@"CREATE TABLE IF NOT EXISTS {MasterData.GetTableName_Vault}  
                (ID INTEGER PRIMARY KEY AUTOINCREMENT,
                 SITENAME TEXT,
                 USERNAME TEXT,
                 PASSWORD TEXT,
                 SITEDESC TEXT,
                 EMAIL TEXT,
                 SITEURL TEXT,
                 SECQUEST1 TEXT,
                 SECQUEST2 TEXT,
                 SECQUEST3 TEXT,
                 SECQUEST4 TEXT,
                 PASSHINT TEXT,
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
            //tVaultRec tAddFilt = new tVaultRec();
            //tAddFilt.FName = "Hells Kitchen";
            //tAddFilt.FID = tFed.AsLong;
            //tAddFilt.FExpression = "+Hells Kitchen\r\n+1080";
            //tAddFilt.FStartSeason = 0;
            //tAddFilt.FStartEpisode = 0;
            //tAddFilt.FEndSeason = 0;
            //tAddFilt.FEndEpisode = 0;
            //tAddFilt.FStartYear = 0;
            //tAddFilt.FEndYear = 0;
            //tAddFilt.FUseHistory = 1;
            //tAddFilt.FDlType = 0;
            //tAddFilt.IsActive = 1;
            //tAddFilt.LocalDir = "";
            //tAddFilt.DlOption = 1;
            //tAddFilt.SaveDir = "";
            //dbVault.Add(tAddFilt);

            // Preferences
            dbPreference.SetInt(tPrefConstants.AutoClose, 300);
            dbPreference.SetString(tPrefConstants.Hint, "");
         }

         // %%%%%%%%%%%%%%% NO MORE UPDATES AFTER THIS %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% //

         MasterData.SetDBVersion(Next_DB_Version);

         return new tErrorResult();
      }


   }
}






