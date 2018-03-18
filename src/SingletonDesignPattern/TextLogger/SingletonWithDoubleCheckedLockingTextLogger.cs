using System;
using System.IO;

namespace SingletonWithDoubleCheckedLockingTextLogger
{
    public class Logger
    {
        //reference which points to singleton object.
        private static volatile Logger singleton;
        private string LogFileDirectory = "";
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
            //once the singleton instance is instantiated all calls will jump to return
            //statement after this line instead of going inside the if statement and acquiring the lock
            if (singleton == null)
            {
                //if singleton isn’t initialized so initialization piece code
                //is thread synchronized so that only one instance gets created.
                lock (syncRoot)
                {
                    //initialize singleton only once when it is found null for the first time.
                    if (singleton == null)
                        singleton = new Logger();
                }
            }
            return singleton;
        }

        public void Log(string logMessage, LogLevel logLevel)
        {
            if (Directory.Exists(LogFileDirectory))
            {
                using (StreamWriter writetext = new StreamWriter(LogFileDirectory + "log.txt",true))
                {
                    writetext.WriteLine(DateTime.Now.ToString() + " - " + logMessage);
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
