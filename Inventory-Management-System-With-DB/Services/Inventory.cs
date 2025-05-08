using System;
using System.Collections.Generic;
using Inventory_Management_System.Models;
using Inventory_Management_System.Interfaces;
using Inventory_Management_System.DataBaseConnection;

namespace Inventory_Management_System.Services
{

    public class Inventory
    {
        private readonly IInventory _inventoryDb;

        public Inventory(IInventory inventoryDb)
        {
            _inventoryDb = inventoryDb;
        }

        public void AddProduct(Product product)
        {
            try
            {
                _inventoryDb.AddProduct(product);
                Console.WriteLine($"Product {product.Name} added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to add product. Error: {ex.Message}");
            }
        }

        public List<Product> ViewProducts() => _inventoryDb.GetAllProducts();

        public Product search_for_product(string name) => _inventoryDb.SearchProduct(name);

        public void EditProduct(string oldName)
        {
            Product existingProduct = _inventoryDb.SearchProduct(oldName);
            if (existingProduct == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.WriteLine($"Editing {existingProduct.Name} product");

            Console.Write("Enter new name (leave empty to keep current): ");
            string new_name = Console.ReadLine();
            if (!string.IsNullOrEmpty(new_name))
                existingProduct.Name = new_name;

            Console.Write("Enter new price (leave empty to keep current): ");
            string new_price = Console.ReadLine();
            if (decimal.TryParse(new_price, out decimal price))
                existingProduct.Price = price;

            Console.Write("Enter new quantity (leave empty to keep current): ");
            string new_quantity = Console.ReadLine();
            if (decimal.TryParse(new_quantity, out decimal quantity))
                existingProduct.Quantity = quantity;

            _inventoryDb.UpdateProduct(oldName, existingProduct);
            Console.WriteLine("Product updated successfully.");
        }

        public void DeleteProduct(string name)
        {
            Product existingProduct = _inventoryDb.SearchProduct(name);
            if (existingProduct == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            _inventoryDb.DeleteProduct(name);
            Console.WriteLine($"Product {name} deleted successfully.");
        }
    }

}
