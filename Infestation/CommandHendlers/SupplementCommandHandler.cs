namespace Infestation.CommandHendlers
{
    using System;
    using Enums;
    using Factories;
    using Providers;
    using Supplements;
    using Units;

    public class SupplementCommandHandler : CommandHandlerBase
    {
        private readonly ISupplementFactory _supplementFactory;
        private readonly ITakeUnit _takeUnit;

        public SupplementCommandHandler(ISupplementFactory supplementFactory, ITakeUnit takeUnit)
        {
            this._supplementFactory = supplementFactory;
            this._takeUnit = takeUnit;
        }
        protected override bool CanHandle(ICommand command)
        {
            return command != null && command.CommandType == CommandTypes.Supplement;
        }

        protected override void ProccessCommandInternal(ICommand command)
        {
            ISupplement supplement = this._supplementFactory.GetSupplement(command.SupplementType);
            IUnit unit = this._takeUnit.TakeUnit(command.UnitId);

            unit.AddSupplement(supplement);
        }
    }
}
