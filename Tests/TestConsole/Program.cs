using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Loggers;

namespace TestConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Logger logger = new ListLogger();
            //Logger logger = new FileLogger("program.log");
            //Logger logger = new VisualStudioOutputLogger();
            Logger logger = new TraceLogger();
            Trace.Listeners.Add(new TextWriterTraceListener("trace.log"));

            var critical_logger = new ListLogger();
            var student_logger = new Student { Name = "Иванов" };
            DoSomeCriticalWork(student_logger);

            logger.LogInformation("Start program");

            for (var i = 0; i < 10; i++)
                logger.LogInformation($"Do some work {i + 1}");

            logger.LogWarning("Завершение работы приложения");

            //var log_message = ((ListLogger)logger).Messages;

            Trace.Flush();

            Console.ReadLine();
        }

        public static void DoSomeCriticalWork(ILogger log)
        {
            for (var i = 0; i < 10; i++)
            {
                log.LogInformation($"Do some very important work {i + 1}");
            }


        }

    }

    public class Student : ILogger
    {

        private List<string> _Messages = new List<string>();
        public string Name { get; set; }

        public List<int> Ratings { get; set; } = new List<int>();

        public void Log(string Message)
        {
            Ratings.Add(Message.Length);
            _Messages.Add(Message);
        }


        public void LogInformation(string Message) { Log("Info:" + Message); }


        public void LogWarning(string Message) { Log("Warning:" + Message); }

        public void LogError(string Message) { Log("Error:" + Message); }
    }


}
