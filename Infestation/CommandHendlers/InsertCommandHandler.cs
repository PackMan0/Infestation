namespace Infestation.CommandHendlers
{
    using System;
    using Enums;
    using Factories;
    using Providers;
    using Units;

    public class InsertCommandHandler : CommandHandlerBase
    {
        private readonly IUnitFactory unitFactory;
        private readonly IInsertUnit insertUnit;

        public InsertCommandHandler(IUnitFactory unitFactory, IInsertUnit insertUnit)
        {
            this.unitFactory = unitFactory;
            this.insertUnit = insertUnit;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Type == CommandTypes.Insert;
        }

        protected override void ProccessCommandInternal(ICommand command)
        {
            UnitTypes type;

            if (Enum.TryParse(command.Parameters[0], out type))
            {
                string id = command.Parameters[1];

                IUnit unit = this.unitFactory.CreateUnit(type, id);

                this.insertUnit.InsertUnit(unit);
            }
        }
    }
}
