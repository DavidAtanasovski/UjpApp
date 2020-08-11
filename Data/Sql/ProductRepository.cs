using Core;
using Data.Interface;

namespace Data.Sql
{
    public class ProductRepository : IProductRepository
    {
        private readonly UjpDbContext ujpDbContext;

        public ProductRepository(UjpDbContext ujpDbContext)
        {
            this.ujpDbContext = ujpDbContext;
        }

        public void Commit()
        {
            ujpDbContext.SaveChanges();
        }

        public void Create(Product product)
        {
            ujpDbContext.Products.Add(product);
        }
    }
}
