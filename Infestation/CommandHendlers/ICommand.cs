namespace Infestation.CommandHendlers
{
    using System.Collections.Generic;
    using Enums;

    public interface ICommand
    {
        CommandTypes CommandType { get; }

        UnitTypes UnitType { get; }

        SupplementTypes SupplementType { get; }

        string UnitId { get; }

        bool TranslateInput(string input);
    }
}
