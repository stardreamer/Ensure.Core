using System;
using System.ComponentModel;
using System.Linq;

namespace Ensure.Core.Ensure
{
    public static partial class Ensure
    {
        private static string GetDescriptionFromType(string valueName, Type parentType)
        {
            var property = parentType.GetProperty(valueName);
            if (property == null)
                return null;

            var descriptions = property.GetCustomAttributes(typeof(DescriptionAttribute), true);
            return !descriptions.Any() ? null : (descriptions[0] as DescriptionAttribute)?.Description;
        }

        private static void ThrowEnsureException<T>(string valueName, T value, string validationProblem, Type parentType = null, Exception userException = null)
        {
            if(parentType == null)
            {
                if(userException == null)
                    throw new EnsureException($"There is a problem with variable {valueName}! {validationProblem}! Current value {value}!");
                
                throw new EnsureException("Error", userException);
            }
            
            var description = GetDescriptionFromType(valueName, parentType);

            if(userException == null)
                throw new EnsureException($"There is a problem with variable {valueName}({description})! {validationProblem}! Current value {value}!");
            
            throw new EnsureException($"Error with {description}", userException);
        }

        private static void PerformEnsureCheck<T>(string valueName, T value, Func<T,bool> condition, string valueProblem, Type parentType = null, Exception userException = null)
        {
            if(condition(value))
                return;    
            ThrowEnsureException(valueName, value, valueProblem, parentType, userException);
        }
    }
}