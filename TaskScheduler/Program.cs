partial class Program
{
    static void Main()
    {
        try
        {
            // Blocking async operation
            MainAsync().Wait();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Sync Main exception {ex.GetType().ToString()}");
        }

}

    static async Task MainAsync()
    {
        try
        {
            //there’s no method for setting the current scheduler. Instead, the current scheduler is the one associated with the currently running Task
            var cesp = new ConcurrentExclusiveSchedulerPair();
            //Task Scheduler is a class that schedules and automatically fires events at a time you specify
            var myTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine(TaskScheduler.Current == cesp.ExclusiveScheduler);
            }, default, TaskCreationOptions.None, cesp.ExclusiveScheduler);

            await myTask;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Async Main Exception {ex.GetType().ToString()}");
            throw new Exception("My Exception");
        }
    }
}