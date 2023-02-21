using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacci.Core
{
    public class ProcessorsFactory
    {
        private ProcessorsFactory()
        {
        }

        private static ProcessorsFactory? instance;
        public static ProcessorsFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProcessorsFactory();
                }
                return instance;
            }
        }

        public FibonacciProcess GetFibonacciProcess(int FirstTerm, int SecondTerm)
        => new FibonacciProcess(FirstTerm, SecondTerm);

        public BackgroundProcessor<FibonacciProcess> GetFibonacciProcessor(int FirstTerm, int SecondTerm, ProcessorType type)
        {
            FibonacciProcess fibonacciProcess = GetFibonacciProcess(FirstTerm, SecondTerm);
            return type switch
            {
                ProcessorType.Task => new TaskProcessor<FibonacciProcess>(fibonacciProcess),
                ProcessorType.Thread => new ThreadProcessor<FibonacciProcess>(fibonacciProcess),
                _ => throw new InvalidOperationException()
            };
        }
    }
}
