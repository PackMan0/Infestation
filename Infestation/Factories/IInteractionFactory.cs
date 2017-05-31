namespace Infestation.Factories
{
    using Enums;
    using Interactions;
    using Units;

    public interface IInteractionFactory
    {
        IInteraction GetInteraction(IUnit sourceUnit, IUnit targetUnit);
    }
}
