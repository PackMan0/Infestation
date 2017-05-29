namespace Infestation.Providers
{
    using System.Collections.Generic;

    public interface ITakeUnitsStatuses
    {
        IEnumerable<string> TakeUnitsStatuses();
    }
}
