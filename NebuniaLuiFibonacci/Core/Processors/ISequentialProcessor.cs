using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacci.Core
{
    public interface ISequentialProcessor<T> where T: IMultiStepProcess
    {
        T Process { get;}
        ProcessorState Status { get; }
        void Start();
        void Stop();
    }
}
