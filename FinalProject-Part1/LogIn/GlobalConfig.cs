using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace FinalProject_Part1
{
    public static class GlobalConfig
    {
        private static string configJsonPath = "C:\\Users\\Michael Bakshi\\source\\repos\\FinalProject-Part1\\config.json";
        private static string testConfigJsonPath = "C:\\Users\\Michael Bakshi\\source\\repos\\FinalProject-Part1\\testing_config.json";
        private static ConfigJson configJson;
        public static bool isConfigured = false;

        public static void GetConfiguration(bool testMode)
        {
            if (isConfigured == true)
            {
                return;
            }

            if (testMode)
            {
                string configFile = File.ReadAllText(testConfigJsonPath);
                configJson = JsonConvert.DeserializeObject<ConfigJson>(configFile);
            }
            else
            {
                string configFile = File.ReadAllText(configJsonPath);
                configJson = JsonConvert.DeserializeObject<ConfigJson>(configFile);
            }
            isConfigured = true;
        }

        public static string GetConnectionString()
        {
            if (!isConfigured)
            {
                throw new Exception("Global configuration is empty");
            }
            else
            {
                return configJson.ConnectionString;
            }
        }
    }

    class ConfigJson
    {
        public string ConnectionString { get; set; }
    }
}
