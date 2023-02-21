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
                try
                {
                    while (this.CanExecuteNextStep)
                    {
                        Process.ExecuteNext();
                        CancellationTokenSource.Token.WaitHandle.WaitOne(TickDelay);
                    }
                    PostProcessingLogic();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString()); //DUMMY LOG EXCEPTION => NORMALLY WE WOULD USE A LOGGER HERE
                    Status = ProcessorState.Faulted;
                    //throwing here will cause the execution to stop, and I don't want my application to crash if a task fails
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
