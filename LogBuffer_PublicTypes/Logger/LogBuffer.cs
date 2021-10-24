using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Logger
{
    public class LogBuffer: IDisposable
    {
        private List<Message> messages;
        private int bufferSize;
        private string filePath;
        private Timer timer;
        private bool timerState;
        private object messageListLock = new object();
        private object writeMessages = new object();
        private bool disposed;

        public LogBuffer(int maxbufferSize, int timerInterval, string destFile)
        {
            bufferSize = maxbufferSize;
            filePath = destFile;
            messages = new List<Message>();
            disposed = false;

            timerState = true;
            TimerCallback timerCallback = new TimerCallback(ClearBuffer);
            timer = new Timer(timerCallback, timerState, 0, timerInterval);
        }

        private async void ClearBuffer(object state)
        {
            if ((bool)state)
            {
                Console.WriteLine("Запись на диск по таймеру");
                await Task.Run(() => WriteToFile());
            }
        }

        public async void Add(Message item)
        {
            bool state = false;
            lock(messageListLock)
            {
                messages.Add(item);
                if (messages.Count == bufferSize)
                    state = true;
                Console.WriteLine($"Добавление сообщения (количество сообщений в бефере = {messages.Count}): {item.ToString()}");
            }

            if (state)
            {
                Console.WriteLine("Запись на диск из-за нехватки места в буфере");
                await Task.Run(() => WriteToFile());
            }

        }

        private void WriteToFile()
        {
            List<Message> oldMessages = null;
            lock(messageListLock)
            {
                oldMessages = new List<Message>(messages);
                messages.Clear();
            }

            lock(writeMessages)
            {
                using (StreamWriter stream = File.AppendText(filePath))
                {
                    foreach(Message message in oldMessages)
                    {
                        stream.WriteLine(message.ToString());
                    }
                }
            }
        }

        public void Dispose()
        {
            Console.WriteLine("Вызов деструктора");
            if (disposed) return;

            timerState = false;
            WriteToFile();

            disposed = true;
        }

        ~LogBuffer()
        {
            Dispose();
        }
    }
}
