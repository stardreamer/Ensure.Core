using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ensure.Core.Ensure
{
    /// <summary>
    /// This class Ensures that requested conditions are satisfied
    /// </summary>
    public static partial class Ensure
    {
        /// <summary>
        /// This class Ensures that requested conditions are satisfied for input numerical value
        /// </summary>
        public static class Number
        {
            /// <summary>
            /// This function ensures that input value is positive
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when value is nonpositive</exception> 
            public static void IsPositive(string valueName, double value, string customMessage = null, Type parentType = null)
            {
                PerformEnsureCheck(valueName, value, (v) => v > 0, customMessage ?? "Must be positive", parentType);
            }

            /// <summary>
            /// This function ensures that input value is negative
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when value is nonnegative</exception> 
            public static void IsNegative(string valueName, double value, string customMessage = null, Type parentType = null)
            {
                PerformEnsureCheck(valueName, value, (v) => v < 0, customMessage ?? "Must be negative", parentType);
            }

            /// <summary>
            /// This function ensures that input value is nonnegative
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when value is negative</exception> 
            public static void IsNonNegative(string valueName, double value, string customMessage = null, Type parentType = null)
            {
                PerformEnsureCheck(valueName, value, (v) => v >= 0, customMessage ?? "Must be nonnegative", parentType);
            }

            /// <summary>
            /// This function ensures that input value is nonpositive
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when value is positive</exception> 
            public static void IsNonPositive(string valueName, double value, string customMessage = null, Type parentType = null)
            {
                PerformEnsureCheck(valueName, value, (v) => v <= 0, customMessage ?? "Must be nonpositive", parentType);
            }

            /// <summary>
            /// This function ensures that input value is nonpositive
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when value is not odd</exception> 
            public static void IsOdd(string valueName, int value, string customMessage = null, Type parentType = null)
            {
                PerformEnsureCheck(valueName, value, (v) => v %2 != 0, customMessage ?? "Must be odd", parentType);
            }

            /// <summary>
            /// This function ensures that input value is nonpositive
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when value is not even</exception> 
            public static void IsEven(string valueName, int value, string customMessage = null, Type parentType = null)
            {
                PerformEnsureCheck(valueName, value, (v) => v %2 == 0, customMessage ?? "Must be even", parentType);
            }
        }
    }
}