# Exception Handling

## Theory

Exception handling is a critical aspect of writing robust and reliable software in C#. It enables a program to respond gracefully to unexpected runtime errors. The core of exception handling in C# revolves around four key keywords: `try`, `catch`, `finally`, and `throw`.

### Understanding Exceptions

An exception is an event that occurs during the execution of a program and disrupts the normal flow of instructions. In C#, exceptions are instances of classes that derive from the `System.Exception` class. When an error occurs within a method, the system creates an exception object and throws it. If the exception is not caught and handled, the program will terminate abruptly.

### The `try` Block

The `try` block is used to wrap code that might throw an exception. It defines a scope for one or more operations that may result in an exception. The syntax is straightforward:

```
try
{
    // Code that may throw an exception
}
```

### The `catch` Block

When an exception is thrown, the Common Language Runtime (CLR) looks for the `catch` block that can handle the exception. If a suitable `catch` block is found, the CLR passes control to that block, along with the exception object. You can have multiple `catch` blocks to handle different types of exceptions specifically:

```
try
{
    // Code that may throw an exception
}
catch (SpecificExceptionType ex)
{
    // Handle this specific type of exception
}
catch (AnotherExceptionType ex)
{
    // Handle a different type of exception
}
catch
{
    // Handle any exception that wasn't handled by the preceding blocks
}
```

### The `finally` Block

The `finally` block is optional and used for code that must be executed whether or not an exception is thrown. This is typically used for cleaning up resources, like closing files or network connections, regardless of whether the operation succeeded:

```
try
{
    // Code that may throw an exception
}
catch (Exception ex)
{
    // Handle exception
}
finally
{
    // Code that executes after the try/catch blocks, regardless of whether an exception was thrown
}
```

### Throwing Exceptions

You can throw an exception using the `throw` statement. This is useful for signaling that an error condition has occurred, often in response to some invalid condition:

```
if (someInvalidCondition)
{
    throw new Exception("Description of the error");
}
```

To rethrow an exception in a `catch` block (to allow further handling up the call stack), simply use `throw;` without specifying an exception:

```
catch (Exception)
{
    // Possibly log the error or clean up resources
    throw; // Rethrows the caught exception
}
```

### Best Practices

