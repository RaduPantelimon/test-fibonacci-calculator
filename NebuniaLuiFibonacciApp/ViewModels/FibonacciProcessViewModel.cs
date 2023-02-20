using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NebuniaLuiFibonacci.Core;
using NebuniaLuiFibonacciApp.Properties;

namespace NebuniaLuiFibonacciApp
{
    public class FibonacciProcessViewModel: FormViewModelBase
    {

        private int? firstTerm;
        private int? secondTerm;

        [Required]
        [FibonacciInteger]
        public int? FirstTerm 
        {
            get
            {
                return firstTerm;
            }
            set
            {
                this.firstTerm = value;
                this.OnPropertyChanged();
            }
        }

        [Required]
        [FibonacciInteger]
        public int? SecondTerm
        {
            get
            {
                return secondTerm;
            }
            set
            {
                this.secondTerm = value;
                this.OnPropertyChanged();
            }
        }
        public ProcessorType WorkerType { get; set; }

    }
}
