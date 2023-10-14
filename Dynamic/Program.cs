using System.Dynamic;

dynamic d = new { a = 1};
var testSum = d + 3; //operation involving dynamic its type can be inferred
// Rest the mouse pointer over testSum in the following statement. type is dynamic{int}
System.Console.WriteLine(testSum);

// dynamic object
dynamic user = new
{
    FirstName = "Billy",
    LastName = "Bob"
};

Console.WriteLine($"{user.FirstName} {user.LastName}");

// compliler wont pick up this error
try
{
    user.Gender = "ugh";
}
catch (Exception e)
{
    Console.WriteLine($"can't add properties dynamically unless with expando object Error: {e}");
}

dynamic d1;
dynamic d2 = "A string";
dynamic d3 = 42;
Console.WriteLine(d2.Length);
try
{
    // int doesnt have Length property but this code will compile
    Console.WriteLine(d3.Length);
}
catch (Exception e)
{
    Console.WriteLine($"Compiler didnt pick up this error ${e}");
}
