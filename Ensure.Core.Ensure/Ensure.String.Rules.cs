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
        public static class String
        {
            /// <summary>
            /// This function ensures that the input string is not null or empty
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="EnsureException">Thrown when input string is null or empty</exception> 
            public static void IsNotNullOrEmpty(string valueName, string value, string customMessage = null, Type parentType = null)
            {
                PerformEnsureCheck(valueName, value, (v) => !string.IsNullOrEmpty(value), customMessage ?? "String must not be null or empty", parentType);
            }

            /// <summary>
            /// This function ensures that the input string is not null
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="EnsureException">Thrown when input string is null or empty</exception> 
            public static void IsNotNull(string valueName, string value, string customMessage = null, Type parentType = null)
            {
                PerformEnsureCheck(valueName, value, (v) => value != null, customMessage ?? "String must not be null", parentType);
            }

            /// <summary>
            /// This function ensures that the input string is null
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="EnsureException">Thrown when input string is not null</exception> 
            public static void IsNull(string valueName, string value, string customMessage = null, Type parentType = null)
            {
                PerformEnsureCheck(valueName, value, (v) => value == null, customMessage ?? "String must not be null", parentType);
            }

            /// <summary>
            /// This function ensures that the input string is not empty
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="EnsureException">Thrown when input string is empty</exception> 
            public static void IsNotEmpty(string valueName, string value, string customMessage = null, Type parentType = null)
            {
                PerformEnsureCheck(valueName, value, (v) => value.Any(), customMessage ?? "String must not be null", parentType);
            }

            /// <summary>
            /// This function ensures that the input string is empty
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="EnsureException">Thrown when input string is not empty</exception> 
            public static void IsEmpty(string valueName, string value, string customMessage = null, Type parentType = null)
            {
                PerformEnsureCheck(valueName, value, (v) => !value.Any(), customMessage ?? "String must not be null", parentType);
            }

        }
        
    }
}