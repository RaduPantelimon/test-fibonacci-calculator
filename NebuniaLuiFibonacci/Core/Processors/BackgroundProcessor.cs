using NebuniaLuiFibonacci.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacci.Core
{
    public abstract class BackgroundProcessor<T>:ISequentialProcessor<T>, INotifyPropertyChanged where T: IMultiStepProcess
    {
        protected static TimeSpan TickDelay { get; } = TimeSpan.FromMilliseconds(int.Parse(Resources.Tick));
        protected static TimeSpan ThreadDelay { get; } = TimeSpan.FromMilliseconds(int.Parse(Resources.ThreadDelay));
        protected static TimeSpan TaskDelay { get; } = TimeSpan.FromMilliseconds(int.Parse(Resources.TaskDelay));

        private readonly object _stateLock = new object();

        ProcessorState _state;
        public ProcessorState Status { 
            get
            {
                lock (_stateLock)
                    return _state;
            }
            protected set
            {
                lock (_stateLock)
                    _state = value;
                OnPropertyChanged();
            } 
        }

        protected CancellationTokenSource CancellationTokenSource {get;}
        public T Process { get; }

        public BackgroundProcessor(T process)
        {
            Process = process;
            CancellationTokenSource = new CancellationTokenSource();
            Status = ProcessorState.Unactivated;
        }

        public void Start()
        {
            if (Status == ProcessorState.Canceled) 
                throw new InvalidOperationException(Resources.Exception_StartFinishedWorker);
            if (Status != ProcessorState.Unactivated) 
                throw new InvalidOperationException(Resources.Exception_GenericStartWorkerError);

            Status = ProcessorState.Running;
            BeginProcess();
        }

        protected abstract void BeginProcess();

        public void Stop()
        {
            if (Status != ProcessorState.Running) 
                throw new InvalidOperationException(Resources.Exception_StopWorkerError);
            
            Status = ProcessorState.Canceled;
            CancellationTokenSource.Cancel();
        }
            

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
