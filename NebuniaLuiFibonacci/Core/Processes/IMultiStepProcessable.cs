using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacci.Core
{
    //a basic interface that represents computationally intensive multi-step processes
    public interface IMultiStepProcess
    {
        //check if it next sequence can be executed
        public bool CanExecuteNextStep { get; }
        //execute next sequence
        public void ExecuteNext();
    }
}
