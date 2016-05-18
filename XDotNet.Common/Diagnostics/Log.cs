using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace XDotNet.Diagnostics
{
    /// <summary>
    /// Severity of log entries
    /// </summary>
    public enum LogLevel
    {
        None,
        Error,
        Warning,
        Info,
        Diagnostics,
        All
    }

    public static class Log
    {
        public static LogLevel Level { get; set; }
        public static List<ILogListener> Listeners { get; private set; }

        static Log()
        {
            Listeners = new List<ILogListener>();
            Level = LogLevel.All;
        }

        public static string FormatException(Exception ex)
        {
            return string.Format("Exception of type {0} occured: {1}\nStack trace: {2}", ex.GetType(), ex.Message, ex.StackTrace);
        }

        public static void Write(string message, LogLevel level = LogLevel.None)
        {
            if (level > Level)
                return;

            foreach (var listener in Listeners)
            {
                listener.Write(level, message);
            }
        }

        public static void Write(LogLevel level, string format, params object[] args)
        {
            Write(string.Format(format, args));
        }

        public static void Info(string message)
        {
            Write(message, LogLevel.Info);
        }

        public static void Info(string format, params object[] args)
        {
            Write(LogLevel.Info, format, args);
        }

        public static void Error(Exception ex)
        {
            foreach (var listener in Listeners)
            {
                listener.Write(ex);
            }
        }

        public static void Error(string message)
        {
            Write(message, LogLevel.Error);
        }

        public static void Error(string format, params object[] args)
        {
            Write(LogLevel.Error, format, args);
        }

        public static void Warning(string message)
        {
            Write(message, LogLevel.Warning);
        }

        public static void Warning(string format, params object[] args)
        {
            Write(LogLevel.Warning, format, args);
        }

        public static void Diagnostics(string message)
        {
            Write(message, LogLevel.Diagnostics);
        }

        public static void Diagnostics(string format, params object[] args)
        {
            Write(LogLevel.Diagnostics, format, args);
        }
    }
}
