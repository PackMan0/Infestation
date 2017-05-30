namespace Infestation.Factories
{
    using CommandHendlers;
    using Providers;

    public class CommandFactory : ICommandFactory
    {
        private IWriter _writer;

        public CommandFactory(IWriter writer)
        {
            this._writer = writer;
        }

        public ICommand GetCommand()
        {
            return new Command(this._writer);
        }
    }
}
