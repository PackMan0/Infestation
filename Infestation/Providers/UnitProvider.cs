namespace Infestation.Providers
{
    using System.Collections.Generic;
    using System.Linq;
    using Factories;
    using Interactions;
    using Units;

    public class UnitProvider : IInsertUnit, ITakeUnit, ITakeUnitsStatuses, ITakeInteractions
    {
        private IDictionary<string, IUnit> _units;
        private readonly IInteractionFactory _interactionFactory;

        public UnitProvider(IInteractionFactory interactionFactory)
        {
            this._interactionFactory = interactionFactory;
            this._units = new Dictionary<string, IUnit>();
        }

        public UnitProvider()
        {
            this._units =new Dictionary<string, IUnit>();
        }
        public void InsertUnit(IUnit unit)
        {
            if (!this._units.ContainsKey(unit.Id))
            {
                this._units.Add(unit.Id, unit);

                this._units = this._units.Where(u => u.Value.Health >= 0).OrderBy(u => u.Value.Health).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }

        public IUnit TakeUnit(string id)
        {
            return this._units.FirstOrDefault(u => u.Key == id).Value;
        }
        public IEnumerable<string> TakeUnitsStatuses()
        {
            return this._units.Where(u => u.Value.Health >= 0).Select(u => u.ToString());
        }

        public ICollection<IInteraction> TakeInteractions()
        {
            var interactions = new List<IInteraction>();

            foreach (var sorceUnit in this._units)
            {
                var targetUnit =
                    this._units.FirstOrDefault(u => u.Value.Id != sorceUnit.Value.Id && u.Value.UnitClassification == sorceUnit.Value.ClassificationToInteract).Value;

                if (targetUnit != null)
                {
                    interactions.Add(this._interactionFactory.GetInteraction(sorceUnit.Value, targetUnit));
                }
            }

            return interactions;
        }
    }
}
