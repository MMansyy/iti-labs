using Ecommerce_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Project.Views.ViewModels
{
    public class CheckOutVM
    {

        [Required(ErrorMessage = "You have to choose one address")]
        public int AddressId { get; set; }

        public List<Address> Addresses { get; set; } = new List<Address>();


        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public decimal SubTotal => CartItems.Sum(i => i.Total);

        public decimal ShippingCost { get; set; } = 50;

        public decimal Total => SubTotal + ShippingCost;
    }
}
