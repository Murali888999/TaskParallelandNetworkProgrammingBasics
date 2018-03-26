using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using log4net.Config;
using log4net;

namespace TaskParellel
{
    class Parllel
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Parallel));
        public static void PFor()
        {
            Parallel.For(0, 10, i =>
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            });
        }
        public static void PForEach()
        {
            List<String> list = new List<string>();
            list.Add("Murali");
            list.Add("Bhargav");
            list.Add("Bhaskar");
            list.Add("Madhu");
            list.Add("Anil");
            list.Add("Kalpu");
            list.Add("sreevani");
            list.Add("Arun");

            Parallel.ForEach(list, l =>
            {
                Console.WriteLine(l);
                Thread.Sleep(1000);
            });
        }
        public static void calcTime()
        {
            Stopwatch watch;
            watch = new Stopwatch();
            watch.Start();

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);               
            }
            watch.Stop();
            log.Info("normal implementation:" + watch.Elapsed.Seconds.ToString());
                    
            watch = new Stopwatch();
            watch.Start();
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);    
            }
            );
            watch.Stop();
            Console.WriteLine("Parallel implemetation: " + watch.Elapsed.Seconds.ToString());
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            PForEach();
            calcTime();
            Console.Read();
        }
    }
}