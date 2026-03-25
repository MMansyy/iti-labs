using Ecommerce_Project.Models;

namespace Ecommerce_Project.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _context;
        public IEntities<Product> Products { get; }
        public IEntities<Category> Categories { get; }
        public IEntities<Order> Orders { get; }
        public IEntities<OrderItem> OrderItems { get; }
        public IEntities<Address> Addresses { get; }
        public UnitOfWork(DBContext context)
        {
            _context = context;
            Products = new EntityRepo<Product>(_context);
            Categories = new EntityRepo<Category>(_context);
            Orders = new EntityRepo<Order>(_context);
            OrderItems = new EntityRepo<OrderItem>(_context);
            Addresses = new EntityRepo<Address>(_context);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();

        }


        public async Task RollbackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }
    }
}
