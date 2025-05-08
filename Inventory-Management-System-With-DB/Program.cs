using System;
using System.Collections.Generic;
using Inventory_Management_System.Interfaces;
using Inventory_Management_System.Models;
using Inventory_Management_System.Services;
using Microsoft.Extensions.DependencyInjection;


namespace Inventory_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var factory = new InventoryFactory(); 

            IInventory dbInstance = null;
            while (dbInstance == null)
            {
                Console.Write("Choose your database (SQL/Mongo): ");
                string dbChoice = Console.ReadLine();
                dbInstance = factory.Create(dbChoice);
            }

            var inventory = new Inventory(dbInstance);
            string product_name;
            

            while (true)
            {
                Console.WriteLine("Inventory Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View all products");
                Console.WriteLine("3. Edit a product");
                Console.WriteLine("4. Delete a product");
                Console.WriteLine("5. Search for a product");
                Console.WriteLine("6. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        string name;
                        while (true)
                        {
                            Console.Write("Enter the name of the product: ");
                           name = Console.ReadLine();

                            if (string.IsNullOrEmpty(name))
                            {
                                Console.WriteLine("Product name cannot be empty. Please enter a valid name.");
                            }
                            else
                            {
                                break; 
                            }
                        }
                        decimal price;
                        Console.Write("Enter the price of the product: ");
                        while (!decimal.TryParse(Console.ReadLine(), out price) || price < 0)
                        {
                            Console.Write("Invalid price input. Please enter a valid price: ");
                        }

                        decimal quantity;
                        Console.Write("Enter the quantity of the product: ");
                        while (!decimal.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
                        {
                            Console.Write("Invalid quantity input. Please enter a valid quantity: ");
                        }

                        inventory.AddProduct(new Product(name, price, quantity));
                        break;

                    case "2":
                        List<Product> products = inventory.ViewProducts();
                        if (products.Count == 0)
                        {
                            Console.WriteLine("No products found.");
                        }
                        else
                        {
                            Console.WriteLine("All Products:");
                            foreach (var p in products)
                            {
                                Console.WriteLine($"Name: {p.Name}, Price: {p.Price}, Quantity: {p.Quantity}");
                            }
                        }

                        break;

                    case "3":
                        Console.Write("Enter the name of the product you want to edit: ");
                        product_name = Console.ReadLine();
                        inventory.EditProduct(product_name);
                        break;

                    case "4":
                        Console.Write("Enter the name of the product you want to delete: ");
                        product_name = Console.ReadLine();
                        inventory.DeleteProduct(product_name);
                        break;

                    case "5":
                        Console.Write("Enter the name of the product you want to search: ");
                         product_name = Console.ReadLine();
                        Product foundProduct = inventory.search_for_product(product_name);
                        if (foundProduct != null)
                        {
                            Console.WriteLine($"Product found: Name: {foundProduct.Name}, Price: {foundProduct.Price}, Quantity: {foundProduct.Quantity}");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }

                        break;

                    case "6":
                        Console.WriteLine("Exiting the application...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}