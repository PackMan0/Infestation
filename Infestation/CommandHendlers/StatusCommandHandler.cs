namespace Infestation.CommandHendlers
{
    using System;
    using System.Collections.Generic;
    using Enums;
    using Factories;
    using Providers;

    public class StatusCommandHandler : CommandHandlerBase
    {
        private readonly IWriter writer;
        private readonly ITakeUnitsStatuses unitsStatuses;

        public StatusCommandHandler(IWriter writer, ITakeUnitsStatuses unitsStatuses)
        {
            this.writer = writer;
            this.unitsStatuses = unitsStatuses;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command != null && command.Type == CommandTypes.Status;
        }

        protected override void ProccessCommandInternal(ICommand command)
        {
            IEnumerable<string> statuses = this.unitsStatuses.TakeUnitsStatuses();

            foreach (var st in statuses)
            {
                this.writer.Write(st);
            }
        }
    }
}
