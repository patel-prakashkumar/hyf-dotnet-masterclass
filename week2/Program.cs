var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "This is dotnet week2 Assignment");

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
