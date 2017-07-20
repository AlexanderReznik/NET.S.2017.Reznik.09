using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace BookLibrary
{
    public class NLogger:ILogger
    {
        private static readonly NLog.Logger logger = LogManager.GetCurrentClassLogger();
        public void Debug(string message)
        {
            logger.Debug(DateTime.Now);
            logger.Debug(message);
        }

        public void Info(string message)
        {
            logger.Info(DateTime.Now);
            logger.Info(message);
        }

        public void Warn(string message)
        {
            logger.Warn(DateTime.Now);
            logger.Warn(message);
        }

        public void Error(string message)
        {
            logger.Error(DateTime.Now);
            logger.Error(message);
        }

        public void Fatal(string message)
        {
            logger.Fatal(DateTime.Now);
            logger.Fatal(message);
        }
    }
}
