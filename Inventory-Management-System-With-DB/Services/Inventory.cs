using System;
using System.Collections.Generic;
using Inventory_Management_System.Models;
using Inventory_Management_System.Interfaces;
using Inventory_Management_System.DataBaseConnection;

namespace Inventory_Management_System.Services
{
    public class Inventory : IInventory
    {
        private readonly InventorySql _dbConnection;

        public Inventory()
        {
            _dbConnection = new InventorySql();
        }


        public void Add_product(Product product)
        {
            _dbConnection.AddProduct(product);
            Console.WriteLine($"Product {product.Name} added successfully.");
        }

        public void View_products()
        {
            var products = _dbConnection.GetAllProducts();

            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }

            Console.WriteLine("\nList of products:");
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }

        public void Edit_product(string product_name)
        {
            var existingProduct = _dbConnection.SearchProduct(product_name);
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

            while (true)
            {
                Console.Write("Enter new price (leave empty to keep current): ");
                string new_price = Console.ReadLine();
                if (string.IsNullOrEmpty(new_price)) break;

                if (decimal.TryParse(new_price, out decimal price) && price >= 0)
                {
                    existingProduct.Price = price;
                    break;
                }
                Console.Write("Invalid price. ");
            }

            while (true)
            {
                Console.Write("Enter new quantity (leave empty to keep current): ");
                string new_quantity = Console.ReadLine();
                if (string.IsNullOrEmpty(new_quantity)) break;

                if (decimal.TryParse(new_quantity, out decimal quantity) && quantity >= 0)
                {
                    existingProduct.Quantity = quantity;
                    break;
                }
                Console.Write("Invalid quantity.");
            }

            _dbConnection.UpdateProduct(product_name, existingProduct);
            Console.WriteLine("Product updated successfully.");
        }

        public void Delete_product(string product_name)
        {
            var existingProduct = _dbConnection.SearchProduct(product_name);
            if (existingProduct == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            _dbConnection.DeleteProduct(product_name);
            Console.WriteLine($"Product {product_name} deleted successfully.");
        }

        public void search_for_product(string product_name)
        {
            var product = _dbConnection.SearchProduct(product_name);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.WriteLine($"Product Found:\nName: {product.Name}\nPrice: {product.Price}\nQuantity: {product.Quantity}");
        }
    }
}