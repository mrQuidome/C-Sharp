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