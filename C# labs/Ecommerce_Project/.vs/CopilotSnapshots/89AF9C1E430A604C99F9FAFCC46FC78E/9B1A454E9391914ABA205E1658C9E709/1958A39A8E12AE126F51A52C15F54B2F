using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_Project.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int ShippingAddressId { get; set; }

        public string OrderNum { get; set; }

        public int Status { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; } = 0;


        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        [ForeignKey(nameof(ShippingAddressId))]
        public virtual Address ShippingAddress { get; set; } = null!;

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();


        public Order()
        {
            OrderDate = DateTime.Now;
            TotalAmount = 0;
            OrderNum = Guid.NewGuid().ToString();
        }

    }
}
