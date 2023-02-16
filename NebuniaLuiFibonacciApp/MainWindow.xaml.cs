using NebuniaLuiFibonacci;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NebuniaLuiFibonacci.Core;

namespace NebuniaLuiFibonacci
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<BackgroundProcessor<FibonacciProcess>> FibonacciRequests { get; set; } = new();

        public MainWindow()
        {
            FibonacciRequests.Add(new TaskProcessor<FibonacciProcess>(new FibonacciProcess(2, 3)));
            FibonacciRequests.Add(new TaskProcessor<FibonacciProcess>(new FibonacciProcess(5, 8)));
            FibonacciRequests.Add(new ThreadProcessor<FibonacciProcess>(new FibonacciProcess(1, 2)));
            FibonacciRequests.Add(new ThreadProcessor<FibonacciProcess>(new FibonacciProcess(1, 1)));

            SetCommandBindings();
            InitializeComponent();

        }


        public void StopWorker_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            //remove Fibonacci worker and stop it
            BackgroundProcessor<FibonacciProcess> worker = (BackgroundProcessor<FibonacciProcess>)e.Parameter;
            worker.Stop();
            FibonacciRequests.Remove(worker);
        }
        public void StartWorker_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            //remove Fibonacci worker and stop it
            BackgroundProcessor<FibonacciProcess> worker = (BackgroundProcessor<FibonacciProcess>)e.Parameter;
            worker.Start();
        }

        #region Commands
        public ICommand StopWorkerCommand { get; set; }
        public ICommand StartWorkerCommand { get; set; }

        public void SetCommandBindings()
        {
            StopWorkerCommand = new RoutedCommand();
            StartWorkerCommand = new RoutedCommand();
            CommandBindings.Add(new CommandBinding(StopWorkerCommand, StopWorker_Execute));
            CommandBindings.Add(new CommandBinding(StartWorkerCommand, StartWorker_Execute));
        }
        #endregion
    }
}
