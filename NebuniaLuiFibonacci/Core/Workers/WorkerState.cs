using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacci.Core
{
    public enum WorkerState
    {
        WaitingForActivation,
        Running,
        RanUntilCanceled,
        Faulted
    }
}
