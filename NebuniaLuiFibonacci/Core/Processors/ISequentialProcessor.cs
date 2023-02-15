using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacci.Core
{
    public interface ISequentialProcessor<T> where T: ISequentialProcess
    {
        T Process { get;}
        WorkerState Status { get; }
        void Start();
        void Stop();
    }
}
