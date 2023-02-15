using NebuniaLuiFibonacci.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacci.Core
{
    public class TaskProcessor<T> : BackgroundProcessor<T> where T : ISequentialProcess
    {

        public TaskProcessor(T process) : base(process)
        {
        }


        protected override void BeginProcess() => _ = ExecuteProcessStepsAsync();

        protected async Task ExecuteProcessStepsAsync()
        {
            //jump on another Thread ASAP - relevant if the ExecuteNextSequence is really computationallyIntensive
            await Task.Yield();

            while (!CancellationTokenSource.IsCancellationRequested)
            {
                
                Process.ExecuteNextSequence();
                await Task.Delay(TickDelay, CancellationTokenSource.Token).ConfigureAwait(false);
            }
        }
    }
}
