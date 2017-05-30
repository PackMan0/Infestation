namespace Infestation.CommandHendlers
{
    using System;
    using Enums;
    using Providers;

    public class Command : ICommand
    {
        private string _unitId;
        private CommandTypes _commandType;
        private UnitTypes _unitType;
        private SupplementTypes _supplementType;
        private readonly IWriter _writer;

        public Command(IWriter writer)
        {
            this._writer = writer;
        }

        public CommandTypes CommandType
        {
            get { return _commandType; }
        }

        public UnitTypes UnitType
        {
            get { return _unitType; }
        }

        public SupplementTypes SupplementType
        {
            get { return _supplementType; }
        }

        public string UnitId
        {
            get { return _unitId; }
        }

        public bool TranslateInput(string input)
        {
            var commandParams = input.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);

            if (commandParams.Length > 0)
            {
                var commandType = char.ToUpper(commandParams[0][0]) + commandParams[0].Substring(1);

                if (Enum.TryParse(commandType, out this._commandType))
                {
                    if (commandParams.Length > 1)
                    {
                        if (Enum.TryParse(commandParams[1], out this._unitType) || Enum.TryParse(commandParams[1], out this._supplementType))
                        {
                            this._unitId = commandParams[2];
                            return true;
                        }
                        else
                        {
                            this._writer.Write("Wrong second command parameter!");
                            return false;
                        }
                    }
                }
                else
                {
                    this._writer.Write("Wrong command!");
                    return false;
                }
            }

            return false;

        }
    }
}
