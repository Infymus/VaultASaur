using System.Data;
using System.Data.SQLite;
using VaultASaur3.Encryption;
using VaultASaur3.Enums;
using VaultASaur3.ErrorHandling;
using VaultASaur3.Extensions;
using VaultASaur3.Objects;
using VaultASaur3.ToolsBox;
using System.Text.Json;

namespace VaultASaur3.DataBase
{
   public static class dbVault
   {
      public static tErrorResult Add(tVaultRec inVaultRec)
      {
         tErrorResult t;
         string sqlStr = $@"INSERT INTO {MasterData.GetTableName_Vault} 
            (SITENAME, USERNAME, PASSWORD, EMAIL, SITEURL, SECQUEST1, SECQUEST2, SECQUEST3, SECQUEST4, PASSHINT, ISACTIVE, SITEDESC)
            VALUES 
            (@SITENAME, @USERNAME, @PASSWORD, @EMAIL, @SITEURL, @SECQUEST1, @SECQUEST2, @SECQUEST3, @SECQUEST4, @PASSHINT, @ISACTIVE, @SITEDESC)";

         var parameters = new Dictionary<string, object>
         {
            { "@SITENAME", inVaultRec.SITENAME },
            { "@USERNAME", inVaultRec.USERNAME },
            { "@PASSWORD", inVaultRec.PASSWORD },
            { "@EMAIL", inVaultRec.EMAIL },
            { "@SITEURL", inVaultRec.SITEURL },
            { "@SECQUEST1", inVaultRec.SECQUEST1 },
            { "@SECQUEST2", inVaultRec.SECQUEST2 },
            { "@SECQUEST3", inVaultRec.SECQUEST3 },
            { "@SECQUEST4", inVaultRec.SECQUEST4 },
            { "@SITEDESC", inVaultRec.SITEDESC },
            { "@PASSHINT", inVaultRec.PASSHINT },
            { "@ISACTIVE", inVaultRec.IsActive }
         };

         t = MasterData.ExecuteSQL(sqlStr, parameters);
         return t;
      }

      public static tErrorResult AddAndSync(tVaultRec inVaultRec, DataRow inRow)
      {
         // Add the record to the DB
         tErrorResult t = Add(inVaultRec);
         // Add it to our in memory DataRow
         if (!t.errorResult)
         {
            inRow["ID"] = t.AsLong;
            inRow["SITENAME"] = inVaultRec.SITENAME;
            inRow["USERNAME"] = inVaultRec.USERNAME;
            inRow["PASSWORD"] = inVaultRec.PASSWORD;
            inRow["EMAIL"] = inVaultRec.EMAIL;
            inRow["SITEURL"] = inVaultRec.SITEURL;
            inRow["SECQUEST1"] = inVaultRec.SECQUEST1;
            inRow["SECQUEST2"] = inVaultRec.SECQUEST2;
            inRow["SECQUEST3"] = inVaultRec.SECQUEST3;
            inRow["SECQUEST4"] = inVaultRec.SECQUEST4;
            inRow["PASSHINT"] = inVaultRec.PASSHINT;
            inRow["SITEDESC"] = inVaultRec.SITEDESC;
            inRow["ISACTIVE"] = inVaultRec.IsActive;

            try
            {
               inRow.AcceptChanges();
            }
            catch (Exception ex)
            {
               t.errorResult = true;
               t.errorMessage = ex.Message;
            }
         }
         return t;
      }

      public static tErrorResult UpdateAndSync(tVaultRec inVaultRec, DataRow inRow)
      {
         // Add the record to the DB
         tErrorResult t = Update(inVaultRec);
         // Add it to our in memory DataRow
         if (!t.errorResult)
         {
            inRow["ID"] = t.AsLong;
            inRow["SITENAME"] = inVaultRec.SITENAME;
            inRow["USERNAME"] = inVaultRec.USERNAME;
            inRow["PASSWORD"] = inVaultRec.PASSWORD;
            inRow["SITEDESC"] = inVaultRec.SITEDESC;
            inRow["EMAIL"] = inVaultRec.EMAIL;
            inRow["SITEURL"] = inVaultRec.SITEURL;
            inRow["SECQUEST1"] = inVaultRec.SECQUEST1;
            inRow["SECQUEST2"] = inVaultRec.SECQUEST2;
            inRow["SECQUEST3"] = inVaultRec.SECQUEST3;
            inRow["SECQUEST4"] = inVaultRec.SECQUEST4;
            inRow["PASSHINT"] = inVaultRec.PASSHINT;
            inRow["ISACTIVE"] = inVaultRec.IsActive;

            try
            {
               inRow.AcceptChanges();
            }
            catch (Exception ex)
            {
               t.errorResult = true;
               t.errorMessage = ex.Message;
            }
         }
         return t;
      }

