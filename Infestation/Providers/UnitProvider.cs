namespace Infestation.Providers
{
    using System.Collections.Generic;
    using System.Linq;
    using Units;

    public class UnitProvider : IInsertUnit, ITakeUnit, ITakeUnitsStatuses, ITakeAllUnits
    {
        private ICollection<IUnit> units;

        public UnitProvider()
        {
            this.units = new List<IUnit>();
        }
        public void InsertUnit(IUnit unit)
        {
            this.units.Add(unit);

            this.units = this.units.OrderBy(u => u.Power).ToList();
        }

        public IUnit TakeUnit(string id)
        {
            return this.units.FirstOrDefault(u => u.Id == id);
        }
        public IEnumerable<string> TakeUnitsStatuses()
        {
            return this.units.Select(u => u.ToString());
        }

        public ICollection<IUnit> TakeAllUnits()
        {
            return this.units;
        }
    }
}
