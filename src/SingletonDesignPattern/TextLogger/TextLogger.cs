using System;
using System.IO;

namespace TextLogger
{
    public class Logger
    {
        private string LogFileDirectory = "";

        public Logger()
        {
            //in general this path will be obtained at run time from the application configuration file.
            //it is hardcoded here for simplicity
            LogFileDirectory = @"C:\ProgramData\StudentInfo\";
        }

        public void Log(string logMessage, LogLevel logLevel)
        {
            if (Directory.Exists(LogFileDirectory))
            {
                using (StreamWriter streamWriter = new StreamWriter(LogFileDirectory + "log.txt",true))
                {
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + logMessage);
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
