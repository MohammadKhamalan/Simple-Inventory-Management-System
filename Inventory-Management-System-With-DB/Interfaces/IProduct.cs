using System;

namespace Inventory_Management_System.Interfaces
{
    public interface IProduct
    {
        string Name { get; set; }
        decimal Price { get; set; }
        decimal Quantity { get; set; }
        string ToString();
    }
}
