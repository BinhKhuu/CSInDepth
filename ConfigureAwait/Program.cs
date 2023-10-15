
await MyMethodAsync();


static async Task MyMethodAsync()
{
    string test = "testing";
    // Code here runs in the original context.
    await Task.FromResult(1);
    // Code here runs in the original context.
    await Task.FromResult(1).ConfigureAwait(continueOnCapturedContext: false);
    // Code here runs in the original context.
    var random = new Random();
    int delay = random.Next(2); // Delay is either 0 or 1
    await Task.Delay(delay).ConfigureAwait(continueOnCapturedContext: false);
    // Code here might or might not run in the original context.
    // The same is true when you await any Task
    // that might complete very quickly.
    
    // if there is context needed then don't use continueOnCapturedContext
}

