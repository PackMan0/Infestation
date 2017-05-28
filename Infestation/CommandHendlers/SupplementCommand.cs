namespace Infestation.CommandHendlers
{
    using System;
    using Factories;

    public class SupplementCommand : CommandHandlerBase
    {
        private readonly ISupplementFactory supplementFactory;

        public SupplementCommand(ISupplementFactory supplementFactory)
        {
            this.supplementFactory = supplementFactory;
        }
        protected override bool CanHandle(string command)
        {
            return command == "supplement";
        }

        protected override string ProccessCommandInternal(string command)
        {
            throw new NotImplementedException();
        }
    }
}
