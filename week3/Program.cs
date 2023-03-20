var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

/* Task 1:
Create a class named Temperature and make a constructor with one decimal parameter - degrees (Celsius) and 
assign its value to Property. The property has a public getter and private setter.The property setter throws 
an exception if temperature is less than 273.15 Celsius. Then, create a property Fahrenheit that will convert 
Celsius to Fahrenheit (it has no setter similar to NicePrintout)
*/
app.MapGet("/temp", () =>
{
    var temperature = new Temperature(-500m);
    System.Console.WriteLine($"{temperature.Celcius} Celsius is {temperature.Fahrenheit} Fahrenheit");
});



/* Task 2 :
Create a class named ExchangeRate with a constructor with two string parameters, fromCurrency and toCurrency. 
Add a decimal property called Rate and method Calculate with decimal parameter amount return value of the method 
should be a product of Rate and amount multiplication.
Bonus: We should also check that Rate or amount are not negative.
 */
app.MapGet("/exchangeRate", () =>
{
    var amount = 150;
    var exchangeRate = new ExchangeRate("EUR", "DKK");
    exchangeRate.Rate = 7.5m;
    Console.WriteLine($"The rate of {amount} {exchangeRate.FromCurrency} is {exchangeRate.Calculate(amount)} {exchangeRate.ToCurrency}");
});

/* Task 3 :
Create Account class that can be initialized with the amount value. Account class contains Withdraw and Deposit 
methods and Balance (get only) property. Make sure that you can't withdraw more than you have in the balance.
 */

app.MapGet("/accountBalance", () =>
{
    var amountBalance = new Account(500);
    amountBalance.Deposit(500);
    Console.WriteLine($"Account balance is {amountBalance.Balance}");
    //amountBalance.Withdraw(300);
    amountBalance.Withdraw(1100);
    System.Console.WriteLine($"Remain Account balance is {amountBalance.Balance}");
    
});

/* Task 4
 Create interface IAnimal with property Name and Sound . Create classes Cow, Cat and Dog that implement IAnimal . 
Instantiate all three classes and pass them to a new method called MakeSound that has single parameter IAnimal and 
it writes to console eg “Dog says woof woof” if instance of the Dog class is passed.
*/


app.Run();


//Temperature
public class Temperature
{
    public decimal tempCelcius = -273.15m;
    public decimal Celcius { get; set; }

    public Temperature(decimal tempCelciusDegree)
    {
        Celcius = tempCelciusDegree;
        if (Celcius < tempCelcius)
        {
            System.Console.WriteLine("Temperature cannot be less than -273.15");
            throw new System.Exception("Temperature cannot be less than -273.15");
        }
    }
    public string Fahrenheit
    {
        get => ($"{((Celcius * 9) / 5) + 32}");
    }
}

// ExchangeRate Task
public class ExchangeRate
{
    public string FromCurrency { get; set; }
    public string ToCurrency { get; set; }
    public decimal Rate { get; set; }
    public ExchangeRate(string fromCurrency, string toCurrency)
    {
        FromCurrency = fromCurrency;
        ToCurrency = toCurrency;
    }
    public decimal Calculate(decimal amount)
    {
        if (Rate <= 0 || amount <= 0)
        {
            throw new Exception("Amount shouldn't be negative");
        }
        var result = Rate * amount;
        return result;
    }
}

//Bank account
public class Account
{
    public decimal Amount { get; set; }
    public decimal Balance { get; set; }
    public Account(decimal balance)
    {
        Balance = balance;
    }
    public decimal Deposit(decimal Amount)
    {
        {
            if (Balance > 0)
            {
                Balance += Amount;
            }
            return Balance;
        }
    }
    public decimal Withdraw(decimal Amount)
    {
        {
            if (Balance <= Amount)
            {
                throw new Exception("Please check your account balance is not enough");
            }
            return Balance -= Amount;
        }
    }
}