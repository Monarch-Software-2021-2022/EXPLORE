using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXPLORE;

namespace SunriseEXPLORING
{
    public class PluginInfo
    {
        public static Configuration PluginConfig()
        {
            return new Configuration
            {
                Enabled = true,
                Debug = false,
                SourceCodeLink = "github.com/KuebV/SunriseEncryptionPlugin",
                Authors = new string[] { "KuebV " }
            };
        }

        public static string PluginName() => "SunriseEXPLORING";
        public static string PluginDescription() => "EXPLORE Sunrise Encryption Framework Test";
        public static Version PluginVersion() => new Version(1, 0, 0);

        public static object PluginExecuteEvent(object unencryptedMessage)
        {
            List<char> alphabet = Utilities.AlphabetList;
            string x = "";
            for(int i = 0; i < unencryptedMessage.ToString().Length; i++)
            {
                char letter = unencryptedMessage.ToString()[i];
                if (alphabet.Contains(letter))
                    x += $"{alphabet.IndexOf(letter)} ";
                else
                    x += "0 ";

            }

            return x;
        }
    }
}
