var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/mealsharing", () => "Meal Sharing Application");


Meal meal = new Meal()
{
    Headline = "Meal sharing",
    ImageUrl = "www.imageurl.com",
    BodyText = "Its Body Text",
    Location = "Copenhagen",
    Price = 30
};

Meal meal2 = new Meal()
{
    Headline = "Meal sharing",
    ImageUrl = "www.imageurl.com",
    BodyText = "Its Body Text",
    Location = "Copenhagen",
    Price = 30
};

// serializing object to a JSON and writing to a file synchronously

// string json = System.Text.Json.JsonSerializer.Serialize(meal);
// File.WriteAllText("meal.json", json);

// serializing object to a JSON and writing to a file asynchronously

// string json = System.Text.Json.JsonSerializer.Serialize(meal);
// await File.WriteAllTextAsync("meal.json", json);


var json = File.ReadAllText("meal.json");
System.Text.Json.JsonSerializer.Deserialize<Meal>(json);

// reading file asynchronously and deserializing to an object
// var json = await File.ReadAllTextAsync("blogPost.json");
// return System.Text.Json.JsonSerializer.Deserialize<Blogpost>(json);


app.Run();

public interface IMealService

{
    void AddMeal(Meal meal);
    List<Meal> ListMeals();
}

public class Meal
{
    public string Headline { get; set; }
    public string ImageUrl { get; set; }
    public string BodyText { get; set; }
    public string Location { get; set; }
    public int Price { get; set; }

}