namespace Infestation
{
    using Enums;
    using Interactions;
    using Supplements;
    using Units;

    public class InfestationPen : HoldingPen
    {
        public InfestationPen()
            : base()
        {
        }

        protected override void ProcessSingleInteraction(InteractionBase interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    var targetUnit = this.GetUnit(interaction.TargetUnit);
                    targetUnit.AddSupplement(new InfestationSpores());
                    break;
                default:
                    base.ProcessSingleInteraction(interaction);
                    break;
            }
        }
    }
}
