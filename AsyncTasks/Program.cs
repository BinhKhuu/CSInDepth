
using System;

AsyncVoidExcpetion_CannotBeCaughtByCatch();
AsyncTaskException_CantBeCaughtByCatch();

// Exceptions are captured in the Task, Async void does not return a task, so its raised to the SynchronizationContext
static async void ThrowExceptionAsync()
{
    throw new InvalidOperationException();
}

static void AsyncVoidExcpetion_CannotBeCaughtByCatch()
{
    try
    {
        // can't await so this looks like a regular synchronous method call.
        ThrowExceptionAsync();
    }
    catch (Exception ex)
    {
        // The exception is never caught here!
        throw;
    }
}

// Task can catch error
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
