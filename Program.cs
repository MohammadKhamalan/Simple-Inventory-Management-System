using System;

namespace Simple_Inventory_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Inventory inventory = new Inventory();
            string product_name;


            while (true)
            {
                Console.WriteLine("\nInventory Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View all products");
                Console.WriteLine("3. Edit a product");
                Console.WriteLine("4. Delete a product:");
                Console.WriteLine("5. Search for a product");
                Console.WriteLine("6. Exit");
                String choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter the name of the product:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the price of the product:");
                        decimal price;
                        while (true)
                        {

                            string price_input=Console.ReadLine();
                            if (decimal.TryParse(price_input, out price) && price >= 0)

                            {
                                break;
                            }
                                Console.WriteLine("Invalid price input, please enter valid price:");
                                
                            }
                        
                        int quantity;
                        Console.WriteLine("Enter the Quantity of the product:");
                        while (true)
                        {
                            
                            string quantity_input = Console.ReadLine();
                            
                            if (int.TryParse(quantity_input, out quantity) && quantity >= 0)
                            {
                                break;
                            }
                                Console.WriteLine("Invalid Quantity input. Please enter valid Quantity:");
                                
                            
                        }
                        inventory.Add_product(new Product(name, price, quantity));
                        break;

                    case "2":
                        inventory.View_products();
                        break;
                    case "3":
                        Console.WriteLine("Enter the name of the product you want to edit:");
                         product_name = Console.ReadLine();
                        inventory.Edit_product(product_name);
                        break;
                    case "4":
                        Console.WriteLine("Enter the name of the product you want to Delete:");
                         product_name = Console.ReadLine();
                        inventory.Delete_product(product_name);
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
