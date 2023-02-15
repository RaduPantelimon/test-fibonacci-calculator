using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacci.Core
{
    //a basic interface that represents computationally intensive processes
    //that are composed of multiple sequences of code
    public interface ISequentialProcess
    {
        public void ExecuteNextSequence();
    }
}
