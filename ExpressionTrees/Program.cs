using System.Linq.Expressions;
using System.Linq;
// this is not allowed because statement body is statement body
//Expression<Func<int,int,int>> addr = (x, y) => { return x + y; };

// this is allowed only one expression
Expression<Func<int, int, int>> addr = (x, y) => x + y;

var addrDelgate = addr.Compile();
Console.WriteLine(addrDelgate(2, 3));

var myList = new List<int> { 1,2, 3 };

// Linq uses lambda see the .Select paramter
// creates IEnumerable processed locally, if IQueryable its sent to the Provider
myList.Select(x => x + 1).ToList();
foreach (var item in myList)
{
    Console.WriteLine($"MyList item: {item}");
}

// Query Expression
IEnumerable<int> queryExpression = from number in myList
                         where number > 1
                         orderby number
                         select number;

// equivilent Linq Chaining
IEnumerable<int> query = myList.Where(x => x > 1)
    .OrderBy(x => x)
    .Select(x => x);



foreach (var item in queryExpression)
{
    Console.WriteLine($"queryExpression number: {item}");
}

foreach (var item in query)
{
    Console.WriteLine($"queryExpression number: {item}");
}


// TransparentIdentifier * for let variable complier is doing the heavy lifting when creating the scoped variables
var myQueryExpression = from number in myList
                        let identifier = number * 2
                        where identifier > 5
                        orderby identifier
                        select $"ID {identifier}  Number {number}";

// Equivalent in Linq Chaining you do the heavy lifting creating the transparent identifiers
var myQuery = myList.Select(num => new { num, identifier = num * 2 })
    .Where(temp => temp.identifier > 5)
    .OrderBy(temp => temp.identifier)
    .Select(temp => $"ID {temp.identifier}  Number {temp.num}");


foreach(var item in myQueryExpression)
{
    Console.WriteLine(item );
}

foreach (var item in myQuery)
{
    Console.WriteLine(item);
}