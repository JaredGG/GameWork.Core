using System.Collections.Generic;
using System.Linq;
using GameWork.Core.Commands.Interfaces;

namespace GameWork.Core.Commands
{
	public class CommandQueue : CommandQueue<ICommand>, ICommandQueue
	{
	}

	public class CommandQueue<TCommand> : ICommandQueue<TCommand>
		where TCommand : ICommand
	{
        private readonly List<TCommand> _commands = new List<TCommand>();

        public bool HasCommands => _commands.Any();

	    public void AddCommand(TCommand command)
        {
            _commands.Add(command);
        }

        public void AddCommands(IEnumerable<TCommand> commands)
        {
            _commands.AddRange(commands);
        }

        public bool TryTakeFirstCommand(out TCommand command)
        {
            if (HasCommands)
            {
                command = TakeFirstCommand();
                return true;
            }

            command = default(TCommand);
            return false;
        }

        public bool TryTakeAllCommands(out IList<TCommand> commands)
        {
            if (HasCommands)
            {
                commands = TakeAllCommands();
                return true;
            }

            commands = null;
            return false;
        }
        
        public TCommand TakeFirstCommand()
        {
            var command = _commands[0];
            _commands.RemoveAt(0);
            return command;
        }

        public IList<TCommand> TakeAllCommands()
        {
            var commands = _commands.ToList();
            _commands.Clear();
            return commands;
        }
    }
}