using System;
using System.Collections.Generic;
using Inventory_Management_System.Models;
using Inventory_Management_System.Interfaces;

namespace Inventory_Management_System.Services
{
    public class Inventory : IInventory
    {
        public List<Product> products = new List<Product>();

        public void Add_product(Product product)
        {
            products.Add(product);
            Console.WriteLine($"Product {product.Name} added successfully.");
        }

        public void View_products()
        {
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
            Product product = products.Find(p => p.Name.Equals(product_name, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.WriteLine($"Editing {product.Name} product");
            Console.Write("Enter new name (leave empty to keep current): ");
            string new_name = Console.ReadLine();
            if (!string.IsNullOrEmpty(new_name))
                product.Name = new_name;

            while (true)
            {
                Console.Write("Enter new price (leave empty to keep current): ");
                string new_price = Console.ReadLine();
                if (string.IsNullOrEmpty(new_price)) break;

                if (decimal.TryParse(new_price, out decimal price) && price >= 0)
                {
                    product.Price = price;
                    break;
                }
                Console.Write("Invalid price. ");
            }

            while (true)
            {
                Console.Write("Enter new quantity (leave empty to keep current): ");
                string new_quantity = Console.ReadLine();
                if (string.IsNullOrEmpty(new_quantity)) break;

                if (int.TryParse(new_quantity, out int quantity) && quantity >= 0)
                {
                    product.Quantity = quantity;
                    break;
                }
                Console.Write("Invalid quantity.");
            }
        }

        public void Delete_product(string product_name)
        {
            Product product = products.Find(p => p.Name.Equals(product_name, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            products.Remove(product);
            Console.WriteLine($"Product {product.Name} deleted successfully.");
        }

        public void search_for_product(string product_name)
        {
            Product product = products.Find(p => p.Name.Equals(product_name, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.WriteLine($"Product Found:\nName: {product.Name}\nPrice: {product.Price}\nQuantity: {product.Quantity}");
        }
    }
}
