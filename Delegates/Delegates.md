# Delegates

Delegate inference in C# is a feature that simplifies the process of assigning methods to delegates. It allows the C# compiler to infer the delegate type from the method assigned to it, making the code cleaner and more readable. Before diving into delegate inference, let's understand some basics about delegates in C#.

## Interface-based Callbacks

Instead of using delegates, you can define an interface with a method signature that matches the callback's requirements. Any class that implements this interface can then be used as a callback.

### Example

```C#
public interface ICallback
{
    void CallbackMethod();
}

public class CallbackImplementer : ICallback
{
    public void CallbackMethod()
    {
        Console.WriteLine("Callback method called.");
    }
}

public class Processor
{
    public void Process(ICallback callback)
    {
        // Some processing logic here
        callback.CallbackMethod();
    }
}

// Usage
var processor = new Processor();
var callbackImplementer = new CallbackImplementer();
processor.Process(callbackImplementer);
```

## What is a Delegate?

A delegate is a type that safely encapsulates a method, similar to a function pointer in C or C++. However, unlike function pointers, delegates are object-oriented, type-safe, and secure. Delegates can be used to pass methods as arguments, define callback methods, and implement event handlers.

## Basic Syntax of Delegates

Here's how you define and use a delegate:

```
// Define a delegate
public delegate void MyDelegate(string message);

// Method that matches the delegate signature
public void ShowMessage(string message)
{
    Console.WriteLine(message);
}

// Assigning the method to the delegate
MyDelegate del = new MyDelegate(ShowMessage);

// Invoking the delegate
del("Hello, World!");
```

## Delegate Inference

Delegate inference allows you to assign methods to delegates without explicitly instantiating the delegate with the `new` keyword. The compiler automatically infers the delegate type based on the method signature. This simplifies the delegate assignment as follows:

```C#
// With delegate inference
MyDelegate del = ShowMessage;

// Invoking the delegate remains the same
del("Hello, World!");
```

## How Delegate Inference Works

When you assign a method to a delegate type, the C# compiler automatically creates a delegate instance pointing to that method, provided the method signature matches the delegate's signature. This removes the need for the explicit delegate instantiation, making the code more concise.

## Advantages of Delegate Inference

- **Simplicity**: It makes delegate assignment simpler and code more readable.
- **Maintainability**: Less boilerplate code means it's easier to maintain and understand.
- **Type Safety**: Delegate inference doesn't compromise on type safety. The compiler ensures that the method signature matches the delegate's signature.

## Using Delegate Inference with Anonymous Methods and Lambda Expressions

Delegate inference is particularly useful when working with anonymous methods and lambda expressions, allowing for even more concise code:

```C#
// Assigning an anonymous method to the delegate
MyDelegate del1 = delegate(string message) {
    Console.WriteLine(message);
};

// Assigning a lambda expression to the delegate
MyDelegate del2 = (message) => Console.WriteLine(message);
```

In these examples, the compiler infers the delegate type from the context, enabling you to write less verbose and more readable code.

## Exercise: Number Processor with Delegates

**Objective:** Create a console application that processes a list of numbers with different operations (e.g., finding the sum, maximum, and average) using delegates.

**Deliverables:**

1. A console application that defines and uses the `NumberProcessor` delegate.
2. Implementation of sum, maximum, and average calculations.
3. Usage of anonymous methods or lambda expressions as an alternative approach.

This exercise will give you hands-on experience with delegates, including defining, instantiating, and using them, as well as replacing explicit method definitions with anonymous methods or lambda expressions for more concise and flexible code.

**Step 1: Define the Delegate**

Start by defining a delegate that represents a function capable of processing a list of integers and returning a result as a double.

```C#
public delegate double NumberProcessor(List<int> numbers);
```

**Step 2: Implement Different Operations**

Implement three methods that match the `NumberProcessor` delegate signature:

- **Sum**: Calculates the sum of all numbers in the list.
- **Maximum**: Finds the maximum number in the list.
- **Average**: Calculates the average of the numbers in the list.

```C#
public static double Sum(List<int> numbers) => numbers.Sum();

public static double Maximum(List<int> numbers) => numbers.Max();

public static double Average(List<int> numbers) => numbers.Average();
```

**Step 3: Process Numbers Using a Delegate**

In your `Main` method, create a `List<int>` and populate it with some integers. Then, create instances of the `NumberProcessor` delegate for each operation and use them to process the list.

```C#
static void Main(string[] args)
{
    List<int> numbers = new List<int> { 1, 3, 5, 7, 9 };

    NumberProcessor processorSum = new NumberProcessor(Sum);
    NumberProcessor processorMax = new NumberProcessor(Maximum);
    NumberProcessor processorAvg = new NumberProcessor(Average);

    Console.WriteLine($"Sum: {processorSum(numbers)}");
    Console.WriteLine($"Maximum: {processorMax(numbers)}");
    Console.WriteLine($"Average: {processorAvg(numbers)}");
}
```

**Step 4: Adding Flexibility with Anonymous Methods or Lambdas**

Modify your application to use anonymous methods or lambda expressions instead of explicitly defining methods for sum, maximum, and average. Assign these to your delegates and execute them.

Example with a lambda for the sum:

```C#
NumberProcessor processorSum = numbers => numbers.Sum();
```

Repeat this for the maximum and average calculations.



