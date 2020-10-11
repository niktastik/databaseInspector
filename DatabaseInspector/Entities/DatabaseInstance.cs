using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseInspector
{
    class DatabaseInstance
    {
        public string ServerName { get; set; }
        public string InstanceName { get; set; }
        public string IsClustered { get; set; }
        public string Version { get; set; }
    }
}
