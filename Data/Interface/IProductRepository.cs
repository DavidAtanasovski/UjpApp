using Core;

namespace Data.Interface
{
    public interface IProductRepository
    {
        void Create(Product product);
        void Commit();
    }
}
