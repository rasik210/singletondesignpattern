using System;
using System.IO;

namespace StaticClassTextLogger
{
    public static class Logger
    {
        private static string logFileDirectory = @"C:\ProgramData\StudentInfo\";
        private static StreamWriter streamWriter = null;
        //static constructor
        static Logger()
        {
            //initialize streamWriter instance once for the life time of static class
            if (Directory.Exists(logFileDirectory))
            {
                //we can't use using keyword anymore as it will dispose the streamWriter object at
                //the end of using block
                //using (streamWriter = new StreamWriter(logFileDirectory + "log.txt"))
                //{
                //    streamWriter.WriteLine(DateTime.Now.ToString() + " [" + logLevel.ToString() + "]" + " - " + logMessage);
                //}

                streamWriter = new StreamWriter(logFileDirectory + "log.txt");
            }

        }

        public static void Log(string logMessage, LogLevel logLevel)
        {
            //use the same instance everytime Log method is called.
            streamWriter.WriteLine(DateTime.Now.ToString() + " [" + logLevel.ToString() + "]" + " - " + logMessage);
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
