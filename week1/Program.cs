var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "This is Week1 Assignment");

// 1. String manipulation

app.MapGet("/stringReversed", (string input) =>
{
    char[] charArray = input.ToCharArray();
    Array.Reverse(charArray);
    string reversed = new string(charArray);
    return $"Reversed String Manipulation value: {reversed}";
     
}
);

// 2. String/Math

app.MapGet("/vowelCount", (string input) => 

{
    int count = 0;
    string vowels = "aeiou";
    foreach (char c in input.ToLower())
    {
        if (vowels.Contains(c))
        {
            count++;
        }
    }
    return $"Total Number of vowels in Sentence: {count}";
});

// 3. Math/Array
app.MapGet("/math", () =>
{
    int[] arr = new[] { 271, -3, 1, 14, -100, 13, 2, 1, -8, -59, -1852, 41, 5 };
    int sumOfNumbers = 0;
    int mulOfNumbers = 1;
    int[] result = new int[2];
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] > 0)
        {
            mulOfNumbers *= arr[i];
        }
        else
        {
            sumOfNumbers += arr[i];
        }
        result[0] = sumOfNumbers;
        result[1] = mulOfNumbers;
    }
    Console.WriteLine($"Sum of negative numbers: {result[0]}. Multiplication of positive numbers: {result[1]}");

    return $"Sum of negative numbers: {result[0]}. Multiplication of positive numbers: {result[1]}";
  
});

// 4. Classical task

app.MapGet("/fibonacciSequence", (int number) =>
{
    int value1 = 0, value2 = 1, fibonacci = 0;
    for (int i = 2; i <= number; i++)
    {
        fibonacci = value1 + value2;
        value1 = value2;
        value2 = fibonacci;
    }
    return $"Nth fibonacci number is {value2}";
});

app.Run();


