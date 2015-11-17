using System;
using System.IO;

namespace TestDelegate
{
    public class MyClass
    {
        public delegate void LogHandler(string message);

        private static string _log;

        public static void Info(string log)
        {
            _log = log;
        }

        public void Process(LogHandler logHandler)
        {
            if (logHandler != null)
            {
                logHandler(_log);
            }
            //if (logHandler != null)
            //{
            //    logHandler(_log);
            //}
        }
    }

    public class FileLogger
    {
        private FileStream fileStream;
        private StreamWriter streamWriter;
        private string _log;

        public FileLogger(string filename)
        {
            fileStream = new FileStream(filename, FileMode.Create);
            streamWriter = new StreamWriter(fileStream);
        }

        //delegate
        public void Logger(string s)
        {
            streamWriter.WriteLine(s);
        }

        public void Close()
        {
            streamWriter.Close();
            fileStream.Close();
        }
    }

    public class ConsoleLogger
    {
        //delegate
        public void Logger(string s)
        {
            Console.WriteLine(s);
        }
    }

    class Program
    {
        static void Main()
        {
            FileLogger fl = new FileLogger("process.log");
            ConsoleLogger cl = new ConsoleLogger();

            MyClass myClass = new MyClass();

            MyClass.LogHandler myLogger = fl.Logger;
            MyClass.Info("Prueba FileLogger");
            myClass.Process(myLogger);
            fl.Close();

            MyClass.Info("Prueba Console");
            myLogger = cl.Logger;
            myClass.Process(myLogger);

            Console.Read();
        }
    }
}
