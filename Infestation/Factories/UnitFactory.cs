namespace Infestation.Factories
{
    using System;
    using Enums;
    using Supplements;
    using Units;

    public class UnitFactory : IUnitFactory
    {
        private ISupplementFactory supplementFactory;

        public UnitFactory(ISupplementFactory supplementFactory)
        {
            this.supplementFactory = supplementFactory;
        }

        public IUnit CreateUnit(UnitTypes type, string id)
        {
            switch (type)
            {
                case UnitTypes.Dog:
                    return new Dog(id);
                case UnitTypes.Human:
                    return new Human(id);
                case UnitTypes.Marine:
                    return new Marine(id, this.supplementFactory.CreateSupplement(SupplementTypes.WeaponrySkill));
                case UnitTypes.Parasite:
                    return new Parasite(id);
                case UnitTypes.Queen:
                    return new Queen(id);
                case UnitTypes.Tank:
                    return new Tank(id);
            }
        }
    }
}
