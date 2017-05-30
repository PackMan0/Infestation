namespace Infestation.CommandHendlers
{
    using System;
    using System.Collections.Generic;
    using Enums;
    using Factories;
    using Providers;

    public class ProceedCommandHandler : CommandHandlerBase
    {
        private readonly ITakeInteractions _takeAllUnits;

        public ProceedCommandHandler(ITakeInteractions takeAllUnits)
        {
            this._takeAllUnits = takeAllUnits;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.CommandType == CommandTypes.Proceed;
        }

        protected override void ProccessCommandInternal(ICommand command)
        {
            var allInteractions = this._takeAllUnits.TakeInteractions();

            foreach (var interaction in allInteractions)
            {
                interaction.ExecuteInteraction();
            }
        }
    }
}
