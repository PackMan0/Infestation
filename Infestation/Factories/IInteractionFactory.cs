namespace Infestation.Factories
{
    using Enums;
    using Interactions;
    using Units;

    public interface IInteractionFactory
    {
        IInteraction CreateInteraction(IUnit sourceUnit, IUnit targetUnit);
    }
}
