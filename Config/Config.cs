/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/


using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text.Json.Nodes;
using VaultASaur3.Globals;

namespace VaultASaur3.Config
{
   /// <summary>
   /// This is a wrapper class so that you can easily read and write to a configuration file based on a setting name.
   /// </summary>
    public static class AppConfig
    {
        private static string AppConfigReadConfig()
        {
            string appConfigPath = Path.Combine(Constants.appConfigDir, Constants.appConfigFile);
            if (!File.Exists(appConfigPath))
            {
                return "{}";
            }

            return File.ReadAllText(appConfigPath);
        }

        public static string ReadString(string inSetting, string inDefault)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Constants.appConfigDir)
                .AddJsonFile(Constants.appConfigFile, optional: true, reloadOnChange: true)
                .Build();

            string val = config[$"{Constants.AppConfigHeader}:{inSetting}"] ?? string.Empty;
            return string.IsNullOrWhiteSpace(val) ? inDefault : val;
        }

        public static int ReadInt(string inSetting, int inDefault)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Constants.appConfigDir)
                .AddJsonFile(Constants.appConfigFile, optional: true, reloadOnChange: true)
                .Build();

            string val = config[$"{Constants.AppConfigHeader}:{inSetting}"] ?? string.Empty;
            return int.TryParse(val, out int result) ? result : inDefault;
        }

        public static void WriteValue(string inSetting, string inValue)
        {
            string appConfigSettings = AppConfigReadConfig();
            JsonNode? jsonDocument = JsonNode.Parse(appConfigSettings);
            if (jsonDocument is not JsonObject jsonObject)
            {
                jsonObject = new JsonObject();
            }

            JsonNode? sectionNode = jsonObject[Constants.AppConfigHeader];
            if (sectionNode is not JsonObject section)
            {
                section = new JsonObject();
                jsonObject[Constants.AppConfigHeader] = section;
            }

            section[inSetting] = inValue;
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(Path.Combine(Constants.appConfigDir, Constants.appConfigFile), jsonObject.ToJsonString(options));
        }

    }

}

