using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text.Json.Nodes;
using VaultASaur3.Globals;

namespace VaultASaur3.Config
{
    public static class AppConfig
    {
        // Private Config Settings

        private static string AppConfigReadConfig()
        {
            return File.ReadAllText($@"{Constants.appConfigDir}\{Constants.appConfigFile}");
        }

        // Read Methods

        /*
         Function INIReadBoolean( INIKey, INIItem : String; DefValue : Boolean) : Boolean;
         Function INIReadFloat( INIKey, INIItem : String; DefValue : Double) : Double;
        */
        public static string ReadString(string inSetting, string inDefault)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Constants.appConfigDir)
                .AddJsonFile(Constants.appConfigFile, optional: false, reloadOnChange: true)
                .Build();
            string val = config[$"{Constants.AppConfigHeader}:{inSetting}"];
            if ( val != "")
                return val;
            return inDefault;
        }

        public static int ReadInt(string inSetting, int inDefault)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Constants.appConfigDir)
                .AddJsonFile(Constants.appConfigFile, optional: false, reloadOnChange: true)
                .Build();
            string val = config[$"{Constants.AppConfigHeader}:{inSetting}"];
            if (int.TryParse(val, out int result))
            {
                return result;
            }
            return inDefault;
        }

        // Write Methods

        /*Procedure INIWriteString( INIKey, INIItem : String; INIValue : String);
Procedure INIWriteInteger( INIKey, INIItem : String; INIValue : Integer);
Procedure INIWriteBoolean( INIKey, INIItem : String; INIValue : Boolean);
Procedure INIWriteFloat( INIKey, INIItem : String; INIValue : Double);
        */

        public static void WriteValue(string inSetting, string inValue)
        {
            string appConfigSettings = AppConfigReadConfig();
            var jsonDocument = JsonNode.Parse(appConfigSettings);
            jsonDocument[$"{Constants.AppConfigHeader}"][$"{inSetting}"] = inValue;
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText($@"{Constants.appConfigDir}\{Constants.appConfigFile}", jsonDocument.ToJsonString(options));
        }

    }

}

