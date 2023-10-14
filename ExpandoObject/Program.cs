using System.ComponentModel;
using System.Dynamic;

dynamic book = new ExpandoObject();

// dynamically assigned properties
book.Author = "Ugh";
book.Year = 2023;

Console.WriteLine($"{book.Author} {book.Year}");

// using object instantation to create the properties
dynamic anonBook = new
{
    Author = "John Doe",
    Year = 2023
};
Console.WriteLine($"{anonBook.Author} {anonBook.Year}");
try
{
    anonBook.CopiesSold = 1000;
}
catch (Exception ex)
{
    Console.WriteLine($"Can't add new properties after declared {ex}");
}

// can do it to the ExpandoObject
book.CopiesSold = 2000;
Console.WriteLine($"{book.Author} {book.Year} {book.CopiesSold}");

book.Sell = (Action)(() => { book.CopiesSold++; });
book.Sell();

// Expando object implements IDictionary<string, object>
dynamic country = new ExpandoObject();
country.Continent = "Asia";
country.Population = "3 Billion people";
foreach (KeyValuePair<string, object> keyValuePair in country)
{
    Console.WriteLine($"{keyValuePair.Key} : {keyValuePair.Value}");
}

// because its an IDictionary you can use the IDictonary methods
((IDictionary<string,object>)country).Remove("Population");
foreach (KeyValuePair<string, object> keyValuePair in country)
{
    Console.WriteLine($"{keyValuePair.Key} : {keyValuePair.Value}");
}

// Exapdo implements INotifyPropertyChanged += subscribes to an event
((INotifyPropertyChanged)country).PropertyChanged += (_, e) =>
{
    Console.WriteLine($"Property changed: {e.PropertyName}");
};

country.Population = "3 Billion people";