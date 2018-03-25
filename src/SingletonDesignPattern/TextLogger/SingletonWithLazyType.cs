using System.IO;
using System;

namespace SingletonWithLazyType
{
    public sealed class Logger
    {
        //CLR guarantees that this line of code runs in a thread-safe manner
        private static readonly Lazy<Logger>  singleton = new Lazy<Logger>(() => new Logger()); 
        private string LogFileDirectory = "";

        //private constructor. Now nobody dares to create my instance.
        private Logger()
        {
            //in general this path will obtained at run time from the application configuration file.
            //it will not be a hardcoded path
            LogFileDirectory = @"C:\ProgramData\StudentInfo\";
        }

        public static Logger GetInstance()
        {
            //simply return the already initialized instance
            return singleton.Value;
        }

        public void Log(string logMessage, LogLevel logLevel)
        {
            if (Directory.Exists(LogFileDirectory))
            {
                using (StreamWriter streamWriter = new StreamWriter(LogFileDirectory + "log.txt",true))
                {
                    streamWriter.WriteLine(DateTime.Now.ToString() + " [" + logLevel.ToString() + "]" + " - " + logMessage);
                }
            }
        }

    }

    public enum LogLevel
    {
        Trace,
        Information,
        Warning,
        Error,
        Critical,
        Fatal
    }
}

