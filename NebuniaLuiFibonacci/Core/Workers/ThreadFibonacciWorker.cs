using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacci
{
    public class ThreadWorker : Worker
    {
        public ThreadWorker(int term1, int term2) : base(term1, term2)
        {
        }

        protected override void BeginFibonacci()
        {
            Thread thread = new Thread(() =>
            {
                while (!CancellationTokenSource.IsCancellationRequested)
                {
                    GenerateNextFibonacciElement();
                    CancellationTokenSource.Token.WaitHandle.WaitOne(TickDelay);
                }
            });
            thread.Start();
        }
    }
}
