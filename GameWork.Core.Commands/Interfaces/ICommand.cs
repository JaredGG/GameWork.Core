namespace GameWork.Core.Commands.Interfaces
{
    public interface ICommand
    {
    }

    public interface ICommand<in TCommandAction> : ICommand
        where TCommandAction : ICommandAction
    {
        void Execute(TCommandAction implementor);
    }
}