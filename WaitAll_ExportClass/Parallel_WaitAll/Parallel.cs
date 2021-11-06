using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Parallel_WaitAll
{
    public static class Parallel
    {
        public static void WaitAll(WaitCallback[] tasks)
        {
            foreach (var task in tasks)
            {
                ThreadPool.QueueUserWorkItem(task);
            }

            ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int _);

            bool isComplete = false;

            while (!isComplete)
            {
                ThreadPool.GetAvailableThreads(out int currentWorkerThreads, out int _);
                if (maxWorkerThreads == currentWorkerThreads)
                {
                    isComplete = true;
                }
                else
                {
                    Thread.Yield();
                }
            }
        }
    }
}
