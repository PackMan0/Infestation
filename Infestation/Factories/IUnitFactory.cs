namespace Infestation.Factories
{
    using Units;

    public interface IUnitFactory
    {
        IUnit CreateUnit(string type, string id);
    }
}
