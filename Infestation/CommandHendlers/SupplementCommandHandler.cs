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
        private readonly ISupplementFactory supplementFactory;
        private readonly ITakeUnit takeUnit;

        public SupplementCommandHandler(ISupplementFactory supplementFactory, ITakeUnit takeUnit)
        {
            this.supplementFactory = supplementFactory;
            this.takeUnit = takeUnit;
        }
        protected override bool CanHandle(ICommand command)
        {
            return command != null && command.Type == CommandTypes.Suppliment;
        }

        protected override void ProccessCommandInternal(ICommand command)
        {
            SupplementTypes supplimentType;

            if (Enum.TryParse(command.Parameters[0], out supplimentType))
            {

                string unitId = command.Parameters[1];

                ISupplement supplement = this.supplementFactory.CreateSupplement(supplimentType);
                IUnit unit = this.takeUnit.TakeUnit(unitId);

                unit.AddSupplement(supplement);
            }
        }
    }
}
