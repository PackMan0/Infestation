using Infestation.Units;

namespace Infestation.Interactions
{
    public interface IInteraction
    {
        IUnit SourceUnit { get; }
        IUnit TargetUnit { get; }

        void ExecuteInteraction();
    }
}