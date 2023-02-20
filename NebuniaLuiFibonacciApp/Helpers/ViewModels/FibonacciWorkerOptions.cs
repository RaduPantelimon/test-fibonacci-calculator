using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NebuniaLuiFibonacci.Core;

namespace NebuniaLuiFibonacci.Core
{
    public class FibonacciWorkerViewModel
    {
        public int? FirstTerm { get; set; }
        public int? SecondTerm { get; set; }
        public ProcessorType WorkerType { get; set; }
    }
}
