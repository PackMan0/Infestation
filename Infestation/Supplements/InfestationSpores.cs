namespace Infestation.Supplements
{
    public class InfestationSpores : SupplementBase
    {
        public InfestationSpores()
            : base(-1, 0, 20)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.PowerEffect = 0;
                this.AggressionEffect = 0;
            }
        }
    }
}
