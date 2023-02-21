using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebuniaLuiFibonacciApp
{
    //Required Validation only seems to Trigger after the field is first edited.
    //We will use this custom validation attribute to make sure that users cannot submit null values
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    sealed public class ValidIntegerAttribute : ValidationAttribute
    {
        public ValidIntegerAttribute() : base()
        {
        }
        public override bool IsValid(object? value)
        {
            if (value == null || (!(value is int) && !int.TryParse(value.ToString(), out int _)))
                return false;

            return true;
        }
    }
}
