# Iterators

Iterators in C# are powerful constructs used to simplify the process of iterating over collections, like arrays or lists. They allow developers to write code that can iterate through items in a collection one at a time, while abstracting away the complexity of tracking the current position within the collection. This primer will introduce the key concepts and usage patterns of iterators in C#, including how to implement and use them.

## Understanding Iterators

An iterator in C# is a method, get accessor, or operator that enables you to use the `foreach` loop to iterate through a collection. Under the hood, iterators leverage the `IEnumerable` and `IEnumerator` interfaces to traverse a collection.

- **`IEnumerable` Interface**: Represents a collection of objects that can be iterated over. The `IEnumerable` interface contains a single method, `GetEnumerator`, which returns an `IEnumerator` object.
- **`IEnumerator` Interface**: Provides the ability to iterate through the collection by exposing the `Current` property, which gets the current element in the collection, and the `MoveNext` method, which advances the enumerator to the next element of the collection.

## How to Implement Iterators

Iterators are typically implemented using iterator methods or get accessors. These are special methods that use the `yield return` statement to return each element one at a time.

## Iterator Method Example

Here's a simple example of an iterator method in a class:

```C#
using System;
using System.Collections.Generic;

public class Numbers
{
    public IEnumerable<int> GetNumbers()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return i;
        }
    }
}
```

In this example, `GetNumbers` is an iterator method that returns each number from 0 to 9, one at a time. The `yield return` statement is used to return each element to the caller.

## Using Iterators

To use an iterator, you typically use a `foreach` loop, which automatically calls the `GetEnumerator` method of the `IEnumerable` interface, iterates through the collection, and disposes of the enumerator when it's no longer needed.

```C#
var numbers = new Numbers();
foreach (int number in numbers.GetNumbers())
{
    Console.WriteLine(number);
}
```

## Benefits of Using Iterators

- **Simplicity**: Iterators simplify the process of iterating over collections by abstracting the details of how the iteration is performed.
- **Lazy Execution**: Iterators do not execute until the `foreach` loop begins, and they process elements one at a time, which can improve performance and reduce memory usage for large collections.
- **Custom Iteration**: You can easily implement custom iteration logic (e.g., filtering or transforming elements) by writing an iterator method.

## Advanced Usage

Iterators can be more advanced, supporting scenarios like iterating over a binary tree, performing complex calculations lazily, or integrating with `async` and `await` for asynchronous enumeration with `IAsyncEnumerable<T>`.