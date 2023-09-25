using ECommerceTemplate.Utility;
using System.Drawing;

namespace ECommerceTemplate.Models
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public ProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Update(Product product)
        {
            _applicationDbContext.Update(product);
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
