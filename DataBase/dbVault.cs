/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/

using System.Data;
using System.Data.SQLite;
using System.Text.Json;
using VaultASaur3.Encryption;
using VaultASaur3.Enums;
using VaultASaur3.ErrorHandling;
using VaultASaur3.Extensions;
using VaultASaur3.Objects;
using VaultASaur3.ToolsBox;


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
         string sqlStr = $@"SELECT * FROM {MasterData.GetTableName_Vault} WHERE ID = @ID";
         var parameters = new Dictionary<string, object>
                {
                    { "@ID", inID }
                };
         using (SQLiteDataReader reader = MasterData.ExecuteQuery(sqlStr, parameters, out tErrorResult e))
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
         string sqlStr = $@"UPDATE {MasterData.GetTableName_Vault} SET ISACTIVE = " + ToolBox.ConvertEnumToInt(inState);
         SQLiteDataReader reader = MasterData.ExecuteQuery(sqlStr, null, out tErrorResult t);
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
         tVaultRec t = new tVaultRec();
         tErrorResult e;
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
                  t.SECQUEST2 = EncryptDecrypt.Encrypt(fSecquest2, fNewPassword);
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
         t.USERNAME = EncryptDecrypt.Encrypt(t.USERNAME ?? string.Empty, inPasswordPhrase);
         t.PASSWORD = EncryptDecrypt.Encrypt(t.PASSWORD ?? string.Empty, inPasswordPhrase);
         t.SECQUEST1 = EncryptDecrypt.Encrypt(t.SECQUEST1 ?? string.Empty, inPasswordPhrase);
         t.SECQUEST2 = EncryptDecrypt.Encrypt(t.SECQUEST2 ?? string.Empty, inPasswordPhrase);
         t.SECQUEST3 = EncryptDecrypt.Encrypt(t.SECQUEST3 ?? string.Empty, inPasswordPhrase);
         t.SECQUEST4 = EncryptDecrypt.Encrypt(t.SECQUEST4 ?? string.Empty, inPasswordPhrase);
      }

      public static bool CheckDuplicates(tVaultRec t)
      {
         bool found = false;
         try
         {
            using var conn = new SQLiteConnection(MasterData.ConnectionString());
            conn.Open();
            string sqlStr = $@"SELECT 1 FROM {MasterData.GetTableName_Vault} WHERE UPPER(SITENAME) = @SITENAMEUPPER LIMIT 1";
            using var cmd = new SQLiteCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@SITENAMEUPPER", (t.SITENAME ?? string.Empty).ToUpperInvariant());
            var result = cmd.ExecuteScalar();
            if (result != null)
            {
               found = true;
            }
         }
         catch (Exception)
         {
         }
         return found;
      }

      public static tErrorResult ExportDatabase(string inFileName, string inPasswordPhrase)
      {
         var result = new tErrorResult();
         if (string.IsNullOrWhiteSpace(inFileName))
         {
            result.errorResult = true;
            result.errorMessage = "Export file path cannot be empty.";
            return result;
         }

         if (string.IsNullOrEmpty(inPasswordPhrase))
         {
            result.errorResult = true;
            result.errorMessage = "Vault password phrase is not set. Cannot decrypt records for export.";
            return result;
         }

         try
         {
            using var conn = new SQLiteConnection(MasterData.ConnectionString());
            conn.Open();
            string sqlStr = @$"SELECT * FROM {MasterData.GetTableName_Vault}";
            using var cmd = new SQLiteCommand(sqlStr, conn);
            using var adapter = new SQLiteDataAdapter(cmd);
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

            File.WriteAllText(inFileName, jsonString);
            result.errorResult = false;
            result.AsInteger = decryptedVaultEntries.Count;
            result.errorMessage = $"Successfully exported {decryptedVaultEntries.Count} site(s) to:\n{inFileName}";
         }
         catch (Exception ex)
         {
            result.errorResult = true;
            result.errorMessage = $"Failed to export database:\n{ex.Message}";
         }
         return result;
      }

      public static tErrorResult ImportDatabase(string inFileName, string inPasswordPhrase)
      {
         var result = new tErrorResult();

         if (string.IsNullOrWhiteSpace(inFileName) || !File.Exists(inFileName))
         {
            result.errorResult = true;
            result.errorMessage = $"The import file was not found:\n{inFileName}";
            return result;
         }

         if (string.IsNullOrEmpty(inPasswordPhrase))
         {
            result.errorResult = true;
            result.errorMessage = "Vault password phrase is not set. Please unlock the vault first.";
            return result;
         }

         try
         {
            string content = File.ReadAllText(inFileName);
            var records = ParseVaultRecords(content);

            if (records == null || records.Count == 0)
            {
               result.errorResult = true;
               result.errorMessage = "No valid site records could be parsed from the file.";
               return result;
            }

            int importCount = 0;
            int duplicateCount = 0;
            int errorCount = 0;

            foreach (var rec in records)
            {
               if (string.IsNullOrWhiteSpace(rec.SITENAME))
                  continue;

               if (CheckDuplicates(rec))
               {
                  duplicateCount++;
                  continue;
               }

               var vaultRec = rec;
               Encrypt(ref vaultRec, inPasswordPhrase);

               var addResult = Add(vaultRec);
               if (!addResult.errorResult)
               {
                  importCount++;
               }
               else
               {
                  errorCount++;
               }
            }

            result.errorResult = false;
            result.AsInteger = importCount;
            result.errorMessage = $"Import completed.\n\nTotal in file: {records.Count}\nImported: {importCount}\nSkipped Duplicates: {duplicateCount}";
            if (errorCount > 0)
            {
               result.errorMessage += $"\nErrors: {errorCount}";
            }
         }
         catch (Exception ex)
         {
            result.errorResult = true;
            result.errorMessage = $"An error occurred during import:\n{ex.Message}";
         }

         return result;
      }

      private static List<tVaultRec> ParseVaultRecords(string content)
      {
         var parsedDicts = ParseRelaxedJson(content);
         var list = new List<tVaultRec>();
         foreach (var dict in parsedDicts)
         {
            var rec = MapToVaultRec(dict);
            if (!string.IsNullOrWhiteSpace(rec.SITENAME))
            {
               list.Add(rec);
            }
         }
         return list;
      }

      private static tVaultRec MapToVaultRec(Dictionary<string, string> dict)
      {
         var rec = new tVaultRec();

         string GetVal(params string[] keys)
         {
            foreach (var k in keys)
            {
               if (dict.TryGetValue(k, out var v) && v != null)
                  return v;
            }
            return string.Empty;
         }

         rec.SITENAME = GetVal("SiteName", "SITENAME").Trim();
         rec.USERNAME = GetVal("Username", "USERNAME").TrimEnd('\r', '\n');
         rec.PASSWORD = GetVal("Password", "PASSWORD").TrimEnd('\r', '\n');
         rec.EMAIL = GetVal("Email", "EMAIL").TrimEnd('\r', '\n');
         rec.SITEURL = GetVal("URL", "SITEURL").TrimEnd('\r', '\n');
         rec.PASSHINT = GetVal("PasswordHint", "PASSHINT").TrimEnd('\r', '\n');
         rec.SITEDESC = GetVal("Description", "SITEDESC").Trim();
         rec.SECQUEST1 = GetVal("Question1", "SECQUEST1").TrimEnd('\r', '\n');
         rec.SECQUEST2 = GetVal("Question2", "SECQUEST2").TrimEnd('\r', '\n');
         rec.SECQUEST3 = GetVal("Question3", "SECQUEST3").TrimEnd('\r', '\n');
         rec.SECQUEST4 = GetVal("Question4", "SECQUEST4").TrimEnd('\r', '\n');

         string activeVal = GetVal("Active", "IsActive", "ISACTIVE");
         if (bool.TryParse(activeVal, out bool bVal))
         {
            rec.IsActive = bVal ? 1 : 0;
         }
         else if (int.TryParse(activeVal, out int iVal))
         {
            rec.IsActive = iVal;
         }
         else
         {
            rec.IsActive = 1;
         }

         return rec;
      }

      private static List<Dictionary<string, string>> ParseRelaxedJson(string text)
      {
         var records = new List<Dictionary<string, string>>();
         int i = 0;
         int len = text.Length;

         while (i < len)
         {
            // Find '{'
            while (i < len && text[i] != '{')
            {
               if (text[i] == '/' && i + 1 < len)
               {
                  if (text[i + 1] == '/')
                  {
                     i += 2;
                     while (i < len && text[i] != '\n' && text[i] != '\r') i++;
                     continue;
                  }
                  else if (text[i + 1] == '*')
                  {
                     i += 2;
                     while (i + 1 < len && !(text[i] == '*' && text[i + 1] == '/')) i++;
                     if (i + 1 < len) i += 2;
                     continue;
                  }
               }
               i++;
            }

            if (i >= len) break;
            i++; // skip '{'

            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            while (i < len)
            {
               // Skip whitespace, commas, and comments
               while (i < len)
               {
                  if (char.IsWhiteSpace(text[i]) || text[i] == ',')
                  {
                     i++;
                  }
                  else if (text[i] == '/' && i + 1 < len && text[i + 1] == '/')
                  {
                     i += 2;
                     while (i < len && text[i] != '\n' && text[i] != '\r') i++;
                  }
                  else if (text[i] == '/' && i + 1 < len && text[i + 1] == '*')
                  {
                     i += 2;
                     while (i + 1 < len && !(text[i] == '*' && text[i + 1] == '/')) i++;
                     if (i + 1 < len) i += 2;
                  }
                  else
                  {
                     break;
                  }
               }

               if (i >= len || text[i] == '}')
               {
                  if (i < len) i++;
                  break;
               }

               // Read key
               string key = "";
               if (text[i] == '"' || text[i] == '\'')
               {
                  char quote = text[i++];
                  int start = i;
                  while (i < len && text[i] != quote)
                  {
                     if (text[i] == '\\' && i + 1 < len) i += 2;
                     else i++;
                  }
                  key = text.Substring(start, i - start);
                  if (i < len) i++;
               }
               else
               {
                  int start = i;
                  while (i < len && (char.IsLetterOrDigit(text[i]) || text[i] == '_' || text[i] == '$')) i++;
                  key = text.Substring(start, i - start);
               }

               key = key.Trim();

               // Skip to ':'
               while (i < len && (char.IsWhiteSpace(text[i]) || text[i] == ':')) i++;

               // Read value
               string val = "";
               if (i < len && (text[i] == '"' || text[i] == '\''))
               {
                  char quote = text[i++];
                  var sb = new System.Text.StringBuilder();
                  while (i < len)
                  {
                     if (text[i] == quote)
                     {
                        if (quote == '\'' && i + 1 < len && text[i + 1] == '\'')
                        {
                           sb.Append('\'');
                           i += 2;
                           continue;
                        }
                        break;
                     }

                     if (text[i] == '\\' && i + 1 < len)
                     {
                        char next = text[i + 1];
                        if (next == quote || next == '\\' || next == '/')
                        {
                           sb.Append(next);
                           i += 2;
                           continue;
                        }
                        else if (next == 'n') { sb.Append('\n'); i += 2; continue; }
                        else if (next == 'r') { sb.Append('\r'); i += 2; continue; }
                        else if (next == 't') { sb.Append('\t'); i += 2; continue; }
                        else if (next == 'b') { sb.Append('\b'); i += 2; continue; }
                        else if (next == 'f') { sb.Append('\f'); i += 2; continue; }
                        else if (next == 'u' && i + 5 < len)
                        {
                           string hex = text.Substring(i + 2, 4);
                           if (int.TryParse(hex, System.Globalization.NumberStyles.HexNumber, null, out int codePoint))
                           {
                              sb.Append((char)codePoint);
                              i += 6;
                              continue;
                           }
                        }
                        sb.Append('\\');
                        i++;
                        continue;
                     }

                     sb.Append(text[i]);
                     i++;
                  }
                  val = sb.ToString();
                  if (i < len) i++;
               }
               else
               {
                  int start = i;
                  while (i < len && text[i] != ',' && text[i] != '}' && !char.IsWhiteSpace(text[i]))
                  {
                     i++;
                  }
                  val = text.Substring(start, i - start).Trim();
                  if (string.Equals(val, "null", StringComparison.OrdinalIgnoreCase))
                  {
                     val = "";
                  }
               }

               if (!string.IsNullOrEmpty(key))
               {
                  dict[key] = val;
               }

               // Skip whitespace, comma before next property or '}'
               while (i < len && (char.IsWhiteSpace(text[i]) || text[i] == ',')) i++;
               if (i < len && text[i] == '}')
               {
                  i++;
                  break;
               }
            }

            if (dict.Count > 0)
            {
               records.Add(dict);
            }
         }

         return records;
      }
   }


}

