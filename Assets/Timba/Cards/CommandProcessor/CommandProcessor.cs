using System.Collections.Generic;

/// <summary>
/// Receives Commands, queues them and executes them in order.
/// </summary>
public class CommandProcessor : Singleton<CommandProcessor>
{
    private List<Command> commands;

    public void AddCommand(Command command) {
        commands.Add(command);
    }

    public void ExecuteNext() {

    }
}
