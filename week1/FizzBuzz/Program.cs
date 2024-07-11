class Program
{
    public static void Main(string[] args)
    {
        // play FizzBuzz
        // As a user, I want to play Fizz Buzz from 1 to 20
        // Count from lower to upper numbers, printing each one to it's own line
        // When we play Fizz Buzz I want multiples of 3 to be replaced with Fizz
        // When a multiple of 5 replace it with Buzz
        // When a multiple of both 3 and 5 replace with FizzBuzz
        // When a multiple of 7 replace with Bang
        // When a multiple of 3 and 7 replace with FizzBang
        // When a multiple of 5 and 7 replace with BuzzBang
        // When a multiple of 3, 5, and 7 replace with FizzBuzzBang


        // int fizzNum = 2;
        // int buzzNum = 5;
        // int bangNum = 7;
        // int crackNum = 9;


        Dictionary<int, string> wordVals = new Dictionary<int, string>();
        wordVals.Add(2, "Fizz");
        wordVals.Add(3,"Bug");
        wordVals.Add(5, "Buzz");
        wordVals.Add(7, "Bang");
        wordVals.Add(9, "Crack");

        int startNum = 1;
        int endNum = 21;

        for (int i = startNum; i <= endNum; i++)
        {
            Console.WriteLine(FizzBuzzBuilder(wordVals, i));
        }
    }

    public static string FizzBuzzBuilder(Dictionary<int, string> wordVals, int i)
    {
        string output = "";
        foreach (KeyValuePair<int, string> val in wordVals)
        {
            if (i % val.Key == 0)
            {
                output += val.Value;
            }
        }

        if (string.IsNullOrEmpty(output))
        {
            output += i.ToString();
        }
        return output;
    }
}