using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXPLORE
{
    public class FSLObject
    {
        public Configuration Configuration { get; set; }
        public string PluginName { get; set; }
        public string PluginDescription { get; set; }
        public Version Version { get; set; }
        public string Response { get; set; }

    }
}
