using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebDriversGenerator
{
    public class DriverBinary
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Platform { get; set; }
        public string Link { get; set; }

        public static DriverBinary FromFile(
            string name,
            string version, 
            string platform,
            FileInfo file)
        {
            return new DriverBinary() 
            {
                Name = name,
                Version = version,
                Platform = platform,
                Link = $"https://raw.githubusercontent.com/feel-the-dz3n/WebDrivers/master/{name}/{version}/{platform}/{file.Name}"
            };
        }
    }
}
