using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UtilHelper.Threading
{
    /*NOTES/
     * https://stackoverflow.com/questions/22688679/process-queue-with-multithreading-or-tasks
     * https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/dataflow-task-parallel-library?redirectedfrom=MSDN
     * 
     * https://www.c-sharpcorner.com/UploadFile/1d42da/thread-locking-in-C-Sharp/
     * https://docs.microsoft.com/en-us/dotnet/api/system.threading.threadpool?view=net-5.0
     * 
     * https://www.sqlite.org/threadsafe.html
     * 
     */
    class WorkerThreads
    {
        public void doStuff()
        {

        }

        public void StartThreadsusingTasks()
        {
            Task task1 = Task.Factory.StartNew(() => doStuff());
            Task task2 = Task.Factory.StartNew(() => doStuff());
            Task task3 = Task.Factory.StartNew(() => doStuff());

            Task.WaitAll(task1, task2, task3);
            Console.WriteLine("All threads complete");
        }

        public void StartThreadsTradtionalWay()
        {
            Thread t1 = new Thread(doStuff);
            t1.Start();

            Thread t2 = new Thread(doStuff);
            t2.Start();

            Thread t3 = new Thread(doStuff);
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("All threads complete");
        }

        public void StartThreadsTradtionalWay_WithListDataStructure()
        {
            List<Thread> threads = new List<Thread>();


            // Start threads
            for (int i = 0; i < 10; i++)
            {
                int tmp = i; // Copy value for closure
                Thread t = new Thread(() => Console.WriteLine(tmp));
               // t.Start;
                threads.Add(t);
            }

            // Await threads
            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("All threads complete");
        }
    }
}
