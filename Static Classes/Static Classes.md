# Static Classes

Static classes in C# are a fundamental concept that allows developers to create classes that cannot be instantiated. In other words, you cannot use the `new` keyword to create an object of a static class. Static classes are primarily used to hold static members, which belong to the class itself rather than to any specific object. This primer will introduce the key concepts, usage patterns, and guidelines for working with static classes in C#.

## Understanding Static Classes

A static class is defined with the `static` keyword. It can contain static methods, properties, fields, and events. Everything inside a static class must be static, and the class cannot contain instance members or constructors.

## Key Characteristics

- **No Instances**: You cannot create instances of a static class.
- **Static Members Only**: All members of a static class must be static.
- **Cannot Inherit or be Inherited**: Static classes cannot inherit from other classes and cannot be used as base classes.
- **Static Constructor**: A static class can have a static constructor, which is called automatically before the first static member is accessed or a static method is called.

## How to Define a Static Class

Here is a simple example of defining a static class:

```C#
public static class UtilityClass
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int Multiply(int a, int b)
    {
        return a * b;
    }
}
```

In this example, `UtilityClass` is a static class with two static methods: `Add` and `Multiply`. These methods can be called without creating an instance of `UtilityClass`.

## Using Static Classes

To use a static class, you simply call its static members using the class name:

```C#
int sum = UtilityClass.Add(5, 3);
int product = UtilityClass.Multiply(5, 3);
```

### Best Practices and Use Cases

- **Utility Functions**: Static classes are ideal for groups of utility functions that do not require an object state. For example, a math utility class might contain methods for mathematical operations.
- **Extension Methods**: Extension methods must be defined in a static class, making static classes crucial for extending existing types with new methods.
- **Constants and Configuration**: Use static classes to hold application-wide constants or configuration settings that are read-only and do not change.
- **Performance Considerations**: Since static members are tied to the class and not to instances, they can offer performance benefits by not requiring object instantiation. However, the misuse of static classes can lead to issues with code maintainability and testing.

### Limitations

While static classes are useful, they also come with limitations:

- **Testing**: Static members can make unit testing more challenging, as they are not easily mocked or replaced with test doubles.
- **Global State**: Overuse of static members can lead to issues with managing global state and side effects, which can increase the complexity of applications and make them harder to debug.