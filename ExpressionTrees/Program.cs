using System.Linq.Expressions;

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