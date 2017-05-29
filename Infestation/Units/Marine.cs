namespace Infestation.Units
{
    using System.Collections.Generic;
    using Enums;
    using Supplements;

    public class Marine : Human
    {
        public Marine(string id, ISupplement defaultSupplement)
            : base(id)
        {
            this.AddSupplement(defaultSupplement);
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassifications.Unknown, int.MinValue, 0, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health > optimalAttackableUnit.Health)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
    }
}
