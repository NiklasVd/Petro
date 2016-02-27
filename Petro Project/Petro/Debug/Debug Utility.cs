using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petro.Debug
{
    public struct LogMessage
    {
        public readonly DateTime timestamp;
        public readonly LogMessageImportance importance;
        public readonly string message;

        public LogMessage(LogMessageImportance importance, string message)
        {
            timestamp = DateTime.Now;
            this.importance = importance;
            this.message = message;
        }
    }

    public enum LogMessageImportance
    {
        Information,
        Warning,
        Error,
        Exception
    }

    public class TelemetryData
    {
    }
}
