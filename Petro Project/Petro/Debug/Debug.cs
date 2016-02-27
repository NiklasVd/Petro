using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petro.Debug
{
    public static class Debug
    {
        private const int maxLogMessagesCount = 8000;

        private static readonly List<LogMessage> logMessages;

        private static string defaultLogStoragePath = "debug.log";
        public static string DefaultLogStoragePath
        {
            get { return defaultLogStoragePath; }
            set { defaultLogStoragePath = value; }
        }

        private static bool activeLogging, activeTelemetry;
        public static bool ActiveLogging
        {
            get { return activeLogging; }
            set { activeLogging = value; }
        }
        public static bool ActiveTelemetry
        {
            get { return activeTelemetry; }
            set { activeTelemetry = value; }
        }

        static Debug()
        {
            logMessages = new List<LogMessage>();
        }

        public static void LogInformation(string message)
        {
            Log(LogMessageImportance.Information, message);
        }
        public static void LogWarning(string message)
        {
            Log(LogMessageImportance.Warning, message);
        }
        public static void LogError(string message)
        {
            Log(LogMessageImportance.Error, message);
        }
        public static void LogException(Exception ex)
        {
            Log(LogMessageImportance.Exception, ex.Message);
        }

        public static void StoreLogMessages(string path)
        {
            // It does not matter if "activeLogging" is true or false because there could be messages logged before the boolean has been set to false
            // TODO: Store log messages
        }
        public static void StoreLogMessages()
        {
            StoreLogMessages(defaultLogStoragePath);
        }

        public static void SendTelemetryData()
        {
            if (activeTelemetry)
            {
                // TODO: Generate and send telemetry data
            }
        }

        private static void Log(LogMessageImportance importance, string message)
        {
            logMessages.Add(new LogMessage(importance, message));

            if (logMessages.Count > maxLogMessagesCount)
            {
                StoreLogMessages(defaultLogStoragePath);
                logMessages.Clear();
            }
        }
    }
}
