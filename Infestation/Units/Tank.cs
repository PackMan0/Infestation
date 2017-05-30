namespace Infestation.Units
{
    using Enums;

    public class Tank : Unit
    {
        const int TankPower = 25;
        const int TankHealth = 20;
        const int TankAggression = 25;

        public Tank(string id)
            : base(id, UnitClassifications.Mechanical, TankHealth, TankPower, TankAggression, UnitClassifications.Psionic, false)
        {
        }
    }
}
