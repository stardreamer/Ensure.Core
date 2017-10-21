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