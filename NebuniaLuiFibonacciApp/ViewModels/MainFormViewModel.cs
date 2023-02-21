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

            StartProcessCommand = new DelegateCommand<BackgroundProcessor<FibonacciProcess>>(StartProcess_Execute);
            StopProcessCommand = new DelegateCommand<BackgroundProcessor<FibonacciProcess>>(StopProcess_Execute);
            RemoveProcessCommand = new DelegateCommand<BackgroundProcessor<FibonacciProcess>>(RemoveProcess_Execute);
            CreateProcessCommand = new DelegateCommand(CreateProcess_Execute);
        }

        #region Commands

        public ICommand CreateProcessCommand { get; protected set; }
        public ICommand StopProcessCommand { get; protected set; }
        public ICommand RemoveProcessCommand { get; protected set; }
        public ICommand StartProcessCommand { get; protected set; }

        public void StopProcess_Execute(BackgroundProcessor<FibonacciProcess> process)
        {
            //stop Fibonacci worker
            process.Stop();
        }

        public void RemoveProcess_Execute(BackgroundProcessor<FibonacciProcess> process)
        {
            //remove Fibonacci worker from Table
            LiveFibonacciProcesses.Remove(process);
        }

        public void StartProcess_Execute(BackgroundProcessor<FibonacciProcess> process)
        {
            //start Fibonacci worker
            process.Start();
        }

        public void CreateProcess_Execute()
        {
            if (!FibonacciProcess.IsValid)
                throw new Exception(Resources.ExceptionMessage_FibonacciModelNotValid);
            
            BackgroundProcessor<FibonacciProcess> process =
                ProcessorsFactory.Instance.GetFibonacciProcessor(
                    (int)FibonacciProcess.FirstTerm!,
                    (int)FibonacciProcess.SecondTerm!,
                    FibonacciProcess.Type);

            LiveFibonacciProcesses.Add(process);
        }
        
        #endregion
    }
}
