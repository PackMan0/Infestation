namespace Infestation.Units
{
    using System.Collections.Generic;
    using Enums;
    using Interactions;
    using Supplements;

    public interface IUnit
    {
        int Aggression { get; }

        int Health { get; }

        string Id { get; }

        bool IsDestroyed { get; }

        int Power { get; }

        bool CanInfest { get; }

        UnitClassifications UnitClassification { get; }

        UnitClassifications ClassificationToInteract { get; }

        void AddSupplement(ISupplement newSupplement);

        void DecreaseHealth(int val);

        string ToString();
    }
}