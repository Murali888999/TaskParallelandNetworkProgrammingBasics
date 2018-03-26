using System;
using System.Diagnostics;
using System.Threading;

namespace TaskParellel
{
    class ThreadPoll
    {
        static void Run(object callback)
        {
        }
        static void RunWithThreadPool()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Run));
            }
        }

        static void RunWithOutThreadPool()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Run);
                obj.Start();
            }
        }

        static void Main(string[] args)
        {
 
            RunWithThreadPool();
            RunWithOutThreadPool();


            Stopwatch mywatch = new Stopwatch();

            Console.WriteLine("Run with thread pool");

            mywatch.Start();
            RunWithThreadPool();
            mywatch.Stop();

            Console.WriteLine("Time consumed with thread pool is : " + mywatch.ElapsedTicks.ToString());
            mywatch.Reset();


            Console.WriteLine("Run without thread pool");

            mywatch.Start();
            RunWithOutThreadPool();
            mywatch.Stop();

            Console.WriteLine("Time consumed with out thread pool is : " + mywatch.ElapsedTicks.ToString());
            Console.Read();
        }
    }
}
