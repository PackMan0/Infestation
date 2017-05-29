namespace Infestation.Interactions
{
    using Units;

    public abstract class InteractionBase : IInteraction
    {
        public const InteractionBase PassiveInteraction = null;

        public IUnit SourceUnit { get; private set; }
        public IUnit TargetUnit { get; private set; }

        public InteractionBase(IUnit sourceUnit, IUnit targetUnit)
        {
            this.SourceUnit = sourceUnit;
            this.TargetUnit = targetUnit;
        }

        public abstract void ExecuteInteraction();
    }
}
