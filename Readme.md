# Ensure.Core

This project is inspired by [Ensure.That](https://github.com/danielwertheim/Ensure.That) developed by [Daniel Wertheim](https://github.com/danielwertheim).

It is also available as a nuget package [Ensure.Core](https://www.nuget.org/packages/Ensure.Core/).
# Examples of usage

This won't throw any exception
```csharp
try
{
    var a = 11;
    Ensure.IsPositive(nameof(a), a);
}
catch(EnsureException e)
{

}
```

This will throw an exception
```csharp
try
{
    var a = 11;
    Ensure.IsNegative(nameof(a), a);
}
catch(EnsureException e)
{

}
```

Assume for example you have a class
```csharp
public class TestClass
{
    [Description("Generic description")]
    public int TestVar {get; set;}
}
```

In that case next piece of code will produce an instance of `EnsureException` with the following exception message: `There is a problem with variable TestVar(Generic description)! Must be positive! Current value -11!`
```csharp
try
{
    var testObj = new TestClass
    {
        TestVar = -11;
    }

    Ensure.IsNegative(nameof(testObj), testObj, typeof(TestClass));
}
catch(EnsureException e)
{

}
```

# Available checks

* `IsPositive` - checks if the input value is positive
* `IsNegative` - checks if the input value is negative
* `IsNonNegative` - checks if the input value is non negative
* `IsNonPositive` - checks if the input value is non positive
* `IsNotNullOrEmpty` - checks if the input string is not null or empty
* `FileExists` - ensure that input file exists
* `IsNotNull` - ensure that input object is not null
* `IsEmpty` - cheks if the input collection is empty
* `IsNotEmpty` - checks if the input colletion is not empty
* `SatisfiesCondition` - checks if the input value does satisfy the specified condition