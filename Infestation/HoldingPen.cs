namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enums;
    using Interactions;
    using Units;

    public class HoldingPen
    {
        public void ParseCommand(string command)
        {
            string[] commandWordSeparators = new string[] { " " };

            string[] commandWords = command.Split(commandWordSeparators, StringSplitOptions.RemoveEmptyEntries);

            DispatchCommand(commandWords);

        }

        protected virtual void DispatchCommand(string[] commandWords)
        {
            switch (commandWords[0])
            {
                case "insert":
                    this.ExecuteInsertUnitCommand(commandWords);
                    break;
                case "proceed":
                    this.ExecuteProceedSingleIterationCommand();
                    break;
                case "supplement":
                    this.ExecuteAddSupplementCommand(commandWords);
                    break;
                case "status":
                    this.ExecutePrintStatusCommand();
                    break;
                default:
                    break;
            }
        }

        protected virtual void ExecuteProceedSingleIterationCommand()
        {
            var containedUnitsInfo = this.containedUnits.Select((unit) => unit.Info);

            IEnumerable<InteractionBase> requestedInteractions =
                from unit in this.containedUnits
                select unit.DecideInteraction(containedUnitsInfo);

            requestedInteractions = requestedInteractions.Where((interaction) => interaction != InteractionBase.PassiveInteraction);

            foreach (var interaction in requestedInteractions)
            {
                this.ProcessSingleInteraction(interaction);
            }

            this.containedUnits.RemoveAll((unit) => unit.IsDestroyed);
        }

        protected virtual void ProcessSingleInteraction(InteractionBase interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Attack:
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);

                    targetUnit.DecreaseBaseHealth(interaction.SourceUnit.Power);
                    break;
                default:
                    break;
            }
        }
    }
}
