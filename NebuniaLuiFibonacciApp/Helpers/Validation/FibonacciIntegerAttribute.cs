using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacciApp
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    sealed public class FibonacciIntegerAttribute : ValidationAttribute
    {
        public FibonacciIntegerAttribute() : base()
        {
            
        }
        public override bool IsValid(object? value)
        {
            if (value == null || (!(value is int) && !int.TryParse(value.ToString(), out int _)))
                return false;

            return true;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            return new ValidationResult("Something went wrong");
        }
    }
}
