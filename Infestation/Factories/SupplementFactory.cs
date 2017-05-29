namespace Infestation.Factories
{
    using System;
    using Enums;
    using Supplements;

    public class SupplementFactory : ISupplementFactory
    {
        public ISupplement CreateSupplement(SupplementTypes type)
        {
            switch (type)
            {
                case SupplementTypes.AggressionCatalyst:
                    return new AggressionCatalyst();
                case SupplementTypes.HealthCatalyst:
                    return new HealthCatalyst();
                case SupplementTypes.InfestationSpores:
                    return new InfestationSpores();
                case SupplementTypes.PowerCatalyst:
                    return new PowerCatalyst();
                case SupplementTypes.Weapon:
                    return new Weapon();
                case SupplementTypes.WeaponrySkill:
                    return new WeaponrySkill();
            }
        }
    }
}
