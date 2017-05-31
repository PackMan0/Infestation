namespace Infestation
{
    using System.Collections.Generic;
    using System.Linq;
    using CommandHendlers;
    using Enums;
    using Factories;
    using Interactions;
    using Ninject;
    using Ninject.Extensions.Factory;
    using Ninject.Modules;
    using Ninject.Parameters;
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

            Bind<ICommandFactory>().ToFactory().InSingletonScope();
            Bind<ICommand>().ToMethod(context =>
            {
                return context.Kernel.Get<Command>();
            }).NamedLikeFactoryMethod((ICommandFactory commandFactory) => commandFactory.GetCommand());

            Bind<ISupplementFactory>().ToFactory().InSingletonScope();
            Bind<ISupplement>().ToMethod(context =>
            {
                SupplementTypes supplementType =
                    (SupplementTypes)context.Parameters.Single().GetValue(context, null);

                switch (supplementType)
                {
                    case SupplementTypes.AggressionCatalyst:
                        return context.Kernel.Get<HealthCatalyst>();
                        case SupplementTypes.HealthCatalyst:
                        return context.Kernel.Get<HealthCatalyst>();
                    case SupplementTypes.InfestationSpores:
                        return context.Kernel.Get<InfestationSpores>();
                    case SupplementTypes.PowerCatalyst:
                        return context.Kernel.Get<PowerCatalyst>();
                    case SupplementTypes.Weapon:
                        return context.Kernel.Get<Weapon>();
                    case SupplementTypes.WeaponrySkill:
                        return context.Kernel.Get<WeaponrySkill>();
                    default:
                        return null;
                }


            }).NamedLikeFactoryMethod((ISupplementFactory supplementFactory) => supplementFactory.GetSupplement(SupplementTypes.None));

            Bind<IInteractionFactory>().ToFactory().InSingletonScope();
            Bind<IInteraction>().ToMethod(context =>
                {
                    var  methodParams = context.Parameters;

                    if (((IUnit)methodParams.First().GetValue(context,null)).CanInfest)
                    {
                        methodParams.Add(new ConstructorArgument("supplement", context.Kernel.Get<InfestationSpores>()));

                        return context.Kernel.Get<InfestInteraction>(methodParams.ToArray());
                    }
                    else
                    {
                        return context.Kernel.Get<AttackInteraction>(methodParams.ToArray());
                    }
                }).NamedLikeFactoryMethod((IInteractionFactory interactionFactory) => interactionFactory.GetInteraction(null, null));

            Bind<IUnitFactory>().ToFactory().InSingletonScope();
            Bind<IUnit>().ToMethod(context =>
            {
                var unitType = (UnitTypes)context.Parameters.First().GetValue(context,null);
                var unitArg = new List<IParameter>() {context.Parameters.Last()};

                switch (unitType)
                {
                    case UnitTypes.Dog:
                        return context.Kernel.Get<Dog>(unitArg.ToArray());
                    case UnitTypes.Human:
                        return context.Kernel.Get<Human>(unitArg.ToArray());
                    case UnitTypes.Marine:
                        unitArg.Add(new ConstructorArgument("defaultSupplement", context.Kernel.Get<WeaponrySkill>()));
                        return context.Kernel.Get<Marine>(unitArg.ToArray());
                    case UnitTypes.Parasite:
                        return context.Kernel.Get<Parasite>(unitArg.ToArray());
                    case UnitTypes.Queen:
                        return context.Kernel.Get<Queen>(unitArg.ToArray());
                    case UnitTypes.Tank:
                        return context.Kernel.Get<Tank>(unitArg.ToArray());
                    default:
                        return null;
                }

            }).NamedLikeFactoryMethod((IUnitFactory unitFactory) => unitFactory.GetUnit(UnitTypes.None, null));

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
