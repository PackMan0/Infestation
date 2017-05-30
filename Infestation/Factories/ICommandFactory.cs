namespace Infestation.Factories
{
    using CommandHendlers;
    using Providers;

    public interface ICommandFactory
    {
        ICommand GetCommand();
    }
}
