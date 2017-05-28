namespace Infestation.CommandHendlers
{
    public interface ICommandHandler : ICommandHandlerProcessor
    {
        void SetSuccessor(ICommandHandlerProcessor commandHandler);
    }
}