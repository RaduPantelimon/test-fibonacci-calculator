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

namespace NebuniaLuiFibonacci
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Worker> FibonacciRequests { get; set; } = new();

        public MainWindow()
        {
            FibonacciRequests.Add(new TaskWorker(2, 3));
            FibonacciRequests.Add(new TaskWorker(1, 1));
            FibonacciRequests.Add(new ThreadWorker(1, 1));
            FibonacciRequests.Add(new ThreadWorker(3, 4));

            FibonacciRequests[0].Start();
            FibonacciRequests[1].Start();
            FibonacciRequests[2].Start();
            FibonacciRequests[3].Start();


            SetCommandBindings();
            InitializeComponent();
        }


        public void StopWorker_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            //remove Fibonacci worker and stop it
            Worker worker = (Worker)e.Parameter;
            worker.Stop();
            FibonacciRequests.Remove(worker);
        }

        #region Commands
        public ICommand StopWorkerCommand { get; set; }

        public void SetCommandBindings()
        {
            StopWorkerCommand = new RoutedCommand();
            CommandBindings.Add(new CommandBinding(StopWorkerCommand, StopWorker_Execute));
        }
        #endregion
    }
}
