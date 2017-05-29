namespace Infestation.CommandHendlers
{
    using System;
    using System.Collections.Generic;
    using Enums;
    using Factories;
    using Providers;

    public class ProceedCommandHandler : CommandHandlerBase
    {
        private readonly ITakeAllUnits takeAllUnits;
        private readonly IInteractionFactory interactionFactory;

        public ProceedCommandHandler(ITakeAllUnits takeAllUnits, IInteractionFactory interactionFactory)
        {
            this.takeAllUnits = takeAllUnits;
            this.interactionFactory = interactionFactory;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Type == CommandTypes.Proceed;
        }

        protected override void ProccessCommandInternal(ICommand command)
        {
            var allUnits = this.takeAllUnits.TakeAllUnits();

            foreach (var unit in allUnits)
            {
                
            }
        }
    }
}
