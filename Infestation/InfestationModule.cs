namespace Infestation
{
    using CommandHendlers;
    using Factories;
    using Interactions;
    using Ninject;
    using Ninject.Extensions.Factory;
    using Ninject.Modules;
    using Providers;
    using Supplements;
    using Units;

    public class InfestationModule : NinjectModule
    {
        private const string InsertCommandHandlerName = "InsertCommandHandlerName";
        private const string ProceedCommandHandlerName = "ProceedCommandHandlerName";
        private const string StatusCommandHandlerName = "StatusCommandHandlerName";
        private const string SupplementCommandHandlerName = "SupplementCommandHandlerName";

        public override void Load()
        {
            Bind(typeof(IWriter), typeof(IReader), typeof(IInputOutputProvider))
                .To<ConsoleProvider>()
                .InSingletonScope();

            Bind<ICommand>().To<Command>();

            Bind<ISupplement>().To<AggressionCatalyst>();
            Bind<ISupplement>().To<HealthCatalyst>();
            Bind<ISupplement>().To<InfestationSpores>();
            Bind<ISupplement>().To<PowerCatalyst>();
            Bind<ISupplement>().To<Weapon>();
            Bind<ISupplement>().To<WeaponrySkill>();

            Bind<IInteraction>().To<AttackInteraction>();
            Bind<IInteraction>().To<InfestInteraction>();

            Bind<IUnit>().To<Dog>();
            Bind<IUnit>().To<Human>();
            Bind<IUnit>().To<Marine>();
            Bind<IUnit>().To<Parasite>();
            Bind<IUnit>().To<Queen>();
            Bind<IUnit>().To<Tank>();

            Bind(typeof(IInsertUnit), typeof(ITakeUnit), typeof(ITakeUnitsStatuses), typeof(ITakeInteractions)).To<UnitProvider>().InSingletonScope();

            Bind<ICommandFactory>().To<CommandFactory>();
            Bind<ISupplementFactory>().To<SupplementFactory>().InSingletonScope();
            Bind<IInteractionFactory>().To<InteractionFactory>().InSingletonScope();
            Bind<IUnitFactory>().To<UnitFactory>().InSingletonScope();

            Bind<IHoldingPen>().To<HoldingPen>().InSingletonScope();

            Bind<ICommandHandler>().To<InsertCommandHandler>().Named(InsertCommandHandlerName);
            Bind<ICommandHandler>().To<ProceedCommandHandler>().Named(ProceedCommandHandlerName);
            Bind<ICommandHandler>().To<StatusCommandHandler>().Named(StatusCommandHandlerName);
            Bind<ICommandHandler>().To<SupplementCommandHandler>().Named(SupplementCommandHandlerName);

            Bind<ICommandHandlerProcessor>().ToMethod(context =>
            {
                ICommandHandler insertCommandHandler = context.Kernel.Get<ICommandHandler>(InsertCommandHandlerName);
                ICommandHandler proceedCommandHandler = context.Kernel.Get<ICommandHandler>(ProceedCommandHandlerName);
                ICommandHandler statusCommandHandler = context.Kernel.Get<ICommandHandler>(StatusCommandHandlerName);
                ICommandHandler supplementCommandHandler = context.Kernel.Get<ICommandHandler>(SupplementCommandHandlerName);

                insertCommandHandler.SetSuccessor(proceedCommandHandler);
                proceedCommandHandler.SetSuccessor(statusCommandHandler);
                statusCommandHandler.SetSuccessor(supplementCommandHandler);

                return insertCommandHandler;
            }).WhenInjectedInto<HoldingPen>();


        }
    }
}