- **Catch specific exceptions**: Always catch the most specific exception types you are prepared to handle, rather than catching the base `Exception` class.
- **Use exceptions for exceptional conditions**: Exceptions should be used for errors that cannot be predicted or controlled by the program. (C# traditionally leans more towards the LBYL approach, but it can support EAFP-like patterns to some extent)
- **Avoid empty catch blocks**: Catching an exception and doing nothing hides the error, making debugging difficult.
- **Resource cleanup**: Utilize the `finally` block or the `using` statement to ensure resources are properly cleaned up.
- **Throw meaningful exceptions**: Provide clear, descriptive messages with exceptions to aid in debugging.

Exception handling in C# is a powerful mechanism for dealing with runtime errors, ensuring that your application can handle unexpected events in a controlled and graceful manner.

## File Read Example

Below is an example of production-ready code for reading from a file in C#, incorporating robust exception handling. This example demonstrates how to safely open, read, and process the contents of a file, along with appropriate error handling and resource cleanup.

```
using System;
using System.IO;

class FileReadExample
{
    public static void ReadFile(string filePath)
    {
        // Check if the file exists before attempting to open it
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        try
        {
            // Open the file for reading
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                // Read and display lines from the file until the end of the file is reached
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            // Handle specific exceptions first
            Console.WriteLine($"Access to the file {filePath} is denied.");
            LogError(ex);
        }
        catch (IOException ex)
        {
            // Handle I/O exceptions
            Console.WriteLine($"An I/O error occurred while reading the file {filePath}.");
            LogError(ex);
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            LogError(ex);
        }
        // The 'finally' block is not needed here because 'using' ensures the file is closed
    }

    private static void LogError(Exception ex)
    {
        // Log the error to a file or error logging service
        // This is a placeholder for actual error logging logic
        Console.WriteLine("Error logged: " + ex.Message);
    }

    static void Main(string[] args)
    {
        string filePath = "path/to/your/file.txt";
        ReadFile(filePath);
    }
}
```

### Key Points

- **File Existence Check**: It checks if the file exists before attempting to open it to avoid unnecessary exceptions.
- **`using` Statement**: Ensures that the `StreamReader` is properly disposed of, closing the file regardless of whether an exception occurs.
- **Specific Exception Handling**: Catches and handles specific exceptions (`UnauthorizedAccessException`, `IOException`) before a more general `Exception` catch block. This allows for more precise error messages and handling.
- **Logging**: Implements a `LogError` method as a placeholder for actual logging logic. In a production environment, you would log errors to a file, database, or error monitoring service.
- **No `finally` Block Needed**: The `using` statement takes care of releasing the file resource, so a `finally` block for cleanup is unnecessary in this case.

This example represents a pattern for reading files that balances error handling and resource management, making it suitable for production environments.

## Exercise: File Content Processor

**Objective**: Write a C# program that reads content from a specified file and processes it. Your program should handle exceptions that may occur during file reading and processing, such as file not found, access denied, and file format errors.

**Requirements**:

1. **File Reading**:
   - Prompt the user to enter the path of a file to process.
   - Read the content of the file line by line.
2. **Content Processing**:
   - The file contains integers, one per line.
   - Parse each line as an integer and compute the sum of all integers in the file.
3. **Exception Handling**:
   - Handle the `FileNotFoundException` to inform the user if the specified file does not exist.
   - Handle `UnauthorizedAccessException` to inform the user if they do not have permission to read the file.
   - Handle `FormatException` for lines that cannot be parsed into integers, skipping over those lines but continuing to process the rest.
   - In case of any other exceptions, display a general error message.
4. **Output**:
   - Print each integer read from the file as it's processed.
   - After processing all lines, print the sum of the integers.
   - Display appropriate error messages for exceptions.

### Instructions

- Implement the program 
- Test your program with different files, including ones that do not exist, contain mixed content (not just integers), and for which you might not have read access.
- Observe how the program handles these different scenarios and refines your exception handling as needed.

This exercise will give you practical experience with exception handling patterns in C#, teaching you how to write resilient and user-friendly applications.

### Solution

```c#
class FileContentProcessor
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the path of the file to process:");
        string filePath = Console.ReadLine();
        try
        {
            ProcessFile(filePath);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: The specified file does not exist.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: Access to the file is denied.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

    private static void ProcessFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException();
        }

        int sum = 0;
        int lineCount = 0;

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                try
                {
                    int number = int.Parse(line);
                    sum += number;
                    lineCount++;
                    Console.WriteLine($"Processed line {lineCount}: {number}");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Warning: Line {lineCount + 1} contains non-integer values and was skipped.");
                }
            }
        }

        Console.WriteLine($"Sum of all processed integers: {sum}");
    }
}
```
## Exercise: Calculate Square Root

**Objective**: Write a C# function named `CalculateSquareRoot` that takes a string representing a number as input and returns its square root. If the input is not a valid number or if it is a negative number (for which the square root would be complex in the real number system), the function should throw an exception.

**Requirements**:

1. **Input Validation**:
   - The input is a string that should represent a non-negative number.
   - If the input string does not represent a valid non-negative number, throw a `FormatException`.
   - If the number is negative, throw an `ArgumentOutOfRangeException` indicating that square roots of negative numbers are not supported.
2. **Calculation**:
   - If the input is valid, calculate and return the square root of the number.
3. **Testing the Function**:
   - Write a `Main` method to test the `CalculateSquareRoot` function with various inputs.
   - Use a try-catch block to catch and display messages for both `FormatException` and `ArgumentOutOfRangeException`.

### Instructions

- Fill in the `CalculateSquareRoot` function to meet the specified requirements.
- Complete the `Main` method to test the function with a set of predefined inputs, capturing and displaying exceptions as specified.
- Ensure your program gracefully handles both valid and invalid inputs, demonstrating effective use of exceptions in error handling.

This exercise will help you practice using exceptions for input validation and error signaling, an essential skill for developing robust applications in C#.

### Solution

```C#
class Program
{
    public static double CalculateSquareRoot(string input)
    {
        double number;
        bool isNumeric = double.TryParse(input, out number);

        if (!isNumeric)
        {
            throw new FormatException("Input must be a valid number.");
        }

        if (number < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(input), "Square roots of negative numbers are not supported.");
        }

        return Math.Sqrt(number);
    }

    static void Main(string[] args)
    {
        string[] testInputs = { "16", "-4", "hello", "25.6", "0" };

        foreach (var input in testInputs)
        {
            try
            {
                double result = CalculateSquareRoot(input);
                Console.WriteLine($"The square root of {input} is {result}.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
```