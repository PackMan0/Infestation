namespace Infestation.Factories
{
    using Enums;
    using Supplements;

    public interface ISupplementFactory
    {
        ISupplement GetSupplement(SupplementTypes type);
    }
}