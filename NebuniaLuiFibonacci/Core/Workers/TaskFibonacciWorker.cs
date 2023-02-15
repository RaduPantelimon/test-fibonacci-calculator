using NebuniaLuiFibonacci.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacci
{
    public class TaskWorker:Worker
    {

        public TaskWorker(int term1, int term2): base(term1, term2)
        {
        }

        protected override void BeginFibonacci() =>
            Task.Factory.StartNew(
                    FibonacciProcess, // this will use current synchronization context
                    CancellationTokenSource.Token,
                    TaskCreationOptions.None,
                    TaskScheduler.Default);

        protected async Task FibonacciProcess()
        {
            while (!CancellationTokenSource.IsCancellationRequested)
            {
                GenerateNextFibonacciElement();
                await Task.Delay(TickDelay, CancellationTokenSource.Token).ConfigureAwait(false);
            }
        }
    }
}
