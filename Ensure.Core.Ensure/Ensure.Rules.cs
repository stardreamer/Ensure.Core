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
            PerformEnsureCheck(valueName, value, (v) => v < 0, customMessage ?? "Must be nonpositive", parentType);
        }

        /// <summary>
        /// This function ensures that the input string is not null or empty
        /// </summary>
        /// <param name="valueName">Name of the variable being checked.</param>
        /// <param name="value">Actual value of the variable being checked.</param>
        /// <param name="customMessage">Custom validation ErrorMessage.</param>
        /// <param name="parentType">Type of the class which contains the variable as property.</param>
        /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when input string is null or empty</exception> 
        public static void IsNotNullOrEmpty(string valueName, string value, string customMessage = null, Type parentType = null)
        {
            PerformEnsureCheck(valueName, value, (v) => !string.IsNullOrEmpty(value), customMessage ?? "String must not be null or empty", parentType);
        }

        /// <summary>
        /// This function ensures that the input file exists
        /// </summary>
        /// <param name="valueName">Name of the variable being checked.</param>
        /// <param name="value">Actual value of the variable being checked.</param>
        /// <param name="customMessage">Custom validation ErrorMessage.</param>
        /// <param name="parentType">Type of the class which contains the variable as property.</param>
        /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when input file does not exists</exception> 
        public static void FileExists(string valueName, string value, string customMessage = null, Type parentType = null)
        {
            PerformEnsureCheck(valueName, value, (v) => File.Exists(value), customMessage ?? "File must exist", parentType);
        }

        /// <summary>
        /// This function ensures that the input variable is not null
        /// </summary>
        /// <param name="valueName">Name of the variable being checked.</param>
        /// <param name="value">Actual value of the variable being checked.</param>
        /// <param name="customMessage">Custom validation ErrorMessage.</param>
        /// <param name="parentType">Type of the class which contains the variable as property.</param>
        /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when input variable is null</exception> 
        public static void IsNotNull<T>(string valueName, T value, string customMessage = null, Type parentType = null) where T : class
        {
            PerformEnsureCheck(valueName, value, (v) => v != null, customMessage ?? "Variable must not be null", parentType);
        }

        /// <summary>
        /// This function ensures that the input collection is not Empty
        /// </summary>
        /// <param name="collectionName">Name of the variable being checked.</param>
        /// <param name="collection">Actual value of the variable being checked.</param>
        /// <param name="customMessage">Custom validation ErrorMessage.</param>
        /// <param name="parentType">Type of the class which contains the variable as property.</param>
        /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when input variable is null</exception> 
        public static void IsNotEmpty<T>(string collectionName, IEnumerable<T> collection, string customMessage = null, Type parentType = null)
        {
            PerformEnsureCheck(collectionName, collection, (v) => v.Any(), customMessage ?? "Collection must not be empty", parentType);
        }

                /// <summary>
        /// This function ensures that the input collection is not Empty
        /// </summary>
        /// <param name="collectionName">Name of the variable being checked.</param>
        /// <param name="collection">Actual value of the variable being checked.</param>
        /// <param name="customMessage">Custom validation ErrorMessage.</param>
        /// <param name="parentType">Type of the class which contains the variable as property.</param>
        /// <exception cref="TextGameFramework.Ensure.EnsureException">Thrown when input variable is null</exception> 
        public static void IsEmpty<T>(string collectionName, IEnumerable<T> collection, string customMessage = null, Type parentType = null)
        {
            PerformEnsureCheck(collectionName, collection, (v) => !v.Any(), customMessage ?? "Collection must be empty", parentType);
        }
    }
}
