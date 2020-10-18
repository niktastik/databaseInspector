using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32;

namespace DatabaseInspector.Utilities
{
    public static class WindowsSystemHelper
    {
        public static string GetMachineName()
        {
            return Environment.MachineName;
        }

        public static bool Is64bit()
        {
            return Environment.Is64BitOperatingSystem;
        }

        public static RegistryView GetRegistryView()
        {
            return Is64bit() ? RegistryView.Registry64 : RegistryView.Registry32;
        }
    }
}
