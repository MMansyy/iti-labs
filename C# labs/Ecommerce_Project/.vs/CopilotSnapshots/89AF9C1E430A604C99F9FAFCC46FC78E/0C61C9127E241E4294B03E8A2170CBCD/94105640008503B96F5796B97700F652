using Ecommerce_Project.Models;
using Ecommerce_Project.Repositories;
using Ecommerce_Project.Views.ViewModels;

namespace Ecommerce_Project.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICartService cartService;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(ICartService _cartService, IUnitOfWork _unitOfWork)
        {
            cartService = _cartService;
            unitOfWork = _unitOfWork;
        }

        // =============================
        // Checkout VM
        // =============================

        public Task<CheckOutVM> GetCheckoutVMAsync(string userId)
        {
            var addresses = unitOfWork.Addresses
                .GetAll(a => a.UserId == userId)
                .ToList();

            var cartItems = cartService.GetCartItems();

            return Task.FromResult(new CheckOutVM
            {
                Addresses = addresses,
                CartItems = cartItems
            });
        }

        // =============================
        // Create Order
        // =============================

        public async Task CreateOrderAsync(string userId, CheckOutVM model)
        {
            var cart = cartService.GetCartItems();

            if (cart == null || !cart.Any())
                throw new Exception("Cart is empty");

            await unitOfWork.BeginTransactionAsync();

            try
            {
                var productIds = cart.Select(c => c.ProductId).ToList();
                var products = unitOfWork.Products
                    .GetAll(p => productIds.Contains(p.ProductId))
                    .ToList();

                var productDict = products.ToDictionary(p => p.ProductId);

                foreach (var item in cart)
                {
                    var product = productDict[item.ProductId];
                    if (item.Quantity > product.StockQuantity)
                        throw new Exception($"'{product.Name}' only has {product.StockQuantity} in stock");
                }

                decimal total = cart.Sum(item => productDict[item.ProductId].Price * item.Quantity);

                var order = new Order
                {
                    UserId = userId,
                    ShippingAddressId = model.AddressId,
                    TotalAmount = total,
                    Status = 0,
                    OrderDate = DateTime.UtcNow
                };

                unitOfWork.Orders.Add(order);
                await unitOfWork.SaveAsync();

                foreach (var item in cart)
                {
                    var product = productDict[item.ProductId];

                    unitOfWork.OrderItems.Add(new OrderItem
                    {
                        OrderId = order.OrderId,
                        ProductId = product.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = product.Price
                    });

                    product.StockQuantity -= item.Quantity;
                    unitOfWork.Products.Update(product);
                }

                await unitOfWork.SaveAsync();
                await unitOfWork.CommitTransactionAsync();

                cartService.ClearCart();
            }
            catch
            {
                await unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        // =============================
        // Get Orders
        // =============================

        public Task<List<Order>> GetUserOrdersAsync(string userId)
        {
            var orders = unitOfWork.Orders
                .GetAll(o => o.UserId == userId, "OrderItems,OrderItems.Product,ShippingAddress")
                .OrderByDescending(o => o.OrderDate)
                .ToList();

            return Task.FromResult(orders);
        }

        public Task<List<Order>> GetAllOrdersAsync()
        {
            var orders = unitOfWork.Orders
                .GetAll(null, "User,ShippingAddress,OrderItems")
                .OrderByDescending(o => o.OrderDate)
                .ToList();

            return Task.FromResult(orders);
        }

        public Task<Order?> GetOrderDetailsAsync(int orderId, string currentUserId, string currentUserRole)
        {
            if (orderId < 0)
                throw new ArgumentException("Invalid order ID");

            var order = unitOfWork.Orders
                .GetAll(o => o.OrderId == orderId, "OrderItems,OrderItems.Product,ShippingAddress,User")
                .FirstOrDefault();

            if (order == null)
                return Task.FromResult<Order?>(null);

            if (order.UserId != currentUserId && currentUserRole != "Admin")
                throw new UnauthorizedAccessException("You are not authorized to view this order");

            return Task.FromResult<Order?>(order);
        }

        // =============================
        // Update Status
        // =============================

        public async Task UpdateOrderStatusAsync(int orderId, int status)
        {
            var order = unitOfWork.Orders.GetById(orderId);
            if (order == null)
                throw new Exception("Order not found");

            order.Status = status;
            unitOfWork.Orders.Update(order);
            await unitOfWork.SaveAsync();
        }
    }
}
