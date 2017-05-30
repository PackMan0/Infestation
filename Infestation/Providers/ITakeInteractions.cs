namespace Infestation.Providers
{
    using System.Collections.Generic;
    using Interactions;
    using Units;

    public interface ITakeInteractions
    {
        ICollection<IInteraction> TakeInteractions();
    }
}
