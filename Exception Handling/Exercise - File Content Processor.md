## File Content Processor

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