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
        public static class File
        {
            /// <summary>
            /// This function ensures that the input file exists
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when input file does not exists</exception> 
            public static void Exists(string valueName, string value, string customMessage = null, Type parentType = null)
            {
                PerformEnsureCheck(valueName, value, (v) => System.IO.File.Exists(value), customMessage ?? "File must exist", parentType);
            }

            /// <summary>
            /// This function ensures that the input file is not empty
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when input file is empty</exception> 
            public static void IsNotEmpty(string valueName, string value, string customMessage = null, Type parentType = null)
            {
                PerformEnsureCheck(valueName, value, (v) => System.IO.File.ReadLines(value).Any(), customMessage ?? "File must not be empty", parentType);
            }

            /// <summary>
            /// This function ensures that the input file is not empty
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when input file is not empty</exception> 
            public static void IsEmpty(string valueName, string value, string customMessage = null, Type parentType = null)
            {
                PerformEnsureCheck(valueName, value, (v) => !System.IO.File.ReadLines(value).Any(), customMessage ?? "File must not empty", parentType);
            }

            /// <summary>
            /// This function ensures that the input file does not contain blank or empty lines
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when the input file contains blank or empty lines</exception> 
            public static void DoesNotContainBlankLines(string valueName, string value, string customMessage = null, Type parentType = null)
            {
                PerformEnsureCheck(valueName, value, (v) => System.IO.File.ReadLines(value).Count(string.IsNullOrWhiteSpace) == 0, customMessage ?? "File must not contain black or empty lines", parentType);
            }
        }
    }
}