namespace Factories.Interfaces
{
    public interface IFactory<TProduct>
        where TProduct : IFactoryProduct
    {
        public abstract TProduct CreateProduct();
    }
}
