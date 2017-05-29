namespace Infestation.Factories
{
    using Enums;
    using Supplements;

    public interface ISupplementFactory
    {
        ISupplement CreateSupplement(SupplementTypes type);
    }
}