using System.Collections.Generic;

/// <summary>
/// Receives Commands, queues them and executes them in order.
/// </summary>
public class CommandProcessor : MonoSingleton<CommandProcessor>
{
    private List<Command> commands = new List<Command>();

    public void AddCommand(Command command) {
        commands.Add(command);
    }

    public void ExecuteNext() {

    }
}
