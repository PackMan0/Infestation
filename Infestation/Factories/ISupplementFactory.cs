namespace Infestation.Factories
{
    using Supplements;

    public interface ISupplementFactory
    {
        ISupplement CreateSupplement(string type);
    }
}