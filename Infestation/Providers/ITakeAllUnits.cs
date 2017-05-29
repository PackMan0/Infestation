namespace Infestation.Providers
{
    using System.Collections.Generic;
    using Units;

    public interface ITakeAllUnits
    {
        ICollection<IUnit> TakeAllUnits();
    }
}
