using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXPLORE
{
    public class PluginNotFoundException : Exception
    {
        public PluginNotFoundException() { }
        public PluginNotFoundException(string message) : base(message) { }
        public PluginNotFoundException(string message, Exception inner) : base(message, inner) { }

    }

    public class ConfigurationNotValidException : Exception
    {
        public ConfigurationNotValidException() { }
        public ConfigurationNotValidException(string message) : base(message) { }
        public ConfigurationNotValidException(string message, Exception inner) : base(message, inner) { }
    }

    public class ConfigurationNotFoundException : Exception
    {
        public ConfigurationNotFoundException() { }
        public ConfigurationNotFoundException(string message) : base(message) { }
        public ConfigurationNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
