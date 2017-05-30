namespace Infestation.Units
{
    using Enums;

    public class Dog : Unit
    {
        const int DogPower = 5;
        const int DogAggression = 2;
        const int DogHealth = 4;

        public Dog(string id) :
            base(id, UnitClassifications.Biological, DogHealth, DogPower, DogAggression, UnitClassifications.Biological, false)
        {
        }
    }
}
