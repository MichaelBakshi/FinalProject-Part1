using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FinalProject_Part1.LogIn
{
    public class TestingGlobalConfig
    {
        private static ConfigJson configJson;
        static TestingGlobalConfig()
        {
            string configFile = File.ReadAllText("C:\\Users\\Michael Bakshi\\source\\repos\\FinalProject-Part1\\config.json");
            configJson = JsonConvert.DeserializeObject<ConfigJson>(configFile);
        }

        public static string TestConnectionString { get { return configJson.TestConnectionString; } }
    }

    class ConfigJson
    {
        public string TestConnectionString { get; set; }
    }
}
