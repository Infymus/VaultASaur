using VaultASaur3.Enums;
using VaultASaur3.ErrorHandling;
using VaultASaur3.Objects;
using VaultASaur3.ToolsBox;
using System.Data.SQLite;
using System.Net.Http.Headers;

namespace VaultASaur3.DataBase
{

    public static class dbPreference
    {
        public static tPreferenceRec InitializeRecord()
        {
            return new tPreferenceRec()
            {
                ID = "",
                PNAME = "",
                ASSTR = "",
                ASBOOL = 0,
                ASGUID = "",
                ASMEMO = "",
                ASINT = 0,
                ASCURR = 0.00,
            };
        }

        public static tErrorResult Add(tPreferenceRec inPrefRec)
        {
            tErrorResult t;

            string sqlStr = $@"INSERT INTO {MasterData.GetTableName_Preference}  (PNAME, ASSTR, ASBOOL, ASGUID, ASMEMO, ASINT, ASCURR) 
                VALUES (@PNAME, @ASSTR, @ASBOOL, @ASGUID, @ASMEMO, @ASINT, @ASCURR)";

            var parameters = new Dictionary<string, object>
            {
                { "@PNAME", inPrefRec.PNAME},
                { "@ASSTR", inPrefRec.ASSTR },
                { "@ASBOOL", inPrefRec.ASBOOL },
                { "@ASGUID", inPrefRec.ASGUID },
                { "@ASMEMO", inPrefRec.ASMEMO },
                { "@ASINT", inPrefRec.ASINT },
                { "@ASCURR", inPrefRec.ASCURR}
            };

            t = MasterData.ExecuteSQL(sqlStr, parameters);
            return t;
        }

        public static tPreferenceRec GetPrefByPrefName(tPrefConstants inPrefName)
        {
            tPreferenceRec t = InitializeRecord();
            tErrorResult e;
            string sqlStr = $@"SELECT * FROM {MasterData.GetTableName_Preference} WHERE PNAME = @PNAME";
            var parameters = new Dictionary<string, object>
                {
                    { "@PNAME", ToolBox.GetEnumName(inPrefName) }
                };
            using (SQLiteDataReader reader = MasterData.ExecuteQuery(sqlStr, parameters, out e))
            {
                if (!e.errorResult)
                {
                    if (reader.Read())
                    {
                        t.ID = reader["ID"].ToString();
                        t.ASSTR = reader["ASSTR"].ToString();
                        t.ASBOOL = Convert.ToInt32(reader["ASBOOL"]);
                        t.ASGUID = reader["ASGUID"].ToString();
                        t.ASMEMO = reader["ASMEMO"].ToString();
                        t.ASINT = Convert.ToInt32(reader["ASINT"]);
                        t.ASCURR = Convert.ToDouble(reader["ASCURR"]);
                    }
                }
            }
            return t;
        }

        public static bool PreferenceExists(tPrefConstants inPrefName)
        {
            string sqlStr = $@"SELECT COUNT(*) FROM {MasterData.GetTableName_Preference} WHERE PNAME = @PNAME";
            var parameters = new Dictionary<string, object>
                {
                    { "@PNAME", ToolBox.GetEnumName(inPrefName) }
                };
            object result = MasterData.ExecuteScalar(sqlStr, parameters);
            if (result != null && int.TryParse(result.ToString(), out int count))
            {
                return count > 0;
            }
            return false;
        }

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//

        public static bool GetBool(tPrefConstants inPrefName)
        {
            tPreferenceRec t = GetPrefByPrefName(inPrefName);
            return Convert.ToBoolean(t.ASBOOL);
        }

        public static int GetInt(tPrefConstants inPrefName)
        {
            tPreferenceRec t = GetPrefByPrefName(inPrefName);
            return t.ASINT;
        }

        public static string GetMemo(tPrefConstants inPrefName)
        {
            tPreferenceRec t = GetPrefByPrefName(inPrefName);
            return t.ASMEMO;
        }

