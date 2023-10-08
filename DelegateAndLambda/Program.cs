//Delegate is the type for a method
//Need statement that defines the delegate then create the instance of the delegate (expression) using a method group
//Note top level statements will have statement different ordering
using MyDelegate;

// method group
static void NotifyCallback(string str)
{
    Console.WriteLine(str);
}

// Delegate expression assignment with method group
// Paramter is the method group 'NotifyCallback'
NotifyCallback del1 = new NotifyCallback(NotifyCallback);
del1("ugh");

// able to call correct overload
NotifyCallbackOverload del2 = new NotifyCallbackOverload(MyClass.NotifyCallback);
del2(1);

// Delegate statement
delegate void NotifyCallback(string str);
delegate void NotifyCallbackOverload(int i); //set to overloaded int signiture

namespace MyDelegate
{
    static class MyClass
    {
        public static void NotifyCallback(string str)
        {
            Console.WriteLine(str);
        }

        public static void NotifyCallback(int i) 
        {
            Console.WriteLine(i);
        }
    }
}
