/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/

using System.Data.SQLite;
using VaultASaur3.Enums;
using VaultASaur3.ErrorHandling;
using VaultASaur3.Extensions;

namespace VaultASaur3.DataBase
{

   /// <summary>
   /// This is a collection of database calls for sqLite, also holding the name of the database
   /// plus the tables. 
   /// </summary>
    public static class MasterData
    {
        // Enums
        public enum dbState
        {
            dsBrowse,
            dsInsert,
            dsEdit,
            dsInitialize
        }

        // DataBase Name
        private static string SQLiteDBName = "vaultasaur.db";

        // Tables
        private static string tableMain = "MAIN";
        private static string tablePreference = "PREF";
        private static string tableVault = "VAULT";

        public static string ConnectionString()
        {
            return $"Data Source={SQLiteDBName};Version=3;";
        }

        public static string GetTableName_Preference
        {
            get { return tablePreference; }
        }

        public static string GetTableName_Main
        {
            get { return tableMain; }
        }

        public static string GetTableName_Vault
        {
            get { return tableVault; }
        }

        // Compares the DB Version with the current version
        public static bool CompareVersion(int inDbVersion)
        {
            if (GetDataBaseVersion() < inDbVersion)
                return true;
            else
                return false;
        }

        public static string getDBNameByDBType(dbTypes inDbType)
        {
            switch (inDbType)
            {
                case dbTypes.Vault:
                    return tableVault;
                default:
                    return "";
            }
        }

        public static int GetDataBaseVersion()
        {
            int dbVersion = 0; // Default value if not found
            tErrorResult errorResult;
            string sqlStr = $"SELECT DBID FROM {GetTableName_Main} LIMIT 1"; // Retrieve the only record in the table
            using (SQLiteDataReader reader = ExecuteQuery(sqlStr, null, out errorResult))
                if (!errorResult.errorResult && reader != null && reader.Read())
                    dbVersion = Convert.ToInt32(reader["DBID"]);
            return dbVersion;
        }

        public static tErrorResult SetDBVersion(int nextDBVersion)
        {
            tErrorResult t;
            string sqlStr = $"UPDATE {GetTableName_Main} SET DBID = @DBID";
            var parameters = new Dictionary<string, object>
                {
                    { "@DBID", nextDBVersion }
                };
            t = MasterData.ExecuteSQL(sqlStr, parameters);
            return t;
        }

        public static tErrorResult StartDBVersion()
        {
            tErrorResult t;
            string sqlStr = $@"INSERT INTO {MasterData.GetTableName_Main} (DBID) VALUES (@DBID)";

            var parameters = new Dictionary<string, object>
                {
                    { "@DBID", 0 }
                };
            t = MasterData.ExecuteSQL(sqlStr, parameters);
            return t;
        }

        public static bool TableExists(string tableName)
        {
            tErrorResult errorResult;
            string sqlStr = "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name=@TableName";
            var parameters = new Dictionary<string, object>
                {
                    { "@TableName", tableName }
                };
            using (SQLiteDataReader reader = ExecuteQuery(sqlStr, parameters, out errorResult))
            {
                if (!errorResult.errorResult && reader != null && reader.Read())
                {
                    return Convert.ToInt32(reader[0]) > 0;
                }
            }
            return false;
        }

        public static object ExecuteScalar(string sqlStr, Dictionary<string, object> parameters)
        {
            string connectionString = MasterData.ConnectionString();
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sqlStr, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static SQLiteDataReader ExecuteQuery(string sqlStr, Dictionary<string, object> parameters = null)
        {
            string connectionString = MasterData.ConnectionString();
            var conn = new SQLiteConnection(connectionString);

            try
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sqlStr, conn))
                {
                    // Add parameters if provided
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    // Return the reader (command.ExecuteReader must be called before returning)
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
            }
            catch (Exception ex)
            {
                conn.Close(); // Ensure the connection is closed in case of an error
                throw new Exception("Database query error: " + ex.Message);
            }
        }

        public static tErrorResult ExecuteNonQuery(string sqlStr, Dictionary<string, object> parameters, out tErrorResult errorResult)
        {
            errorResult = new tErrorResult(); // Initialize error result
            var conn = new SQLiteConnection(ConnectionString());

            try
            {
                conn.Open();
                var cmd = new SQLiteCommand(sqlStr, conn);

                // Add parameters if provided
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                // Execute and return the reader
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Handle error and return null
                errorResult.errorResult = true;
                errorResult.errorMessage = ex.Message;
                conn.Close(); // Ensure connection is closed if an error occurs
                return null;
            }
            return errorResult;
        }

