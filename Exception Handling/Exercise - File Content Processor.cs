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