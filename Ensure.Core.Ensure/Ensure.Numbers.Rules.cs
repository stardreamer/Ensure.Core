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
        /// This class Ensures that requested conditions are satisfied for input numerical colletion
        /// </summary>
        public static class Numbers
        {
            /// <summary>
            /// This function ensures that input value is positive
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="EnsureException">Thrown if not all values are positive</exception> 
            public static void ArePositive(string valueName, IEnumerable<double> values, string customMessage = null, Type parentType = null) 
            {
                foreach (var value in values)
                {
                    Ensure.Number.IsPositive(valueName, value, customMessage, parentType);
                }
            }

            /// <summary>
            /// This function ensures that input value is negative
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="EnsureException">Thrown if not all values are negative</exception> 
            public static void AreNegative(string valueName, IEnumerable<double>  values, string customMessage = null, Type parentType = null) 
            {
                foreach (var value in values)
                {
                    Ensure.Number.IsNegative(valueName, value, customMessage, parentType);
                }
            }

            /// <summary>
            /// This function ensures that input value is nonnegative
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="EnsureException">Thrown if not all values are nonnegative</exception> 
            public static void AreNonNegative(string valueName, IEnumerable<double>  values, string customMessage = null, Type parentType = null) 
            {
                foreach (var value in values)
                {
                    Ensure.Number.IsNonNegative(valueName, value, customMessage, parentType);
                }
            }

            /// <summary>
            /// This function ensures that input value is nonpositive
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="EnsureException">Thrown if not all values are nonpositive</exception> 
            public static void AreNonPositive(string valueName, IEnumerable<double>  values, string customMessage = null, Type parentType = null) 
            {
                foreach (var value in values)
                {
                    Ensure.Number.IsNonPositive(valueName, value, customMessage, parentType);
                }
            }

            /// <summary>
            /// This function ensures that input value is nonpositive
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="EnsureException">Thrown if not all values are odd</exception> 
            public static void AreOdd(string valueName, IEnumerable<int> values, string customMessage = null, Type parentType = null)
            {
                foreach (var value in values)
                {
                    Ensure.Number.IsOdd(valueName, value, customMessage, parentType);
                }
            }

            /// <summary>
            /// This function ensures that input value is nonpositive
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="EnsureException">Thrown if not all values are even</exception> 
            public static void AreEven(string valueName, IEnumerable<int> values, string customMessage = null, Type parentType = null)
            {
                foreach (var value in values)
                {
                    Ensure.Number.IsEven(valueName, value, customMessage, parentType);
                }
            }
        }
    }
}