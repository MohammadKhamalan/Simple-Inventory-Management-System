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

    }
}
