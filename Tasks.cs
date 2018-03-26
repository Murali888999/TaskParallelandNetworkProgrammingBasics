using System;
using System.Threading.Tasks;
using System.Threading;
using log4net;
using log4net.Config;

namespace TaskParellel
{
    class Tasks
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Thread6));
        public static void Work1(int i, int time)
        {
            Console.WriteLine("task {0} is beggin....", i);
            Thread.Sleep(time);
            Console.WriteLine("task {0} is ended.....", i);
        }

        public static void Work2(int i, int time)
        {
            Console.WriteLine("DoOther {0} is beggin....", i);
            Thread.Sleep(time);
            Console.WriteLine("DoOther {0} is ended.....", i);
        }
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            //Task t1 = new Task(() => Work1(1, 1500));
            //t1.Start();
            //Task t2 = new Task(() => Work1(2, 1500));
            //t2.Start();
            //Task t3 = new Task(() => Work1(3, 1500));
            //t3.Start();

            Task t1 = Task.Factory.StartNew(() => Work1(1, 1500));
            Task t2 = Task.Factory.StartNew(() => Work1(2, 1500));
            Task t3 = Task.Factory.StartNew(() => Work1(3, 1500));

            Task.WaitAll(t1, t2, t3);

            Work2(1, 2000);
            Console.ReadLine();
        }
    }
}



