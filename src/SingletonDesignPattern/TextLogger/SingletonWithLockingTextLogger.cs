using System.IO;
using System;

namespace SingletonWithLockingTextLogger
{
    public class Logger
    {
        //reference which points to singleton object.
        private static volatile Logger singleton;
        private string LogFileDirectory = "";
        //object used for creating locks for thread synchronization
        private static object syncRoot = new Object();

        //private constructor. Now nobody dares to create my instance.
        private Logger()
        {
            //in general this path will obtained at run time from the application configuration file.
            //it will not be a hardcoded path
            LogFileDirectory = @"C:\ProgramData\StudentInfo\";
        }

        public static Logger GetInstance()
        {
            lock (syncRoot)
            {
                //initialize singleton only once when it is found null for the first time.
                if (singleton == null)
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
