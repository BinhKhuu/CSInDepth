
// Anon method
Action<string> action = (string message) =>
{
    Console.WriteLine(message);
};

// Short form is the lambda in a single expression
Action<string> action2 = (string message) => Console.WriteLine(message);

// lambda defined in an expression
var myLambda = (string message) => Console.Write(message);

action("test1");
action2("test2");
myLambda("test3");

/*
 * Scopes and Closures look at the .dll to see how the compiler genertes the classes and statemachines
 */
static List<Action> CreateCountingActions()
{
    List<Action> actions = new List<Action>();
    // shared scoped variable
    int outerCounter = 0;
    for (int i = 0; i < 2; i++)
    {
        // new local scoped variable
        int innerCounter = 0;

        // closure over outerCounter and innerCounter
        Action action = () =>
        {
            Console.WriteLine(
            "Outer: {0}; Inner: {1}",
            outerCounter, innerCounter);
            outerCounter++;
            innerCounter++;
        };
        actions.Add(action);
    }
    return actions;
}

List<Action> actions = CreateCountingActions();

// closure formed over outerCounter can access from anywhere
actions[0]();// 0 0
actions[0]();// 1 1
actions[1]();// 2 0
actions[1]();// 3 1
actions[0]();// 4 2
actions[0]();// 5 3
actions[1]();// 6 2