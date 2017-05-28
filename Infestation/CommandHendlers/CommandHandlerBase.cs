namespace Infestation.CommandHendlers
{
    using System;

    public abstract class CommandHandlerBase : ICommandHandler
    {
        private ICommandHandlerProcessor Successor { get; set; }

        public virtual string ProcessCommand(string command)
        {
            if (this.CanHandle(command))
            {
                return this.ProccessCommandInternal(command);
            }

            if (this.Successor != null)
            {
                return this.Successor.ProcessCommand(command);
            }

            throw new InvalidOperationException();
        }

        public virtual void SetSuccessor(ICommandHandlerProcessor commandHandler)
        {
            this.Successor = commandHandler;
        }

        protected abstract bool CanHandle(string command);

        protected abstract string ProccessCommandInternal(string command);
    }
}