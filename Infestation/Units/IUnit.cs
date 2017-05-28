namespace Infestation.Units
{
    using System.Collections.Generic;
    using Supplements;

    public interface IUnit
    {
        int Aggression { get; }
        int Health { get; }
        string Id { get; }
        UnitInfo Info { get; }
        bool IsDestroyed { get; }
        int Power { get; }
        UnitClassification UnitClassification { get; }

        void AddSupplement(ISupplement newSupplement);
        Interaction DecideInteraction(IEnumerable<UnitInfo> units);
        void DecreaseBaseHealth(int quantity);
        string ToString();
    }
}