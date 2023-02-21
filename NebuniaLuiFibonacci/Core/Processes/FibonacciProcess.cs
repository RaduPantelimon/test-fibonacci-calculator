using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacci.Core
{
    public class FibonacciProcess: IMultiStepProcess, INotifyPropertyChanged
    {
        public int OriginalFirstTerm { get; }
        public int OriginalSecondTerm { get; }

        private readonly object _termLock = new object();

        int _penultimateTerm;
        public int PenultimateTerm
        {
            get
            {
                lock (_termLock)
                    return _penultimateTerm;
            }
            protected set
            {
                lock (_termLock)
                    _penultimateTerm = value;

                OnPropertyChanged();
            }
        }
        int _lastTerm;
        public int LastTerm
        {
            get
            {
                lock (_termLock)
                    return _lastTerm;
            }
            protected set
            {
                lock (_termLock)
                    _lastTerm = value;

                OnPropertyChanged();
            }
        }

        public FibonacciProcess(int term1, int term2)
        {
            PenultimateTerm = OriginalFirstTerm = term1;
            LastTerm = OriginalSecondTerm = term2;
        }

        public bool CanExecuteNextStep
        {
            get
            {
                if (PenultimateTerm > 0 && LastTerm > 0 && int.MaxValue - LastTerm < PenultimateTerm)
                    return false;
                if (PenultimateTerm < 0 && LastTerm < 0 && int.MinValue - LastTerm > PenultimateTerm)
                    return false;

                return true;
            }
        }
        

        public void ExecuteNext()
        {
            //calculate new Fibonacci element and update terms
            int sum = checked(PenultimateTerm + LastTerm); //throw exception we overflow
            lock(_termLock) //we don't want for a consumer to retrieve missmatched terms by accident
            {
                PenultimateTerm = LastTerm;
                LastTerm = sum;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
