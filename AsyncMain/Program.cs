partial class Program
{
    static void Main()
    {
        try
        {
            // Blocking the async operation
            MainAsync().Wait();
        }
        // Excpetions for blocking async operations will always be Aggregated, can't catch the specific
        catch (Exception ex)
        {
            Console.WriteLine($"Sync Main exception {ex.GetType().ToString()}");
        }

    }
    static async Task MainAsync()
    {
        try
        {
            // Asynchronous implementation.
            await Task.Delay(1000);
            throw new NotImplementedException();
        }
        // Exceptiosn for awaiting will be the first exception thrown
        catch (Exception ex)
        {
            // Handle exceptions.
            Console.WriteLine($"Async Main Exception {ex.GetType().ToString()}");
            throw new Exception("My Exception");
        }
    }
}