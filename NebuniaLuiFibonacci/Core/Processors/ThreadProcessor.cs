using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacci.Core
{
    public class ThreadProcessor<T> : BackgroundProcessor<T> where T : ISequentialProcess
    {
        public ThreadProcessor(T process) : base(process)
        {
        }

        protected override void BeginProcess()
        {
            new Thread(() =>
            {
                while (!CancellationTokenSource.IsCancellationRequested)
                {
                    Process.ExecuteNextSequence();
                    CancellationTokenSource.Token.WaitHandle.WaitOne(TickDelay);
                }
            }).Start();
        }
    }
}
