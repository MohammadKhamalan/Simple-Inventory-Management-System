using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Inventory_Management_System
{
    class Inventory
    {
        public List<Product> products = new List<Product>();

        public void Add_product(Product product)
        {
            products.Add(product);
            Console.WriteLine($"product {product.Get_Name()} added successfully");
        }
        public void View_products()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }
            Console.WriteLine("\n List of products:");
            foreach(var product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }

        public void Edit_product(string product_name)
        {
            Product product = products.Find((p => p.Get_Name().Equals(product_name, StringComparison.OrdinalIgnoreCase)));
            if (product == null)
            {
                Console.WriteLine("Product Not Found");
                return;
            }
            Console.WriteLine($"Editing {product.Get_Name()} product");
            Console.Write("Enter new name (leave empty to keep current): ");

            string new_name = Console.ReadLine();
            if(!string.IsNullOrEmpty(new_name))
            product.Set_Name(new_name);
            while (true)
            {
                Console.Write("Enter new price (leave empty to keep current): ");

                string new_price = Console.ReadLine();
                if (string.IsNullOrEmpty(new_price)) break;

                if (decimal.TryParse(new_price, out decimal price) && price >= 0)
                {
                    product.Set_Price(price);
                    break;
                }
                Console.Write("Invalid price. ");
            }
            while (true)
            {
                Console.Write("Enter new Quantity (leave empty to keep current): ");
                string new_quantity = Console.ReadLine();
                if (string.IsNullOrEmpty(new_quantity)) break;
                if (int.TryParse(new_quantity, out int quantity) && quantity >= 0)
                {
                    product.Set_Quantity(quantity);
                    break;
                }
                Console.Write("Invalid Quantity.");
            }
            }

        public void Delete_product(string product_name)
        {
            Product product = products.Find((p => p.Get_Name().Equals(product_name, StringComparison.OrdinalIgnoreCase)));
            if (product == null)
            {
                Console.WriteLine("Product Not Found");
                return;
            }
            products.Remove(product);
            Console.WriteLine($"Product {product.Get_Name()} deleted successfully");
            
            
            }

    }
}
