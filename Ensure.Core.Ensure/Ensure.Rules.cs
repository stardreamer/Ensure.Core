using System;
using System.IO;


namespace Ensure.Core.Ensure
{
    /// <summary>
    /// This class Ensures that requested conditions are satisfied
    /// </summary>
    public static partial class Ensure
    {       
        /// <summary>
        /// This function ensures that input value is positive
        /// </summary>
        /// <param name="valueName">Name of the variable being checked.</param>
        /// <param name="value">Actual value of the variable being checked.</param>
        /// <param name="parentType">Type of the class which contains the variable as property.</param>
        /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when value is nonpositive</exception> 
        public static void IsPositive(string valueName, double value, Type parentType = null)
        {
            PerformEnsureCheck(valueName, value, (v) => v > 0, "Must be positive", parentType);
        }

        /// <summary>
        /// This function ensures that input value is negative
        /// </summary>
        /// <param name="valueName">Name of the variable being checked.</param>
        /// <param name="value">Actual value of the variable being checked.</param>
        /// <param name="parentType">Type of the class which contains the variable as property.</param>
        /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when value is nonnegative</exception> 
        public static void IsNegative(string valueName, double value, Type parentType = null)
        {
            PerformEnsureCheck(valueName, value, (v) => v < 0, "Must be negative", parentType);
        }

        /// <summary>
        /// This function ensures that input value is nonnegative
        /// </summary>
        /// <param name="valueName">Name of the variable being checked.</param>
        /// <param name="value">Actual value of the variable being checked.</param>
        /// <param name="parentType">Type of the class which contains the variable as property.</param>
        /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when value is negative</exception> 
        public static void IsNonNegative(string valueName, double value, Type parentType = null)
        {
            PerformEnsureCheck(valueName, value, (v) => v >= 0, "Must be nonnegative", parentType);
        }

        /// <summary>
        /// This function ensures that input value is nonpositive
        /// </summary>
        /// <param name="valueName">Name of the variable being checked.</param>
        /// <param name="value">Actual value of the variable being checked.</param>
        /// <param name="parentType">Type of the class which contains the variable as property.</param>
        /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when value is positive</exception> 
        public static void IsNonPositive(string valueName, double value, Type parentType = null)
        {
            PerformEnsureCheck(valueName, value, (v) => v < 0, "Must be nonpositive", parentType);
        }

        /// <summary>
        /// This function ensures that the input string is not null or empty
        /// </summary>
        /// <param name="valueName">Name of the variable being checked.</param>
        /// <param name="value">Actual value of the variable being checked.</param>
        /// <param name="parentType">Type of the class which contains the variable as property.</param>
        /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when input string is null or empty</exception> 
        public static void IsNotNullOrEmpty(string valueName, string value, Type parentType = null)
        {
            PerformEnsureCheck(valueName, value, (v) => !string.IsNullOrEmpty(value), "String must not be null or empty", parentType);
        }

        /// <summary>
        /// This function ensures that the input file exists
        /// </summary>
        /// <param name="valueName">Name of the variable being checked.</param>
        /// <param name="value">Actual value of the variable being checked.</param>
        /// <param name="parentType">Type of the class which contains the variable as property.</param>
        /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when input file does not exists</exception> 
        public static void FileExists(string valueName, string value, Type parentType = null)
        {
            PerformEnsureCheck(valueName, value, (v) => File.Exists(value), "File must exist", parentType);
        }

        /// <summary>
        /// This function ensures that the input variable is not null
        /// </summary>
        /// <param name="valueName">Name of the variable being checked.</param>
        /// <param name="value">Actual value of the variable being checked.</param>
        /// <param name="parentType">Type of the class which contains the variable as property.</param>
        /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when input variable is null</exception> 
        public static void IsNotNull<T>(string valueName, T value, Type parentType = null) where T : class
        {
            PerformEnsureCheck(valueName, value, (v) => v != null, "Variable must not be null", parentType);
        }
    }
}
