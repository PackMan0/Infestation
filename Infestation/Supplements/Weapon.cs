namespace Infestation.Supplements
{
    public class Weapon : SupplementBase
    {
        const int WeaponPotentialPowerEffect = 10;
        const int WeaponPotentialAggressionEffect = 3;
        public Weapon()
            : base(0, 0, 0)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.PowerEffect = Weapon.WeaponPotentialPowerEffect;
                this.AggressionEffect = Weapon.WeaponPotentialAggressionEffect;
            }
        }
    }
}
