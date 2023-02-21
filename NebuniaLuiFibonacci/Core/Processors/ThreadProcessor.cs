using NebuniaLuiFibonacci.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacci.Core
{
    public class ThreadProcessor<T> : BackgroundProcessor<T> where T : IMultiStepProcess
    {
        public ThreadProcessor(T process) : base(process, Resources.ThreadProcessor_Name)
        {
        }

        protected override void BeginProcess()
        {
            var thread = new Thread(() =>
            {
                while (this.CanExecuteNextStep)
                {
                    Process.ExecuteNext();
                    CancellationTokenSource.Token.WaitHandle.WaitOne(TickDelay);
                }
                PostProcessingLogic();
            });
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
