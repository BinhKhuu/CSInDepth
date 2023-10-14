using System.Dynamic;

dynamic example = new SimpleDynamicExample();
example.CallSomeMethod("x", 10);
Console.WriteLine(example.SomeProperty);

class SimpleDynamicExample : DynamicObject
{
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
        return true;
    }
}

