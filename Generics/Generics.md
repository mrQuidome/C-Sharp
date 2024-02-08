# Generics

Generics are a powerful feature in modern programming languages like C#, enabling developers to create flexible, reusable, and type-safe components. 

## What are Generics?

Generics allow you to define classes, interfaces, and methods with placeholders for the types they operate on. This means you can create a class or method that can work with any data type without losing the safety and performance of statically typed languages.

## Benefits of Using Generics

1. **Type Safety**: Generics provide compile-time type checking. You avoid runtime errors related to typecasting, as you work with specific types rather than using the generic `object` type.
2. **Reusability**: With generics, you can write code that works with any data type, making your libraries and applications more versatile.
3. **Performance**: Using generics can result in better performance. You avoid boxing and unboxing when dealing with value types, which can save computational resources.

## Defining Generic Classes

A generic class can be defined by specifying a type parameter in angle brackets after the class name:

```
csharpCopy codepublic class GenericList<T>
{
    public void Add(T input) { }
}
```

Here, `T` is a placeholder for the type that the `GenericList` class will contain. You can instantiate this class with any type:

```
csharpCopy codevar list = new GenericList<int>();
list.Add(1);
```

## Generic Methods

Methods can also be generic, defined within both non-generic and generic classes:

```
csharpCopy codepublic void Print<T>(T toPrint)
{
    Console.WriteLine(toPrint);
}
```

You can call this method with any type, and the compiler will infer the type based on the argument passed:

```
csharpCopy codePrint(1); // Prints an integer
Print("Hello"); // Prints a string
```

## Constraints on Type Parameters

Constraints can be applied to type parameters to specify what types are allowed. For example, you might require that a type parameter implements a particular interface:

```
csharpCopy codepublic class GenericClass<T> where T : IComparable
{
    // T must implement IComparable interface
}
```

This ensures that the `GenericClass` can only be instantiated with types that implement the `IComparable` interface, providing compile-time type safety.

## Default Values in Generics

- **Types & Methods**: When you define a generic type or method, you may not know what specific types will be used with that generic at compile time. The `default` keyword allows you to obtain the default value for whatever type `T` happens to be when the generic is instantiated. For reference types, the default value is `null`; for value types (such as `int`, `float`, etc.), the default value is zero or the equivalent neutral value (e.g., `false` for `bool`).

### Using `default` with Generics

Here's an example of using `default` in a generic method:

```
csharpCopy codepublic T CreateDefaultInstance<T>()
{
    return default(T);
}
```

In this method, `default(T)` will return `null` if `T` is a reference type, or a zero-equivalent value if `T` is a value type.

### Default Keyword Enhancements

Starting with C# 7.1, you can use the `default` keyword without specifying the type when it can be inferred by the compiler. For example:

```
csharpCopy code
int number = default; // Equivalent to int number = 0;
```

This enhancement simplifies the syntax for obtaining default values, especially within the context of generics.

## Variance in Generics

Variance keywords (`in`, `out`) allow you to specify more flexible relationships between generic types, particularly useful in interfaces and delegates:

- **Covariance (`out`)**: Enables a method to return a more derived type than specified by the generic parameter.
- **Contravariance (`in`)**: Allows a method to accept parameters of a less derived type than specified by the generic parameter.

## Practical Examples

Generics are widely used in the .NET Framework, with collections in the `System.Collections.Generic` namespace being common examples:

- `List<T>`, `Dictionary<TKey, TValue>`, and others provide type-safe collection classes.
- LINQ uses generics extensively to work with sequences of any type.

## Conclusion

Generics are a fundamental concept in C#, essential for writing type-safe, efficient, and reusable code. By understanding and applying generics, you can take full advantage of the type safety and performance optimizations that the C# language offers.