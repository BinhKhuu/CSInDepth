// our protect resource
int value = 10;

var GetNextValueAsync = async Task<int> (int delay) =>
{
    await Task.Delay(delay);
    value++;
    return value;
};

// Async != safe can't rely on value to be 10 initially
var aValue =  GetNextValueAsync(1000);
var bValue = GetNextValueAsync(10);

await Task.WhenAll(aValue,bValue);
Console.WriteLine($"a value {aValue.Result}, b value {bValue.Result}");

/// todo research SemaphoreSlim
// this will keep is safe not sure how it works
SemaphoreSlim mutex = new SemaphoreSlim(1);
var valueSafe = 10;

var GetNextValueAsyncSafe = async Task<int> (int delay) =>
{
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