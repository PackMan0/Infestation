namespace Infestation.CommandHendlers
{
    using System;
    using Factories;

    public class InsertCommand : CommandHandlerBase
    {
        private readonly IUnitFactory unitFactory;

        public InsertCommand(IUnitFactory unitFactory)
        {
            this.unitFactory = unitFactory;
        }

        protected override bool CanHandle(string command)
        {
            return command == "insert";
        }

        protected override string ProccessCommandInternal(string command)
        {
            throw new NotImplementedException();
        }
    }
}
