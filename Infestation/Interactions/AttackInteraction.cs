namespace Infestation.Interactions
{
    using System;
    using Units;

    public class AttackInteraction : InteractionBase
    {
        public AttackInteraction(IUnit sourceUnit, IUnit targetUnit) : base(sourceUnit, targetUnit)
        {
        }

        public override void ExecuteInteraction()
        {
            this.TargetUnit.DecreaseHealth(this.SourceUnit.Power);
        }
    }
}
