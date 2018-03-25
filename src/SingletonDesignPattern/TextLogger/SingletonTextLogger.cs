using System;
using System.IO;

namespace SingletonTextLogger
{
    public class Logger
    {
        //reference which points to singleton object.
        private static Logger singleton;
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
            //initialize singleton only once when it is found null for the first time.
            if (singleton == null)
            {
                singleton = new Logger();
            }

            return singleton;
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
