using System;
using System.Linq;

namespace Ensure.Core.Ensure
{
    public static partial class Ensure
    {
        public static class Directory
        {
            /// <summary>
            /// This function ensures that the input directory exists
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="EnsureException">Thrown when input directory does not exists</exception> 
            public static void Exists(string valueName, string value, string customMessage = null, Type parentType = null)
            {
                PerformEnsureCheck(valueName, value, (v) => System.IO.Directory.Exists(value), customMessage ?? "Directory must exist", parentType);
            }
            
            /// <summary>
            /// This function ensures that the input directory is not empty
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="EnsureException">Thrown when input directory is emptys</exception> 
            public static void IsNotEmpty(string valueName, string value, string customMessage = null, Type parentType = null)
            {
                PerformEnsureCheck(valueName, value, (v) => System.IO.Directory.EnumerateFileSystemEntries(value).Any(), customMessage ?? "Directory must be not empty!", parentType);
            }
            
            /// <summary>
            /// This function ensures that the input is empty
            /// </summary>
            /// <param name="valueName">Name of the variable being checked.</param>
            /// <param name="value">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="EnsureException">Thrown when input directory is not empty</exception> 
            public static void IsEmpty(string valueName, string value, string customMessage = null, Type parentType = null)
            {
                PerformEnsureCheck(valueName, value, (v) => !System.IO.Directory.EnumerateFileSystemEntries(value).Any(), customMessage ?? "Directory must be empty!", parentType);
            }
        }
    }
}