namespace Infestation.CommandHendlers
{
    public interface ICommandHandlerProcessor
    {
        void ProcessCommand(ICommand command);
    }
}
