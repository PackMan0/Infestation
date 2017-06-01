namespace Infestation.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Enums;
    using Interactions;
    using Supplements;

    public abstract class Unit : IUnit
    {

        private int _health;
        private int _power;
        private int _aggression;
        private bool _canInfest;
        private UnitClassifications _classificationToInteract;
        private ICollection<ISupplement> _supplements;

        public Unit(string id, UnitClassifications unitType, int health, int power, int aggression, UnitClassifications classificationToInteract, bool canInfest)
        {
            this.Id = id;
            this.UnitClassification = unitType;

            this._health = health;
            this._power = power;
            this._aggression = aggression;
            this._classificationToInteract = classificationToInteract;
            this._canInfest = canInfest;

            this._supplements = new List<ISupplement>();
        }

        public string Id { get; }

        public UnitClassifications UnitClassification { get; }

        public virtual int Health
        {
            get
            {
                int supplementsBonus = 0;
                foreach (var supplement in this._supplements)
                {
                    supplementsBonus += supplement.HealthEffect;
                }

                return this._health + supplementsBonus;
            }
        }
        public virtual int Power
        {
            get
            {
                int supplementsBonus = 0;
                foreach (var supplement in this._supplements)
                {
                    supplementsBonus += supplement.PowerEffect;
                }

                return this._power + supplementsBonus;
            }
        }
        public virtual int Aggression
        {
            get
            {
                int supplementsBonus = 0;
                foreach (var supplement in this._supplements)
                {
                    supplementsBonus += supplement.AggressionEffect;
                }

                return this._aggression + supplementsBonus;
            }
        }

        public void DecreaseBaseHealth(int quantity)
        {
            this._health -= quantity;
        }

        public virtual void AddSupplement(ISupplement newSupplement)
        {
            foreach (var supplement in this._supplements)
            {
                newSupplement.ReactTo(supplement);
            }

            this._supplements.Add(newSupplement);
        }

        public UnitClassifications ClassificationToInteract
        {
            get { return this._classificationToInteract; }
        }

        public bool CanInfest
        {
            get { return _canInfest; }
        }

        public void DecreaseHealth(int val)
        {
            this._health -= val;
        }
        public override string ToString()
        {
            StringBuilder supplementsBuilder = new StringBuilder();
            foreach (var supplement in this._supplements)
            {
                supplementsBuilder.Append(supplement.GetType().Name + ", ");
            }

            if (supplementsBuilder.Length != 0)
            {
                supplementsBuilder.Remove(supplementsBuilder.Length - ", ".Length, ", ".Length); //removing the excess comma-space, coming from the foreach loop above (", ")
            }
            string unitSignature = this.GetType().Name + " " + this.Id + " (" + this.UnitClassification + ")";

            return String.Format("{0} [Health: {1}, Power: {2}, Aggression: {3}, Supplements: [{4}]]",
                unitSignature, this.Health, this.Power, this.Aggression, supplementsBuilder);
        }
    }
}
