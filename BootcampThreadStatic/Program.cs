using System;
using System.Threading;

namespace BootcampThreadStatic
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i=0; i<3;i++)
            {
                Thread newThread = new Thread(ThreadData.ThreadStaticDemo);
                newThread.Start();
            }
            Console.ReadLine();
        }
    }

    class ThreadData
    {
        static Random randomGenerator = new Random();
        [ThreadStatic]  // ensures that threadSpecifiData is specific (static) for each thread
        static int threadSpecificData;

        public static void ThreadStaticDemo()
        {
            // store the managed thread id for each thread in the static variable
            //threadSpecificData = Thread.CurrentThread.ManagedThreadId;
            threadSpecificData = randomGenerator.Next(1, 200);
            // allow other threads time to execute the same code, to show 
            // that the static data is unique to each thread
            Thread.Sleep(1000);

            // Display the static data
            Console.WriteLine("Data for managed thread {0}: {1}",
                Thread.CurrentThread.ManagedThreadId, threadSpecificData);

        }

    }
}
