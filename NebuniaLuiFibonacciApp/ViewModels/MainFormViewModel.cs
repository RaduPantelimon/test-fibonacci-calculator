using NebuniaLuiFibonacci.Core;
using NebuniaLuiFibonacciApp.Properties;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NebuniaLuiFibonacciApp
{
    internal class MainFormViewModel: FormViewModelBase
    {
        public ObservableCollection<BackgroundProcessor<FibonacciProcess>> LiveFibonacciProcesses { get; set; }
        public FibonacciProcessViewModel FibonacciProcess { get; }

        public MainFormViewModel()
        {
            LiveFibonacciProcesses = new();
            FibonacciProcess = new FibonacciProcessViewModel();

            StartWorkerCommand = new DelegateCommand<BackgroundProcessor<FibonacciProcess>>(StartWorker_Execute);
            StopWorkerCommand = new DelegateCommand<BackgroundProcessor<FibonacciProcess>>(StopWorker_Execute);
            RemoveWorkerCommand = new DelegateCommand<BackgroundProcessor<FibonacciProcess>>(RemoveWorker_Execute);
            CreateWorkerCommand = new DelegateCommand(CreateWorker_Execute);
        }

        #region Commands

        public ICommand CreateWorkerCommand { get; protected set; }
        public ICommand StopWorkerCommand { get; protected set; }
        public ICommand RemoveWorkerCommand { get; protected set; }
        public ICommand StartWorkerCommand { get; protected set; }

        public void StopWorker_Execute(BackgroundProcessor<FibonacciProcess> worker)
        {
            //stop Fibonacci worker
            worker.Stop();
        }

        public void RemoveWorker_Execute(BackgroundProcessor<FibonacciProcess> worker)
        {
            //remove Fibonacci worker from Table
            LiveFibonacciProcesses.Remove(worker);
        }

        public void StartWorker_Execute(BackgroundProcessor<FibonacciProcess> worker)
        {
            //start Fibonacci worker
            worker.Start();
        }

        public void CreateWorker_Execute()
        {
            if (!FibonacciProcess.IsValid)
                throw new Exception(Resources.ExceptionMessage_FibonacciModelNotValid);
            
            BackgroundProcessor<FibonacciProcess> worker =
                ProcessorsFactory.Instance.GetFibonacciProcessor(
                    (int)FibonacciProcess.FirstTerm!,
                    (int)FibonacciProcess.SecondTerm!,
                    FibonacciProcess.WorkerType);

            LiveFibonacciProcesses.Add(worker);
        }
        
        #endregion
    }
}
