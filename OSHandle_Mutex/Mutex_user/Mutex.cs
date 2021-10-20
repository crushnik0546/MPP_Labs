using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace User_Mutex
{
    public class Mutex
    {
        private static readonly int UnlockedState = -1;
        private int LockedState = Thread.CurrentThread.ManagedThreadId;
        private int state;

        private static readonly SpinWait delay = new SpinWait();

        public Mutex()
        {
            state = UnlockedState;
        }

        public void Lock()
        {
            while (Interlocked.CompareExchange(ref state, LockedState, UnlockedState) != UnlockedState)
            {
                delay.SpinOnce();
            };
        }

        public void Unlock()
        {
            if (Interlocked.CompareExchange(ref state, UnlockedState, LockedState) != LockedState)
            {
                throw new Exception($"Unable to unlock mutex by {Thread.CurrentThread.Name} thread");
            }
        }
    }
}
