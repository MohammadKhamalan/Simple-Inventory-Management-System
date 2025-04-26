using Inventory_Management_System.Interfaces;

namespace Inventory_Management_System.Models
{
    public class Product : IProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}, Quantity: {Quantity}";
        }
    }
}
