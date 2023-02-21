using NebuniaLuiFibonacci.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacci.Core
{
    public class TaskProcessor<T> : BackgroundProcessor<T> where T : IMultiStepProcess
    {

        public TaskProcessor(T process) : base(process, Resources.TaskProcessor_Name)
        {
        }

        protected override void BeginProcess()
        {
            //via Default task scheduler we "lose the SynchronizationContext" and we jump on another Thread ASAP -
            //relevant if the ExecuteNext is really computationallyIntensive
            Task.Factory.StartNew(ExecuteProcessStepsAsync, 
                CancellationTokenSource.Token, 
                TaskCreationOptions.None, 
                TaskScheduler.Default);
        }

        protected async Task ExecuteProcessStepsAsync()
        {
            while (this.CanExecuteNextStep)
            {
                Process.ExecuteNext();
                await Task.Delay(TickDelay, CancellationTokenSource.Token).ConfigureAwait(false);
            }
            PostProcessingLogic();
        }
    }
}
