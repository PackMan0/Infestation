namespace Infestation.CommandHendlers
{
    public interface ICommandHandlerProcessor
    {
        string ProcessCommand(string command);
    }
}
