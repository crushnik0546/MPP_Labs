using System;
using System.IO;
using System.Threading;

namespace ThreadPool
{
    public class Copy
    {
        private TaskQueue taskQueue;

        private int allFiles = 0;
        private int copiedFiles = 0;

        public Copy(int threadCount)
        {
            taskQueue = new TaskQueue(threadCount);
        }

        private void CheckDirectories(string source, string dest)
        {
            if (source == dest)
            {
                throw new Exception("Source and destination directories are the same.");
            }

            if (!Directory.Exists(source))
            {
                throw new Exception("Source directory doesn't exist.");
            }

            if (!Directory.Exists(dest))
            {
                throw new Exception("Destination directory doesn't exist.");
            }
        }

        public void Run(string sourceDir, string destDir)
        {
            CheckDirectories(sourceDir, destDir);

            string[] files = Directory.GetFiles(sourceDir);
            allFiles += files.Length;

            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);

                taskQueue.EnqueueTask(() =>
                {
                    File.Copy(file, Path.Combine(destDir, fileName), true);
                    Console.WriteLine($"{file} -> {Path.Combine(destDir, fileName)}");
                    Interlocked.Increment(ref copiedFiles);
                });
            }

            string[] directories = Directory.GetDirectories(sourceDir);
            foreach (var dir in directories)
            {
                string newDestDir = Path.Combine(destDir, Path.GetFileName(dir));
                Directory.CreateDirectory(newDestDir);

                Run(dir, newDestDir);
            }

        }

        public void PrintInfo()
        {
            Console.WriteLine($"Total number of copied files: {copiedFiles}");
        }

        public void WaitAll()
        {
            SpinWait.SpinUntil(() => copiedFiles == allFiles);
        }
    }
}
