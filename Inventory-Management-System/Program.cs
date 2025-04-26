using System;
using Inventory_Management_System.Models;
using Inventory_Management_System.Services;

namespace Inventory_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            var inventory = new Inventory();
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
                        Console.Write("Enter the name of the product: ");
                        string name = Console.ReadLine();

                        decimal price;
                        Console.Write("Enter the price of the product: ");
                        while (!decimal.TryParse(Console.ReadLine(), out price) || price < 0)
                        {
                            Console.Write("Invalid price input. Please enter a valid price: ");
                        }

                        int quantity;
                        Console.Write("Enter the quantity of the product: ");
                        while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
                        {
                            Console.Write("Invalid quantity input. Please enter a valid quantity: ");
                        }

                        inventory.Add_product(new Product(name, price, quantity));
                        break;

                    case "2":
                        inventory.View_products();
                        break;

                    case "3":
                        Console.Write("Enter the name of the product you want to edit: ");
                        product_name = Console.ReadLine();
                        inventory.Edit_product(product_name);
                        break;

                    case "4":
                        Console.Write("Enter the name of the product you want to delete: ");
                        product_name = Console.ReadLine();
                        inventory.Delete_product(product_name);
                        break;

                    case "5":
                        Console.Write("Enter the name of the product you want to search: ");
                        product_name = Console.ReadLine();
                        inventory.search_for_product(product_name);
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
