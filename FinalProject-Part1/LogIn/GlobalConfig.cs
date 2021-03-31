using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace FinalProject_Part1
{
    class GlobalConfig
    {
        private static ConfigJson configJson;
        static GlobalConfig()
        {
            string configFile = File.ReadAllText("C:\\Users\\Michael Bakshi\\source\\repos\\FinalProject-Part1\\config.json");
            configJson = JsonConvert.DeserializeObject<ConfigJson>(configFile);
        }

        public static string ConnectionString { get {return configJson.ConnectionString; } }
        public static string TestConnectionString { get { return configJson.TestConnectionString; } }
    }

    class ConfigJson
    {
        public string ConnectionString { get; set; }
        public string TestConnectionString { get; set; }
    }
}