      public static tVaultRec Get(string inID)
      {
         tVaultRec t = new tVaultRec();
         tErrorResult e;
         string sqlStr = $@"SELECT * FROM {MasterData.GetTableName_Vault} WHERE ID = @ID";
         var parameters = new Dictionary<string, object>
                {
                    { "@ID", inID }
                };
         using (SQLiteDataReader reader = MasterData.ExecuteQuery(sqlStr, parameters, out e))
         {
            if (!e.errorResult)
            {
               if (reader.Read())
               {
                  t.ID = Convert.ToInt64(reader["ID"]);
                  t.SITENAME = reader["SITENAME"].ToString() ?? string.Empty;
                  t.USERNAME = reader["USERNAME"].ToString() ?? string.Empty;
                  t.PASSWORD = reader["PASSWORD"].ToString() ?? string.Empty;
                  t.EMAIL = reader["EMAIL"].ToString() ?? string.Empty;
                  t.SITEURL = reader["SITEURL"].ToString() ?? string.Empty;
                  t.SECQUEST1 = reader["SECQUEST1"].ToString() ?? string.Empty;
                  t.SECQUEST2 = reader["SECQUEST2"].ToString() ?? string.Empty;
                  t.SECQUEST3 = reader["SECQUEST3"].ToString() ?? string.Empty;
                  t.SECQUEST4 = reader["SECQUEST4"].ToString() ?? string.Empty;
                  t.PASSHINT = reader["PASSHINT"].ToString() ?? string.Empty;
                  t.SITEDESC = reader["SITEDESC"].ToString() ?? string.Empty;
                  t.IsActive = Convert.ToInt32(reader["ISACTIVE"]);
               }
            }
         }
         return t;
      }

      public static tErrorResult Update(tVaultRec inVaultRec)
      {
         tErrorResult t;
         string sqlStr = $@"UPDATE {MasterData.GetTableName_Vault}
              SET SITENAME = @SITENAME,
                  USERNAME = @USERNAME,
                  PASSWORD = @PASSWORD,
                  EMAIL = @EMAIL,
                  SITEURL = @SITEURL,
                  SECQUEST1 = @SECQUEST1,
                  SECQUEST2 = @SECQUEST2,
                  SECQUEST3 = @SECQUEST3,
                  SECQUEST4 = @SECQUEST4,
                  PASSHINT = @PASSHINT,
                  SITEDESC = @SITEDESC,
                  ISACTIVE = @ISACTIVE
              WHERE ID = @ID";
         var parameters = new Dictionary<string, object>
            {
                { "@SITENAME", inVaultRec.SITENAME },
                { "@USERNAME", inVaultRec.USERNAME },
                { "@PASSWORD", inVaultRec.PASSWORD },
                { "@EMAIL", inVaultRec.EMAIL },
                { "@SITEURL", inVaultRec.SITEURL },
                { "@SECQUEST1", inVaultRec.SECQUEST1 },
                { "@SECQUEST2", inVaultRec.SECQUEST2 },
                { "@SECQUEST3", inVaultRec.SECQUEST3 },
                { "@SECQUEST4", inVaultRec.SECQUEST4 },
                { "@PASSHINT", inVaultRec.PASSHINT },
                { "@SITEDESC", inVaultRec.SITEDESC },
                { "@ISACTIVE", inVaultRec.IsActive },
                { "@ID", inVaultRec.ID }
            };

         t = MasterData.ExecuteSQL(sqlStr, parameters);
         t.AsLong = inVaultRec.ID;
         return t;
      }

      public static void EnableDisabe(string inID)
      {
         tVaultRec t = Get(inID);
         t.IsActive = (t.IsActive == 1) ? 0 : 1;
         string sqlStr = $@"UPDATE {MasterData.GetTableName_Vault} SET ISACTIVE = @IsActive WHERE ID = @ID";
         var parameters = new Dictionary<string, object>
                {
                    { "@IsActive", t.IsActive },
                    { "@ID", inID }
                };
         tErrorResult result = MasterData.ExecuteSQL(sqlStr, parameters);
      }

      public static tErrorResult SetAllActiveFlag(ActiveStates inState)
      {
         tErrorResult t;
         string sqlStr = $@"UPDATE {MasterData.GetTableName_Vault} SET ISACTIVE = " + ToolBox.ConvertEnumToInt(inState);
         SQLiteDataReader reader = MasterData.ExecuteQuery(sqlStr, null, out t);
         return t;
      }

