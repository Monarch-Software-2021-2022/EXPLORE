using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXPLORE
{
    public class FSL
    {
        public FSLObject ExecuteFile(string fileName)
        {
            FSLObject obj = new FSLObject();
            Configuration config = new Configuration();
            string[] fileLines = File.ReadAllLines(fileName);
            for(int i = 0; i < fileLines.Length; i++)
            {
                string[] lineArguments = fileLines[i].Split(' ');
                string lineStart = lineArguments[0];
                if (lineStart.StartsWith("#"))
                {
                    string configArgument = lineArguments[1];
                    switch (configArgument.ToLower())
                    {
                        case "name":
                            obj.PluginName = lineArguments[2];
                            break;
                        case "version":
                            obj.Version = Version.Parse(lineArguments[2]);
                            break;
                        case "description":
                            obj.PluginDescription = string.Join(" ", lineArguments.Skip(2).ToArray());
                            break;
                        case "authors":
                            config.Authors = new string[] { lineArguments[2] };
                            break;
                        case "link":
                            config.SourceCodeLink = lineArguments[2];
                            break;
                        case "debug":
                            bool debug;
                            if (bool.TryParse(lineArguments[2], out debug))
                                config.Debug = debug;
                            else
                                config.Debug = false;
                            break;
                        case "enabled":
                            bool enabled;
                            if (bool.TryParse(lineArguments[2], out enabled))
                                config.Enabled = enabled;
                            else
                                config.Enabled = false;
                            break;
                    }
                }
            }
            obj.Configuration = config;
            return obj;
            
        }
    }
}
