using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace API_TUI.Tools.Helper
{
    public class HelperDebug
    {
        public static void Write(MethodBase m, string path)
        {
            Debug.WriteLine(m.ReflectedType.Name + "." + m.Name + " " +
                            path);
        }
    }
}
