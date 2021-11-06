using System;
using System.Threading;

namespace Parallel_WaitAll
{
    class Program
    {
        static void Main(string[] args)
        {
            WaitCallback[] tasks = { Task1, Task2, Task3, Task1, Task2, Task3, Task1, Task2, Task3 };

            Parallel.WaitAll(tasks);
        }

        static void Task1(object state)
        {
            Thread.Sleep(1000);
            Console.WriteLine("Task1 completed");
        }

        static void Task2(object state)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Task2 completed");
        }

        static void Task3(object state)
        {
            Thread.Sleep(100);
            Console.WriteLine("Task3 completed");
        }
    }
}
