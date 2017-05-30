namespace Infestation.CommandHendlers
{
    using System;
    using Enums;
    using Factories;
    using Providers;
    using Units;

    public class InsertCommandHandler : CommandHandlerBase
    {
        private readonly IUnitFactory _unitFactory;
        private readonly IInsertUnit _insertUnit;

        public InsertCommandHandler(IUnitFactory unitFactory, IInsertUnit insertUnit)
        {
            this._unitFactory = unitFactory;
            this._insertUnit = insertUnit;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.CommandType == CommandTypes.Insert;
        }

        protected override void ProccessCommandInternal(ICommand command)
        {
                IUnit unit = this._unitFactory.CreateUnit(command.UnitType, command.UnitId);

                this._insertUnit.InsertUnit(unit);
        }
    }
}
