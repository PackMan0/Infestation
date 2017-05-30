namespace Infestation.Units
{
    using Enums;

    public class Human : Unit
    {
        public const int HumanPower = 4;
        public const int HumanAggression = 1;
        public const int HumanHealth = 10;

        public Human(string id)
            : base(id, UnitClassifications.Biological, HumanHealth, HumanPower, HumanAggression, UnitClassifications.Biological, false)
        {
        }
    }
}
