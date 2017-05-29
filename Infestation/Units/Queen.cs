namespace Infestation.Units
{
    using Enums;

    public class Queen : Unit
    {
        const int QueenPower = 1;
        const int QueenHealth = 30;
        const int QueenAggression = 1;

        public Queen(string id)
            : base(id, UnitClassifications.Psionic, QueenHealth, QueenPower, QueenAggression, UnitClassifications.Psionic)
        {
        }
    }
}
    