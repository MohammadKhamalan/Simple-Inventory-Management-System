using Inventory_Management_System.Models;
using System.Collections.Generic;

namespace Inventory_Management_System.Interfaces
{
    public interface IInventory
    {
        void AddProduct(Product product);
        List<Product> GetAllProducts();                        
        Product SearchProduct(string productName);             
        void UpdateProduct(string oldName, Product updated);   
        void DeleteProduct(string productName);
    }
}
