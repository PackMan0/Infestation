namespace Infestation.Units
{
    using Enums;

    public class Parasite : Unit
    {
        const int ParasitePower = 1;
        const int ParasiteHealth = 1;
        const int ParasiteAggression = 1;

        public Parasite(string id)
            : base(id, UnitClassifications.Biological, ParasiteHealth, ParasitePower, ParasiteAggression, UnitClassifications.Biological, true)
        {
        }
    }
}
