using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace NebuniaLuiFibonacciApp.Helpers
{
    public static class VisualTreeHelpers
    {
        public static T? GetParentOrNull<T>(DependencyObject child) where T : DependencyObject
        {
            if (child == null) return null;

            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            T? parent = parentObject as T;
            if (parent != null) return parent;

            return GetParentOrNull<T>(parentObject);
        }
    }

}
