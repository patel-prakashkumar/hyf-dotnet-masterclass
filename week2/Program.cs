var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "This is dotnet week2 Assignment");

// Calculate Task

app.MapGet("/calculate", (string num1, string num2, string operation) => {
    var number1 = int.TryParse(num1, out int input1);
    var number2 = int.TryParse(num2, out int input2);

    if(!number1 || !number2){
        return Results.BadRequest(new { Error = $"Unable to parse input '{num1}', '{num2}'!" }); 
         }
    var result = 0;
    switch(operation){
        case "add":
            result = input1 + input2;
            break;
         case "substract":
            result = input1 - input2;
            break;
             case "multiply":
            result = input1 * input2;
            break;
        default:
          return Results.BadRequest(new { Error = $"System not supported - please try again"});  
    }
    return Results.Ok(new String($"the result is {result}"));
});

// 2. Count Capital Letters Method example

app.MapGet("/input", (string input) =>
{
     var inputParse = int.TryParse(input, out int value);
     if(inputParse){
            System.Console.WriteLine($"The sum is  {AddNumbers(value)}");
        } else{
            System.Console.WriteLine($"The total uppercase is {CountCapitalLetters(input)}");
        }

    int AddNumbers(int value){
        var sum = 0;
        for (int i = value; i > 0; i = i / 10){
           sum = sum + i % 10; 
        }return sum;
    }

    int CountCapitalLetters(string input){
        var count = 0;
        for (int i = 0; i < input.Length; i++){
            char ch = input[i];
            if(char.IsUpper(ch))
                  count++;
        }
        return count;
    }
});





// Word Frequency Count

app.MapGet("/wordFrequencyCount", () =>
{
    string inputString = "the quick Brown fox jumps over the lazy dog The";
    inputString = inputString.ToLower();
    var Words = inputString.Split(' ');  

    Dictionary<string, int> DuplicateWordCount = new Dictionary<string, int>();
    for (int i = 0; i < Words.Length; i++) 
        if (DuplicateWordCount.ContainsKey(Words[i]))   
        {
            DuplicateWordCount[Words[i]]++;
        }
        else
        {
            DuplicateWordCount[Words[i]] = 1;
        }
    

    return Results.Ok(DuplicateWordCount);


});



app.Run();
