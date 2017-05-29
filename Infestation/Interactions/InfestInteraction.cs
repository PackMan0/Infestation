namespace Infestation.Interactions
{
    using Enums;
    using Factories;
    using Supplements;
    using Units;

    public class InfestInteraction : InteractionBase
    {
        private readonly ISupplement supplement;

        public InfestInteraction(IUnit sourceUnit, IUnit targetUnit, ISupplement supplement) : base(sourceUnit, targetUnit)
        {
            this.supplement = supplement;
        }

        public override void ExecuteInteraction()
        {
            this.TargetUnit.AddSupplement(this.supplement);
        }
    }
}
