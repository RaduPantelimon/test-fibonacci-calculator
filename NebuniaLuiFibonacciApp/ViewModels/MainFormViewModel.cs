using NebuniaLuiFibonacci.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacciApp
{
    internal class MainFormViewModel: FormViewModelBase
    {
        public ObservableCollection<BackgroundProcessor<FibonacciProcess>> LiveFibonacciProcesses { get; set; }
        public FibonacciProcessViewModel FibonacciProcess { get; }

        public MainFormViewModel()
        {
            FibonacciProcess = new FibonacciProcessViewModel();
            LiveFibonacciProcesses = new();


            //TEST DATA
            LiveFibonacciProcesses.Add(new TaskProcessor<FibonacciProcess>(new FibonacciProcess(2, 3)));
            LiveFibonacciProcesses.Add(new TaskProcessor<FibonacciProcess>(new FibonacciProcess(5, 8)));
            LiveFibonacciProcesses.Add(new ThreadProcessor<FibonacciProcess>(new FibonacciProcess(1, 2)));
            LiveFibonacciProcesses.Add(new ThreadProcessor<FibonacciProcess>(new FibonacciProcess(1, 1)));
        }
    }
}
