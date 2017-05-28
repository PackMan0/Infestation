namespace Infestation.Factories
{
    using System;
    using Units;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string type, string id)
        {
            switch (type)
            {
                case "Dog":
                    return new Dog(id);
                case "Human":
                    return new Human(id);
                case "Marine":
                    return new Dog(id);
                case "Parasite":
                    return new Human(id);
                case "Queen":
                    return new Dog(id);
                case "Tank":
                    return new Human(id);
                default:
                    throw new ArgumentException("Wrong unit type");
            }
        }
    }
}
