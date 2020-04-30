using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebDriversGenerator
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: WebDriversGenerator [directory]");
                return 1;
            }

            var drivers = new List<DriverBinary>();
            var rootDir = new DirectoryInfo(args[0]);

            foreach (var driverDir in rootDir.EnumerateDirectories())
            {
                if (driverDir.Name.StartsWith('.')) continue; // ignore .git
                foreach (var versionDir in driverDir.EnumerateDirectories())
                {
                    foreach (var platformDir in versionDir.EnumerateDirectories())
                    {
                        var file = platformDir.EnumerateFiles().First();
                        drivers.Add(DriverBinary.FromFile(driverDir.Name, versionDir.Name, platformDir.Name, file));
                    }
                }
            }

            var json = JsonSerializer.Serialize(drivers);
            Console.WriteLine(json);

            return 0;
        }
    }
}