      public static DataTable GridLoadData(ActiveStates inActiveState)
      {
         using var conn = new SQLiteConnection(MasterData.ConnectionString());
         conn.Open();
         string sqlStr = @$"SELECT * FROM {MasterData.GetTableName_Vault}";

         switch (inActiveState)
         {
            case ActiveStates.StateActive:
               sqlStr += $@" WHERE ""ISACTIVE"" = 1";
               break;
            case ActiveStates.StateInactive:
               sqlStr += $@" WHERE ""ISACTIVE"" = 0";
               break;
            case ActiveStates.StateAll:
               // Show All
               break;
         }

         sqlStr += " ORDER BY SITENAME COLLATE NOCASE";
         var cmd = new SQLiteCommand(sqlStr, conn);
         var adapter = new SQLiteDataAdapter(cmd);
         var dt = new DataTable();
         adapter.Fill(dt);
         return dt;
      }

      /// <summary>
      /// If they change the password, every single item HAS to be reencrypted
      /// </summary>
      /// <param name="fOldPassword"></param>
      /// <param name="fNewPassword"></param>

      public static tErrorResult UpdatePassword(string fOldPassword, string fNewPassword)
      {
         tErrorResult e = new tErrorResult();
         tVaultRec t = new tVaultRec();

         string sqlStr = $@"SELECT * FROM {MasterData.GetTableName_Vault}";

         using (SQLiteDataReader reader = MasterData.ExecuteQuery(sqlStr, null, out e))
         {
            if (!e.errorResult)
            {
               if (reader.Read())
               {
                  t.ID = Convert.ToInt64(reader["ID"]);
                  t.SITENAME = reader["SITENAME"].ToString() ?? string.Empty;
                  t.USERNAME = reader["USERNAME"].ToString() ?? string.Empty;
                  t.PASSWORD = reader["PASSWORD"].ToString() ?? string.Empty;
                  t.EMAIL = reader["EMAIL"].ToString() ?? string.Empty;
                  t.SITEURL = reader["SITEURL"].ToString() ?? string.Empty;
                  t.SECQUEST1 = reader["SECQUEST1"].ToString() ?? string.Empty;
                  t.SECQUEST2 = reader["SECQUEST2"].ToString() ?? string.Empty;
                  t.SECQUEST3 = reader["SECQUEST3"].ToString() ?? string.Empty;
                  t.SECQUEST4 = reader["SECQUEST4"].ToString() ?? string.Empty;
                  t.PASSHINT = reader["PASSHINT"].ToString() ?? string.Empty;
                  t.SITEDESC = reader["SITEDESC"].ToString() ?? string.Empty;
                  t.IsActive = Convert.ToInt32(reader["ISACTIVE"]);

                  // Convert from Old Password
                  string fUsername = EncryptDecrypt.Decrypt(t.USERNAME, fOldPassword);
                  string fPassword = EncryptDecrypt.Decrypt(t.PASSWORD, fOldPassword);
                  string fSecquest1 = EncryptDecrypt.Decrypt(t.SECQUEST1, fOldPassword);
                  string fSecquest2 = EncryptDecrypt.Decrypt(t.SECQUEST2, fOldPassword);
                  string fSecquest3 = EncryptDecrypt.Decrypt(t.SECQUEST3, fOldPassword);

                  // Convert to New Password
                  t.USERNAME = EncryptDecrypt.Encrypt(fUsername, fNewPassword);
                  t.PASSWORD = EncryptDecrypt.Encrypt(fPassword, fNewPassword);
                  t.SECQUEST1 = EncryptDecrypt.Encrypt(fSecquest1, fNewPassword);
                  t.SECQUEST2 = EncryptDecrypt.Encrypt(fSecquest1, fNewPassword);
                  t.SECQUEST3 = EncryptDecrypt.Encrypt(fSecquest3, fNewPassword);

                  // Write it
                  Update(t);
               }
            }
         }
         return e;
      }

