using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;

namespace ThreadPool
{
    public class TaskQueue
    {
        private int threadCount;
        private List<Thread> threadPool;
        public delegate void TaskDelegate();
        private ConcurrentQueue<TaskDelegate> tasksQueue;

        public TaskQueue(int threadCount)
        {
            tasksQueue = new ConcurrentQueue<TaskDelegate>();

            this.threadCount = threadCount;
            threadPool = new List<Thread>();

            for (int i = 0; i < threadCount; i++)
            {
                threadPool.Add(new Thread(RunTask) { IsBackground = true });
                threadPool[i].Start();
            }
        }

        public void EnqueueTask(TaskDelegate task)
        {
            tasksQueue.Enqueue(task);
        }

        private void RunTask()
        {
            while (true)
            {
                bool res = tasksQueue.TryDequeue(out TaskDelegate task);
                if (res)
                {
                    task.Invoke();
                }

                //Console.WriteLine($"RunTask did 1 task, ThreadId = {Thread.CurrentThread.ManagedThreadId}");

                SpinWait.SpinUntil(() => tasksQueue.Count > 0);
            }
        }
    }

}
