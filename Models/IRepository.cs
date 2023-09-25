using System.Linq.Expressions;

namespace ECommerceTemplate.Models
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProps = null);
        T Get(Expression<Func<T, bool>> filtre, string? includeProps = null);
        void Add(T entitiy);
        void Remove(T entitiy);
        void RemoveRange(IEnumerable<T> entities);
    }
}
