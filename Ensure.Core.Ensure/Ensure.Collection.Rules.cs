using System;
using System.Collections.Generic;
using System.Linq;

namespace Ensure.Core.Ensure
{
    /// <summary>
    /// This class Ensures that requested conditions are satisfied
    /// </summary>
    public static partial class Ensure
    {
        /// <summary>
        /// This class Ensures that requested conditions are satisfied for the input collection
        /// </summary>
        public static class Collection
        {
            /// <summary>
            /// This function ensures that the input collection is not Empty
            /// </summary>
            /// <param name="collectionName">Name of the variable being checked.</param>
            /// <param name="collection">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="EnsureException">Thrown when input collection is empty</exception> 
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
            /// <exception cref="EnsureException">Thrown when input colletion is not empty</exception> 
            public static void IsEmpty<T>(string collectionName, IEnumerable<T> collection, string customMessage = null, Type parentType = null)
            {
                PerformEnsureCheck(collectionName, collection, (v) => !v.Any(), customMessage ?? "Collection must be empty", parentType);
            }

            /// <summary>
            /// This function ensures that the input collection's elements are unique
            /// </summary>
            /// <param name="collectionName">Name of the variable being checked.</param>
            /// <param name="collection">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="EnsureException">Thrown when input colletion's elements are not unique </exception> 
            public static void Uniqueness<T>(string collectionName, IEnumerable<T> collection, string customMessage = null, Type parentType = null)
            {
                var value = collection as IList<T> ?? collection.ToList();
                PerformEnsureCheck(collectionName, value, (v) =>  
                    {
                        var enumerable = collection as IList<T> ?? value.ToList();
                        var totalRepeatNumber = enumerable.Count - enumerable.Distinct().Count();
                        return totalRepeatNumber == 0;
                    },
                customMessage ?? "Collection elements must be unique", parentType);
            }

            /// <summary>
            /// This function ensures that the dependentEnumerable contains only elements from independentEnumerable
            /// </summary>
            /// <param name="collectionName">Name of the variable being checked.</param>
            /// <param name="collection">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="EnsureException">Thrown when dependentEnumerable contains elements that are not present in independentEnumerable</exception> 
            public static void Coherence<T>(string dependentparameterName, IEnumerable<T> dependentEnumerable, string independentparameterName,
                IEnumerable<T> independentEnumerable)
            {
                var enumerable = dependentEnumerable as IList<T> ?? dependentEnumerable.ToList();
                PerformEnsureCheck(dependentparameterName, enumerable,
                (v) => enumerable.All(independentEnumerable.Contains),
                $"Collection {dependentparameterName} contains elements that are not present in {independentparameterName}");
            }

            /// <summary>
            /// This function ensures that the input colletion contains specified element
            /// </summary>
            /// <param name="collectionName">Name of the variable being checked.</param>
            /// <param name="collection">Actual value of the variable being checked.</param>
            /// <param name="customMessage">Custom validation ErrorMessage.</param>
            /// <param name="parentType">Type of the class which contains the variable as property.</param>
            /// <exception cref="EnsureException">Thrown when the input colletion does not contain specified element</exception> 
            public static void Contains<T>(string collectionName, IEnumerable<T> collection, string valueName, T value, Type parentType = null)
            {
                PerformEnsureCheck(collectionName, collection, (v) => v.Contains(value), $"Collection must contain element {value}", parentType);
            }
        }
    }
}