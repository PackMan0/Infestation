namespace Infestation
{
    using CommandHendlers;
    using Factories;
    using Providers;

    public class HoldingPen : IHoldingPen
    {
        private ICommandFactory _commandProvider;
        private IReader _reader;
        private ICommandHandlerProcessor _commandProcessor;

        public HoldingPen(ICommandFactory commandProvider, IReader reader, ICommandHandlerProcessor commandProcessor)
        {
            this._commandProvider = commandProvider;
            this._reader = reader;
            this._commandProcessor = commandProcessor;
        }

        public void Start()
        {

            while (true)
            {
                var currentLine = this._reader.Read();

                var command = this._commandProvider.GetCommand();

                if (command.TranslateInput(currentLine))
                {
                    this._commandProcessor.ProcessCommand(command);
                }
            }
        }
    }
}
