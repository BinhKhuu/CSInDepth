using System.ComponentModel;

var test = new PartialMethodsDemo();
Console.WriteLine(test.ToString());


partial class PartialMethodsDemo
{
    public PartialMethodsDemo()
    {
        OnConstruction();
    }
    public override string ToString()
    {
        string ret = "Original return value";
        CustomizeToString(ref ret);
        return ret;
    }
    partial void OnConstruction();
    // Because OnConstruction is never implemented, it's completely removed by the compiler.
    // examine the .dll
    partial void CustomizeToString(ref string text);
}

partial class PartialMethodsDemo
{
    partial void CustomizeToString(ref string text)
    {
        text += " - customized!";
    }
}

