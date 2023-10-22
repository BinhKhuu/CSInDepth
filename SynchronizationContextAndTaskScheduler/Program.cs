
// Use Synchronization context to execute continuation
SynchronizationContext sc = SynchronizationContext.Current;
await Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith(t =>
{
   
    sc.Post(delegate
    {
        Console.WriteLine("ugh");
    },null);
});


// Marshall the current SynchronizationContext from the TaskScheduler.
await Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith(t =>
{
    Console.WriteLine("ugh");
}, TaskScheduler.FromCurrentSynchronizationContext());

