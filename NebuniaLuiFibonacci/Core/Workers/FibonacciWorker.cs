using NebuniaLuiFibonacci.Core;
using NebuniaLuiFibonacci.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacci
{
    public abstract class Worker:INotifyPropertyChanged
    {
        protected static TimeSpan TickDelay { get; } = TimeSpan.FromMilliseconds(int.Parse(Resources.Tick));
        protected static TimeSpan ThreadDelay { get; } = TimeSpan.FromMilliseconds(int.Parse(Resources.ThreadDelay));
        protected static TimeSpan TaskDelay { get; } = TimeSpan.FromMilliseconds(int.Parse(Resources.TaskDelay));

        public int OriginalFirstTerm { get; }
        public int OriginalSecondTerm { get; }

        private readonly object _penultimateTermLock = new object();
        private readonly object _lastTermLock = new object();
        private readonly object _stateLock = new object();

        WorkerState _state;

        public WorkerState Status { 
            get
            {
                lock (_stateLock)
                    return _state;

            }
            protected set
            {
                lock (_stateLock)
                {
                    _state = value;
                }
                OnPropertyChanged();
            } 
        }

        int _penultimateTerm;
        public int PenultimateTerm 
        {
            get
            {
                lock (_penultimateTermLock)
                    return _penultimateTerm;
            }
            protected set
            {
                lock (_penultimateTermLock)
                {
                    _penultimateTerm = value;
                }
                OnPropertyChanged();
            }
        }
        int _lastTerm;
        public int LastTerm 
        {
            get 
            {
                lock (_lastTermLock)
                    return _lastTerm;
            } 
            protected set 
            {
                lock (_lastTermLock)
                {
                    _lastTerm = value;
                }
                OnPropertyChanged();
            }
        }

        protected CancellationTokenSource CancellationTokenSource {get;}

        public Worker(int term1, int term2)
        {
            PenultimateTerm = OriginalFirstTerm = term1;
            LastTerm = OriginalSecondTerm = term2;
            CancellationTokenSource = new CancellationTokenSource();
            Status = WorkerState.WaitingForActivation;
        }

        public void Start()
        {
            if (Status == WorkerState.RanUntilCanceled) 
                throw new InvalidOperationException(Resources.Exception_StartFinishedWorker);
            if (Status != WorkerState.WaitingForActivation) 
                throw new InvalidOperationException(Resources.Exception_GenericStartWorkerError);

            Status = WorkerState.Running;
            BeginFibonacci();
        }

        protected abstract void BeginFibonacci();

        public void Stop()
        {
            if (Status != WorkerState.Running) 
                throw new InvalidOperationException(Resources.Exception_StopWorkerError);
            
            Status = WorkerState.RanUntilCanceled;
            CancellationTokenSource.Cancel();
        }
            
        
        protected int GenerateNextFibonacciElement()
        {
            //calculate new element and update terms
            int sum = PenultimateTerm + LastTerm;
            PenultimateTerm = LastTerm;
            LastTerm = sum;
            return sum;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
