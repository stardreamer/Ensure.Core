# v0.0.3
[Feature]
1. Directory checks were added
[Bugfix]
1. Multiple enumeration of IEnumerable were fixed
# v0.0.2
 [Features]
1. Contexts for ensure checks were added [Issue 11](https://github.com/stardreamer/Ensure.Core/issues/11)
1. Checks for collections were added in their own context [Issue 1](https://github.com/stardreamer/Ensure.Core/issues/1)
1. Checks for the emptiness of the files were added in File context [Issue 2](https://github.com/stardreamer/Ensure.Core/issues/2)
1. It is now became possible to inject user exceptions in user's checks [Issue 13](https://github.com/stardreamer/Ensure.Core/issues/13)
# v0.0.2-alpha3
[Fix]
1. Fixed wrong condition for IsNonPositive check. Zero value was not passing old check

[Misc]
1. More test examples were added
# v0.0.2-alpha2
[Features]
1. Following validation checks were added:
    * `SatisfiesCondition` - checks if the input value does satisfy the specified condition
# v0.0.2-alpha1
[Features]
1. The ability to pass custom error messages to ensure checks was added
1. Following validation checks were added:
    * `IsEmpty` - cheks if the input collection is empty
    * `IsNotEmpty` - checks if the input colletion is not empty 
# v0.0.1-alpha1
[Feature] Following validation checks were added:
* `IsPositive` - checks if the input value is positive
* `IsNegative` - checks if the input value is negative
* `IsNonNegative` - checks if the input value is non negative
* `IsNonPositive` - checks if the input value is non positive
* `IsNotNullOrEmpty` - checks if the input string is not null or empty
* `FileExists` - ensure that input file exists
* `IsNotNull` - ensure that input object is not null