      public static tVaultRec DecryptDataRow(DataRow reader, string fPasswordPhrase)
      {
         try
         {
            return new tVaultRec
            {
               ID = Convert.ToInt64(reader["ID"]),
               SITENAME = reader["SITENAME"].ToString() ?? string.Empty,
               USERNAME = EncryptDecrypt.Decrypt(reader["USERNAME"].ToString() ?? string.Empty, fPasswordPhrase),
               PASSWORD = EncryptDecrypt.Decrypt(reader["PASSWORD"].ToString() ?? string.Empty, fPasswordPhrase),
               EMAIL = reader["EMAIL"].ToString() ?? string.Empty,
               SITEURL = reader["SITEURL"].ToString() ?? string.Empty,
               SECQUEST1 = EncryptDecrypt.Decrypt(reader["SECQUEST1"].ToString() ?? string.Empty, fPasswordPhrase),
               SECQUEST2 = EncryptDecrypt.Decrypt(reader["SECQUEST2"].ToString() ?? string.Empty, fPasswordPhrase),
               SECQUEST3 = EncryptDecrypt.Decrypt(reader["SECQUEST3"].ToString() ?? string.Empty, fPasswordPhrase),
               SECQUEST4 = EncryptDecrypt.Decrypt(reader["SECQUEST4"].ToString() ?? string.Empty, fPasswordPhrase),
               PASSHINT = reader["PASSHINT"].ToString() ?? string.Empty,
               SITEDESC = reader["SITEDESC"].ToString() ?? string.Empty,
               IsActive = Convert.ToInt32(reader["ISACTIVE"])
            };
         }
         catch (Exception ex)
         {
            return new tVaultRec();
         }
      }

      public static tVaultRec GetDTRow(tDataGridView inGrid, string fPasswordPhrase)
      {
         if (inGrid.Count == 0)
            return new tVaultRec();
         DataRow reader = inGrid.GetDataRow();
         if (reader == null)
            return new tVaultRec();
         try
         {
            return new tVaultRec
            {
               ID = Convert.ToInt64(reader["ID"]),
               SITENAME = reader["SITENAME"].ToString() ?? string.Empty,
               USERNAME = EncryptDecrypt.Decrypt(reader["USERNAME"].ToString() ?? string.Empty, fPasswordPhrase),
               PASSWORD = EncryptDecrypt.Decrypt(reader["PASSWORD"].ToString() ?? string.Empty, fPasswordPhrase),
               EMAIL = reader["EMAIL"].ToString() ?? string.Empty,
               SITEURL = reader["SITEURL"].ToString() ?? string.Empty,
               SECQUEST1 = EncryptDecrypt.Decrypt(reader["SECQUEST1"].ToString() ?? string.Empty, fPasswordPhrase),
               SECQUEST2 = EncryptDecrypt.Decrypt(reader["SECQUEST2"].ToString() ?? string.Empty, fPasswordPhrase),
               SECQUEST3 = EncryptDecrypt.Decrypt(reader["SECQUEST3"].ToString() ?? string.Empty, fPasswordPhrase),
               SECQUEST4 = EncryptDecrypt.Decrypt(reader["SECQUEST4"].ToString() ?? string.Empty, fPasswordPhrase),
               PASSHINT = reader["PASSHINT"].ToString() ?? string.Empty,
               SITEDESC = reader["SITEDESC"].ToString() ?? string.Empty,
               IsActive = Convert.ToInt32(reader["ISACTIVE"])
            };
         }
         catch
         {
            return new tVaultRec();
         }
      }

      public static void Encrypt(ref tVaultRec t, string inPasswordPhrase)
      {
         t.USERNAME = EncryptDecrypt.Encrypt(t.USERNAME, inPasswordPhrase);
         t.PASSWORD = EncryptDecrypt.Encrypt(t.PASSWORD, inPasswordPhrase);
         t.SECQUEST1 = EncryptDecrypt.Encrypt(t.SECQUEST1, inPasswordPhrase);
         t.SECQUEST2 = EncryptDecrypt.Encrypt(t.SECQUEST2, inPasswordPhrase);
         t.SECQUEST3 = EncryptDecrypt.Encrypt(t.SECQUEST3, inPasswordPhrase);
         t.SECQUEST4 = EncryptDecrypt.Encrypt("", inPasswordPhrase);
      }

      public static void ExportDatabase(string inFileName, string inPasswordPhrase)
      {
         using var conn = new SQLiteConnection(MasterData.ConnectionString());
         conn.Open();
         string sqlStr = @$"SELECT * FROM {MasterData.GetTableName_Vault}";
         var cmd = new SQLiteCommand(sqlStr, conn);
         var adapter = new SQLiteDataAdapter(cmd);
         var dt = new DataTable();
         adapter.Fill(dt);

         var decryptedVaultEntries = new List<tVaultRec>();

         foreach (DataRow row in dt.Rows)
         {
            var decryptedRec = DecryptDataRow(row, inPasswordPhrase);
            decryptedVaultEntries.Add(decryptedRec);
         }
         var options = new JsonSerializerOptions { WriteIndented = true };
         string jsonString = JsonSerializer.Serialize(decryptedVaultEntries, options);
                  
         try
         {
            File.WriteAllText(inFileName, jsonString);
         }
         catch (Exception ex)
         {
         }
      }

      public static void ImportDatabase()
      {
      }




   }
}
