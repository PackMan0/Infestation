namespace Infestation.Factories
{
    using Enums;
    using Interactions;
    using Units;

    public class InteractionFactory : IInteractionFactory
    {
        private readonly ISupplementFactory _supplementFactory;

        public InteractionFactory(ISupplementFactory supplementFactory)
        {
            this._supplementFactory = supplementFactory;
        }

        public IInteraction CreateInteraction(IUnit sourceUnit, IUnit targetUnit)
        {
            if (sourceUnit.CanInfest)
            {
                return new InfestInteraction(sourceUnit, targetUnit,
                    this._supplementFactory.CreateSupplement(SupplementTypes.InfestationSpores));
            }
            else
            {
                return new AttackInteraction(sourceUnit, targetUnit);
            }
        }
    }
}
