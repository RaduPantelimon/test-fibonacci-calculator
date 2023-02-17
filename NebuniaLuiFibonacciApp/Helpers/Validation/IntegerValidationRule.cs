using NebuniaLuiFibonacciApp.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NebuniaLuiFibonacciApp
{
    public class IntegerValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null ||
                (!(value is int) && !int.TryParse(value.ToString(), out int _)))

                return new ValidationResult(false, Resources.ErrorMessage_InvalidIntValue);

            return ValidationResult.ValidResult;
        }
    }
}
