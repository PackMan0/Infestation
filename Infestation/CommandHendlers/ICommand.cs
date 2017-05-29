namespace Infestation.CommandHendlers
{
    using System.Collections.Generic;
    using Enums;

    public interface ICommand
    {
        CommandTypes Type { get; }

        List<string> Parameters { get; }
    }
}
