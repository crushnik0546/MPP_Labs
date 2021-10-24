using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "d:\\SPP_Lab_Test\\Logger.txt";

            using(LogBuffer logger = new LogBuffer(10, 10000, filePath))
            {
                for (int i = 0; i < 20; i++)
                {
                    logger.Add(new Message(Message.MessageType.Error, $"Message -> {i}"));
                    Thread.Sleep(200);
                }
            }
        }
    }
}
