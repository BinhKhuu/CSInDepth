# region Type Inferrence
// compiles to string myString
var myString = "Testing";

// type is inferred from values it has been initilized with
// int[] array1
var array1 = new[] { 1, 2, 3, 4, 5 };

// works well with anonymous types, useful in LINQ
var test = new { a = 2, b = 3 };
#endregion

# region Object Initlializers
// old way to initlize objects
var customer = new Customer();
customer.Name = "Jon";
customer.Address = "UK";
var item1 = new OrderItem();
item1.ItemId = "abcd123";
item1.Quantity = 1;
var item2 = new OrderItem();
item2.ItemId = "fghi456";
item2.Quantity = 2;
var order = new Order();
order.OrderId = "xyz";
order.Customer = customer;
order.Items.Add(item1);
order.Items.Add(item2);

// new way, note you don't need the () to call the constructor if no arguments are supplied
var order2 = new Order
{
    OrderId = order.OrderId,
    Customer = customer,
    Items =
    {
        new OrderItem {ItemId = "abc", Quantity = 1},
        new OrderItem {ItemId = "zxy", Quantity = 2}

    }
};

// these are the same anonymous type and the compiler will generate and assign them the same class (inspect the .dll)
var sameObject1 = new { property1 = "test" };
var sameObject2 = new { property1 = "test" };

# endregion
public class Order
{
    private readonly List<OrderItem> items = new List<OrderItem>();
    public string OrderId { get; set; }
    public Customer Customer { get; set; }
    public List<OrderItem> Items { get { return items; } }
}
public class Customer
{
    public string Name { get; set; }
    public string Address { get; set; }
}
public class OrderItem
{
    public string ItemId { get; set; }
    public int Quantity { get; set; }
}

