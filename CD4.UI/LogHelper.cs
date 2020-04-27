using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI
{
    public static class LogHelper
    {
        public static ILog GetLogger([CallerFilePath]string filepath = "")
        {
            return LogManager.GetLogger($"Filename: {(filepath?.Split('\\')).ToList().Last()}");
        }
    }
}
