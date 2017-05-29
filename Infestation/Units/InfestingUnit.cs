namespace Infestation.Units
{
    using System.Collections.Generic;
    using System.Linq;
    using Enums;
    using Interactions;

    public abstract class InfestingUnit : Unit
    {
        public InfestingUnit(string id, UnitClassifications unitType, int health, int power, int aggression)
            : base(id, unitType, health, power, aggression)
        {
        }

        public override InteractionBase DecideInteraction(IEnumerable<UnitInfo> units)
        {
            var candidateUnits = units.Where((unit) => unit.Id != this.Id && this.UnitClassification == InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification));

            UnitInfo optimalInfestableUnit = new UnitInfo(null, UnitClassifications.Unknown, int.MaxValue, 0, 0);

            foreach (var unit in candidateUnits)
            {
                if (unit.Health < optimalInfestableUnit.Health)
                {
                    optimalInfestableUnit = unit;
                }
            }

            if (optimalInfestableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalInfestableUnit, InteractionType.Infest);
            }

            return InteractionBase.PassiveInteraction;
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassifications.Unknown, int.MaxValue, 0, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health < optimalAttackableUnit.Health)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
    }
}
