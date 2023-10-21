// our protect resource
int value = 10;

var GetNextValueAsync = async Task<int> (int delay) =>
{
    await Task.Delay(delay); // await here everything after in this delegate will be a continuation
    value++;
    return value;
};

// Async != safe can't rely on value to be 10 initially
var aValue =  GetNextValueAsync(1000); // no await here will execute GetNextValueAsync until it reaches await on line 6 and return to line 13
var bValue = GetNextValueAsync(10); // no await here will execute GetNextValueAsync until it reaches await on line 6 and return to line 14
await Task.WhenAll(aValue,bValue); // await here everything after this will be the a continuation if tasks have not completed, will go to next line immidately if task completed
Console.WriteLine($"a value {aValue.Result}, b value {bValue.Result}"); //.result is blocking

/// todo research SemaphoreSlim
// this will keep is safe not sure how it works
SemaphoreSlim mutex = new SemaphoreSlim(1);
var valueSafe = 10;

var GetNextValueAsyncSafe = async Task<int> (int delay) =>
{
    // limit threads that can access the protect resource
    await mutex.WaitAsync(delay).ConfigureAwait(false);
    try
    {
        valueSafe++;
        return valueSafe;
    }
    finally { mutex.Release(); }
};

var aValueSafe = GetNextValueAsyncSafe(1000);
var bValueSafe = GetNextValueAsyncSafe(10);

await Task.WhenAll(aValueSafe, bValueSafe);
Console.WriteLine($"a value {aValueSafe.Result}, b value {bValueSafe.Result}");