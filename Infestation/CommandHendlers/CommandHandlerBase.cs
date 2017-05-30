namespace Infestation.CommandHendlers
{
    using System;

    public abstract class CommandHandlerBase : ICommandHandler
    {
        private ICommandHandlerProcessor Successor { get; set; }

        public virtual void ProcessCommand(ICommand command)
        {
            if (this.CanHandle(command))
            {
                this.ProccessCommandInternal(command);
            }
            else if (this.Successor != null)
            {
                this.Successor.ProcessCommand(command);
            }
        }

        public virtual void SetSuccessor(ICommandHandlerProcessor commandHandler)
        {
            this.Successor = commandHandler;
        }

        protected abstract bool CanHandle(ICommand command);

        protected abstract void ProccessCommandInternal(ICommand command);
    }
}