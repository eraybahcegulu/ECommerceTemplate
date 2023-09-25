using ECommerceTemplate.Utility;

namespace ECommerceTemplate.Models
{
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public ProductTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Update(ProductType productType)
        {
            _applicationDbContext.Update(productType);
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
