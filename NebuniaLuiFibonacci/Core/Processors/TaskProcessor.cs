using NebuniaLuiFibonacci.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacci.Core
{
    public class TaskProcessor<T> : BackgroundProcessor<T> where T : IMultiStepProcessable
    {

        public TaskProcessor(T process) : base(process, Resources.TaskProcessor_Name)
        {
        }

        protected override void BeginProcess()
        {
            //via Default task scheduler we "lose the SynchronizationContext" and we jump on another Thread ASAP -
            //relevant if the ExecuteNext is really computationallyIntensive
            Task task  = Task.Factory.StartNew(ExecuteProcessStepsAsync, 
                CancellationTokenSource.Token, 
                TaskCreationOptions.None, 
                TaskScheduler.Default);
        }

        protected async Task ExecuteProcessStepsAsync()
        {
            try
            {
                while (this.CanExecuteNextStep)
                {
                    Process.ExecuteNext();
                    await Task.Delay(TickDelay, CancellationTokenSource.Token).ConfigureAwait(false);
                }
                PostProcessingLogic();
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                Console.WriteLine(ex.ToString()); //DUMMY LOG EXCEPTION => NORMALLY WE WOULD USE A LOGGER HERE
                Status = ProcessorState.Faulted;
                throw; //Throwing the error, so our task appears as faulted
            }
        }
    }
}
