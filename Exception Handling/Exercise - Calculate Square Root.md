## Calculate Square Root

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