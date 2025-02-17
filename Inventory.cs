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

    }
}
