namespace Infestation.CommandHendlers
{
    using System;
    using System.Collections.Generic;
    using Enums;
    using Factories;
    using Providers;

    public class StatusCommandHandler : CommandHandlerBase
    {
        private readonly IWriter _writer;
        private readonly ITakeUnitsStatuses _unitsStatuses;

        public StatusCommandHandler(IWriter writer, ITakeUnitsStatuses unitsStatuses)
        {
            this._writer = writer;
            this._unitsStatuses = unitsStatuses;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command != null && command.CommandType == CommandTypes.Status;
        }

        protected override void ProccessCommandInternal(ICommand command)
        {
            IEnumerable<string> statuses = this._unitsStatuses.TakeUnitsStatuses();

            foreach (var st in statuses)
            {
                this._writer.Write(st);
            }
        }
    }
}
