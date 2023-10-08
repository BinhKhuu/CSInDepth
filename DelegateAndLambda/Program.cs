//Delegate
using MyDelegate;

static void NotifyCallback(string str)
{
    Console.WriteLine(str);
}
// Paramter is the method group 'NotifyCallback'
NotifyCallback del1 = new NotifyCallback(NotifyCallback);
del1("ugh");

// able to call correct overload
NotifyCallbackOverload del2 = new NotifyCallbackOverload(MyClass.NotifyCallback);
del2(1);

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
