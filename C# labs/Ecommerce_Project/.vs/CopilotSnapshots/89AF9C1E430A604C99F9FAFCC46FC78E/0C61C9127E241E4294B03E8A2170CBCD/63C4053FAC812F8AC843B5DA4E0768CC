using Ecommerce_Project.Models;

namespace Ecommerce_Project.Repositories
{
    public interface IUnitOfWork
    {
        IEntities<Product> Products { get; }
        IEntities<Category> Categories { get; }
        IEntities<Order> Orders { get; }
        IEntities<OrderItem> OrderItems { get; }
        IEntities<Address> Addresses { get; }

        Task SaveAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
