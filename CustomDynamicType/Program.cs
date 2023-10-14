using System.Dynamic;

dynamic example = new SimpleDynamicExample();
example.CallSomeMethod("x", 10);
example.MyProp = "Ugh";
example.SomeProperty = 1;
Console.WriteLine(example.SomeProperty);
Console.WriteLine(example.MyProp);
class SimpleDynamicExample : DynamicObject
{
    private readonly Dictionary<string, object> _;

    public SimpleDynamicExample() { 
        _ = new Dictionary<string, object>();
    }
    public override bool TryInvokeMember(
    InvokeMemberBinder binder,
    object[] args,
    out object result)
    {
        Console.WriteLine("Invoked: {0}({1})",
        binder.Name, string.Join(", ", args));
        result = null;
        return true;
    }
    public override bool TryGetMember(
    GetMemberBinder binder,
    out object result)
    {
        result = "Fetched: " + binder.Name;
        return _.TryGetValue(binder.Name, out result);
    }

    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
        var key = binder.Name;
        _[key] = value;
        return true;
    }
}

