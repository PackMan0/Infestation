namespace Infestation.Factories
{
    using Enums;
    using Supplements;
    using Units;

    public interface IUnitFactory
    {
        IUnit CreateUnit(UnitTypes type, string id);
    }
}
