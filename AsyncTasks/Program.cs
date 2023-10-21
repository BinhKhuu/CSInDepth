
using System;

SynchronizationContext sc = SynchronizationContext.Current;
AsyncVoidExcpetion_CannotBeCaughtByCatch();
VoidExcpetion_CannotBeCaughtByCatch();
AsyncTaskException_CantBeCaughtByCatch();
SynchronizationContextExample(ThrowExceptionAsync, () => Console.WriteLine("ugh") );
Console.ReadLine();

// Exceptions are captured in the Task, Async void does not return a task, so its raised to the SynchronizationContext
// Having async void decorator means the exception is sent to the SynchronizationContext so it can't be caught even when the code has no asynchronous tasks.
static async void ThrowExceptionAsync()
{
    throw new InvalidOperationException();

}

static void AsyncVoidExcpetion_CannotBeCaughtByCatch()
{
    try
    {
        // can't await a void so this looks like a regular synchronous method call which can be bad if it is really async.
        ThrowExceptionAsync();
    }
    catch (Exception ex)
    {
        // The exception is never caught here!
        throw;
    }
}

// same as Async version without the async decorator
static void ThrowException()
{
    throw new InvalidOperationException();
}

// exception can be caught
static void VoidExcpetion_CannotBeCaughtByCatch()
{
    try
    {
        ThrowException();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}

//  With Task can catch error
static Task ThrowExceptionTask()
{
    throw new NotImplementedException();
}

static async void AsyncTaskException_CantBeCaughtByCatch()
{
    try
    {
        // error propogates up to the awaiters GetResult()
        await ThrowExceptionTask();
    }
    catch (AggregateException ae)
    {
        foreach (var ex in ae.InnerExceptions)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

static void SynchronizationContextExample(Action worker, Action completion)
{
    //By default, all threads in console applications and Windows Services only have the default SynchronizationContext.
    //This causes some event-based asynchronous components to fail.
    SynchronizationContext sc = SynchronizationContext.Current;
    ThreadPool.QueueUserWorkItem(_ =>
    {
        try
        {
            worker();
        }
        finally
        {
            // Only the SynchronizationContext is informed when the async void has returned
            // Error in synchronizationContext
            sc?.Post(_ => completion(), null); //sc is null in this example. Todo workout how to get Synchroniztion context
        }
    });
}
