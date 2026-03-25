using Ecommerce_Project.Models;

namespace Ecommerce_Project.Views.ViewModels
{
    public class SettingsVM
    {
        public List<Order> Orders { get; set; } = new();
        public List<Address> Addresses { get; set; } = new();
        public string ActiveTab { get; set; } = "orders";
    }
}