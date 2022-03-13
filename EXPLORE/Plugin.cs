using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EXPLORE
{
    public class Plugin
    {
        public Plugin(string pluginLocation)
        {
            if (!File.Exists(pluginLocation))
                throw new PluginNotFoundException();


            Assembly assemblyPlugin = Assembly.LoadFrom(pluginLocation);
            PluginFileLocation = pluginLocation;

            Type[] typeArr = assemblyPlugin.GetTypes();
            List<MethodInfo> allMethods = GetMethods(typeArr);
            for (int i = 0; i < allMethods.Count; i++)
            {
                MethodInfo method = allMethods[i];
                switch (method.Name)
                {
                    case "PluginConfig":
                        PluginConfig = (Configuration)method.Invoke(null, null);
                        break;
                    case "PluginName":
                        PluginName = (string)method.Invoke(null, null);
                        break;
                    case "PluginVersion":
                        Version = (Version)method.Invoke(null, null);
                        break;
                    case "PluginDescription":
                        PluginDescription = (string)method.Invoke(null, null);
                        break;
                }
            }
        }

        public void LoadPluginEvent()
        {
            Assembly assembly = Assembly.LoadFile(PluginFileLocation);
            Type pluginClass = assembly.GetType(PluginClass.Name);
            pluginClass.GetMethod("PluginLoadEvent").Invoke(null, null);
        }

        public object ExecutePluginEvent(string input)
        {
            Assembly assembly = Assembly.LoadFile(PluginFileLocation);
            Type[] typeArr = assembly.GetTypes();
            List<MethodInfo> allMethods = GetMethods(typeArr);
            for (int i = 0; i < allMethods.Count; i++)
            {
                MethodInfo method = allMethods[i];
                if (method.Name == "PluginExecuteEvent")
                    return method.Invoke(null, new object[] { input });
            }
            return "Plugin does not return any output!";
            
        }

        private List<MethodInfo> GetMethods(Type[] types)
        {
            List<MethodInfo> allMethods = new List<MethodInfo>();
            for (int a = 0; a < types.Length; a++)
            {
                Type type = types[a];
                MethodInfo[] methods = type.GetMethods();
                for (int b = 0; b < methods.Length; b++)
                    allMethods.Add(methods[b]);
            }

            return allMethods;
        }

        private string PluginFileLocation { get; set; }
        public string PluginName { get; set; }
        public string PluginDescription { get; set; }
        public Version Version { get; set; }
        public Configuration PluginConfig { get; set; }
        private Type PluginClass { get; set; }

        /* NOTICE:
         * EXPLORE has shown to be 5.3x faster at executing methods than Toaster
         * DO NOT BOG DOWN THE FRAMEWORK
         * USE FOR LOOPS, NOT FOREACH
         */
    }
}
