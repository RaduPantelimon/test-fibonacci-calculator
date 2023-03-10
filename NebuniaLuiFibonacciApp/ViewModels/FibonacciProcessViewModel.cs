using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NebuniaLuiFibonacci.Core;
using NebuniaLuiFibonacciApp.Properties;
using Prism.Commands;

namespace NebuniaLuiFibonacciApp
{
    public class FibonacciProcessViewModel: FormViewModelBase
    {
        public FibonacciProcessViewModel()
        {
            
        }

        private int? firstTerm;
        private int? secondTerm;

        [Required]
        [ValidInteger]
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
        [ValidInteger]
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
        public ProcessorType Type { get; set; } = ProcessorType.Task;

    }
}
