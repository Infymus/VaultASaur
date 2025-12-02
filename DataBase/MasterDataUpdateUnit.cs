/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/

using VaultASaur3.Enums;
using VaultASaur3.ErrorHandling;

namespace VaultASaur3.DataBase
{

   /// <summary>
   /// This class works with the MasterData object. It opens the GetTableName_Main and finds out what the version
   /// number in INTEGER format. If no database exists, it creates it fully. Then, based on the Main.DBID value, it will
   /// upgrade the database from any version forward. Makes it so database updates are super easy.
   /// </summary>
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






