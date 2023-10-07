/*
    After the last statement of the try block is executed. (No surprise here.)
    When an exception propagates out of the try block. (No surprise here either.)
    When execution leaves the try block via yield break.
    When the iterator is Disposed and the iterator body was trapped inside a try block at the time.
*/

IEnumerable<int> CountTo10()
{
    try
    {
        for (int i = 1; i <= 10; i++)
        {
            if (i == 3)
                throw new Exception("UGH"); // will call finally when exception propgates out of yield block
            yield return i;
        }
    }
    finally
    {
        Console.WriteLine("finally"); // this is called before exception is cause in outter try
    }
}

try
{
    foreach (int i in CountTo10())
    {
        Console.WriteLine(i);
        if (i == 5) break; //will call finally block 
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString()); // called after finally
}

static IEnumerable<string> Iterator()
{
    try
    {
        Console.WriteLine("Before first yield");
        yield return "first";
        Console.WriteLine("Between yields");
        yield return "second";
        Console.WriteLine("After second yield");
    }
    finally
    {
        Console.WriteLine("In finally block");
    }
}

// because of the using finally will be called in Interator()
// without the sing finally is never called because the yield block never got to the end
IEnumerable<string> enumerable = Iterator();
using (IEnumerator<string> enumerator = enumerable.GetEnumerator())
{
    while (enumerator.MoveNext())
    {
        string value = enumerator.Current;
        Console.WriteLine("Received value: {0}", value);
        if (value != null)
        {
            break;
        }
    }
}