        public static SQLiteDataReader ExecuteQuery(string sqlStr, Dictionary<string, object> parameters, out tErrorResult errorResult)
        {
            errorResult = new tErrorResult(); // Initialize error result
            string connectionString = ConnectionString();
            var conn = new SQLiteConnection(connectionString);

            try
            {
                conn.Open();
                var cmd = new SQLiteCommand(sqlStr, conn);

                // Add parameters if provided
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                // Execute and return the reader
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                // Handle error and return null
                errorResult.errorResult = true;
                errorResult.errorMessage = ex.Message;
                conn.Close(); // Ensure connection is closed if an error occurs
                return null;
            }
        }

        /// <summary>
        /// Execute an SQL query without any parameters.
        /// Use for DELETE, 
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public static tErrorResult ExecuteSQL(string sqlStr, Dictionary<string, object> parameters)
        {
            tErrorResult errorResult = new tErrorResult(); // Initialize error result
            string connectionString = MasterData.ConnectionString();
            var conn = new SQLiteConnection(connectionString);
            try
            {
                conn.Open();
                var cmd = new SQLiteCommand(sqlStr, conn);
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }
                cmd.ExecuteNonQuery();


                using var lastIdCmd = new SQLiteCommand("SELECT last_insert_rowid();", conn);
                long lastId = (long)lastIdCmd.ExecuteScalar();
                errorResult.AsLong = lastId;
            }
            catch (Exception ex)
            {
                errorResult.errorResult = true;
                errorResult.errorMessage = ex.Message;
                conn.Close();
                return errorResult;
            }

            return errorResult;
        }

        public static int Count(dbTypes inDbType)
        {
            int t = 0;
            string connectionString = MasterData.ConnectionString();
            string sqlStr = $@"SELECT COUNT(*) FROM {getDBNameByDBType(inDbType)}";
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (var command = new SQLiteCommand(sqlStr, conn))
                {
                    t = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return t;
        }

        public static string NewDBGuid()
        {
            Guid guid = Guid.NewGuid();
            string tempStr = guid.ToString();

            // Remove the enclosing curly braces if they exist
            tempStr = tempStr.Trim('{', '}');

            return tempStr;
        }

        public static tErrorResult Delete(dbTypes inDbType, string inID)
        {
            tErrorResult errorResult = new tErrorResult();
            string dbName = "";
            string sqlStr = $@"DELETE FROM {getDBNameByDBType(inDbType)} WHERE ID = @ID";

            using var conn = new SQLiteConnection(MasterData.ConnectionString());
            try
            {
                conn.Open();
                var cmd = new SQLiteCommand(sqlStr, conn);
                if (long.TryParse(inID, out long idToDelete))
                {
                    cmd.Parameters.AddWithValue("@ID", idToDelete);
                    errorResult.AsInteger = cmd.ExecuteNonQuery();
                }
                else
                {
                    errorResult.errorResult = true;
                    errorResult.errorMessage = "Invalid ID format. Expected a numeric value.";
                    return errorResult;
                }
            }
            catch (Exception ex)
            {
                errorResult.errorResult = true;
                errorResult.errorMessage = ex.Message;
                conn.Close();
                return null;
            }

            return errorResult;
        }

        public static tErrorResult DeleteAll(dbTypes inDbType)
        {
            tErrorResult errorResult = new tErrorResult();

            string sqlStr = $@"DELETE FROM {getDBNameByDBType(inDbType)}";

            using var conn = new SQLiteConnection(MasterData.ConnectionString());

            try
            {
                conn.Open();
                var cmd = new SQLiteCommand(sqlStr, conn);
                errorResult.AsInteger = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errorResult.errorResult = true;
                errorResult.errorMessage = ex.Message;
                conn.Close();
                return null;
            }

            return errorResult;
        }

        public static void UpdateGridCount(ref Label inLabel, ref tDataGridView inGrid)
        {
            if (inGrid.Count == 0)
            {
                inLabel.Text = "0 Rows";
            }
            else
            {
                inLabel.Text = $"{inGrid.RowNum.ToString()} of {inGrid.Count}";
            }
        }


    }
}