        public static string GetGuid(tPrefConstants inPrefName)
        {
            tPreferenceRec t = GetPrefByPrefName(inPrefName);
            return t.ASGUID;
        }

        public static string GetString(tPrefConstants inPrefName)
        {
            tPreferenceRec t = GetPrefByPrefName(inPrefName);
            return t.ASSTR;
        }

        public static void SetBool(tPrefConstants inPrefName, bool inValue)
        {
            if (PreferenceExists(inPrefName))
            {
                string sqlStr = $@"UPDATE {MasterData.GetTableName_Preference} SET ASGUID = @ASBOOL WHERE PNAME = @PNAME";
                var parameters = new Dictionary<string, object>
                {
                    { "@PNAME", ToolBox.GetEnumName(inPrefName) },
                    { "@ASBOOL", inValue}
                };
                MasterData.ExecuteSQL(sqlStr, parameters);
            }
            else
            {
                tPreferenceRec t = InitializeRecord();
                t.PNAME = ToolBox.GetEnumName(inPrefName);
                t.ASBOOL = inValue ? 1 : 0;
                Add(t);
            }
        }

        public static void SetInt(tPrefConstants inPrefName, int inValue)
        {
            if (PreferenceExists(inPrefName))
            {
                string sqlStr = $@"UPDATE {MasterData.GetTableName_Preference} SET ASGUID = @ASINT WHERE PNAME = @PNAME";
                var parameters = new Dictionary<string, object>
                {
                    { "@PNAME", ToolBox.GetEnumName(inPrefName) },
                    { "@ASINT", inValue}
                };
                MasterData.ExecuteSQL(sqlStr, parameters);
            }
            else
            {
                tPreferenceRec t = InitializeRecord();
                t.PNAME = ToolBox.GetEnumName(inPrefName);
                t.ASINT = inValue;
                Add(t);
            }
        }

        public static void SetGuid(tPrefConstants inPrefName, string inValue)
        {
            if (PreferenceExists(inPrefName))
            {
                string sqlStr = $@"UPDATE {MasterData.GetTableName_Preference} SET ASGUID = @ASGUID WHERE PNAME = @PNAME";
                var parameters = new Dictionary<string, object>
                {
                    { "@PNAME", ToolBox.GetEnumName(inPrefName) },
                    { "@ASGUID", inValue}
                };
                MasterData.ExecuteSQL(sqlStr, parameters);
            }
            else
            {
                tPreferenceRec t = InitializeRecord();
                t.PNAME = ToolBox.GetEnumName(inPrefName);
                t.ASGUID = inValue;
                Add(t);
            }
        }

        public static void SetString(tPrefConstants inPrefName, string inValue)
        {
            if (PreferenceExists(inPrefName))
            {
                string sqlStr = $@"UPDATE {MasterData.GetTableName_Preference} SET ASSTR = @ASSTR WHERE PNAME = @PNAME";
                var parameters = new Dictionary<string, object>
                {
                    { "@PNAME", ToolBox.GetEnumName(inPrefName) },
                    { "@ASSTR", inValue}
                };
                MasterData.ExecuteSQL(sqlStr, parameters);
            }
            else
            {
                tPreferenceRec t = InitializeRecord();
                t.PNAME = ToolBox.GetEnumName(inPrefName);
                t.ASSTR = inValue;
                Add(t);
            }
        }

        public static void SetSMemo(tPrefConstants inPrefName, string inValue)
        {
            if (PreferenceExists(inPrefName))
            {
                string sqlStr = $@"UPDATE {MasterData.GetTableName_Preference} SET ASMEMO = @ASMEMO WHERE PNAME = @PNAME";
                var parameters = new Dictionary<string, object>
                {
                    { "@PNAME", ToolBox.GetEnumName(inPrefName) },
                    { "@ASMEMO", inValue}
                };
                MasterData.ExecuteSQL(sqlStr, parameters);
            }
            else
            {
                tPreferenceRec t = InitializeRecord();
                t.PNAME = ToolBox.GetEnumName(inPrefName);
                t.ASMEMO = inValue;
                Add(t);
            }
        }




    }


}
