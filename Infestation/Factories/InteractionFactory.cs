namespace Infestation.Factories
{
    using Enums;
    using Interactions;
    using Units;

    public class InteractionFactory : IInteractionFactory
    {
        private readonly ISupplementFactory supplementFactory;

        public InteractionFactory(ISupplementFactory supplementFactory)
        {
            this.supplementFactory = supplementFactory;
        }

        public IInteraction CreateInteraction(IUnit sourceUnit, IUnit targetUnit)
        {
            switch (sourceUnit.UnitClassification)
            {
                    case InteractionType.Attack:
                        return new AttackInteraction(sourceUnit,targetUnit);
                    case InteractionType.Infest:
                        return new InfestInteraction(sourceUnit, targetUnit, this.supplementFactory.CreateSupplement(SupplementTypes.InfestationSpores));
            }
        }
    }
}
