namespace Infestation.Factories
{
    using System;
    using Supplements;

    public class SupplementFactory : ISupplementFactory
    {
        public ISupplement CreateSupplement(string type)
        {
            switch (type)
            {
                case "PowerCatalyst":
                        return new PowerCatalyst();
                case "HealthCatalyst":
                        return new HealthCatalyst();
                case "AggressionCatalyst":
                        return new AggressionCatalyst();
                case "Weapon":
                        return new Weapon();
                default:
                    throw new ArgumentException("Wrong supplement type");
            }
        }
    }
}
