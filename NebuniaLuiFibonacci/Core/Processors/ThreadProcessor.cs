using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacci.Core
{
    public class ThreadProcessor<T> : BackgroundProcessor<T> where T : IMultiStepProcess
    {
        public ThreadProcessor(T process) : base(process)
        {
        }

        protected override void BeginProcess()
        {
            var thread = new Thread(() =>
            {
                while (Process.CanExecuteNextStep && !CancellationTokenSource.IsCancellationRequested)
                {
                    Process.ExecuteNext();
                    CancellationTokenSource.Token.WaitHandle.WaitOne(TickDelay);
                }
                if (!Process.CanExecuteNextStep) Status = ProcessorState.Finished;
            });
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
