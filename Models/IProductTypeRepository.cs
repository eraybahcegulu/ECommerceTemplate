

namespace ECommerceTemplate.Models
{
    public interface IProductTypeRepository : IRepository<ProductType>
    {
        void Update(ProductType productType);
        void Save();
    }
}
