using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Common.Logging
{
    public class SimpleLogger
    {
        private readonly Logger logger;

        public SimpleLogger() : this(Assembly.GetEntryAssembly().GetName().Name)
        {

        }

        public SimpleLogger(string logName)
        {
            logger = LogManager.GetLogger(logName);
            //logger.
        }
    }
}
