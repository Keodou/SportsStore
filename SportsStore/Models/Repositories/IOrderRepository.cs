using SportsStore.Models.Entities;

namespace SportsStore.Models.Repositories
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
