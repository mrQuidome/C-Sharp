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