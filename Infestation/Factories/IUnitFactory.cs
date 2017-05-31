namespace Infestation.Factories
{
    using Enums;
    using Supplements;
    using Units;

    public interface IUnitFactory
    {
        IUnit GetUnit(UnitTypes type, string id);
    }
}
