using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Inventory_Management_System
{
    class Product
    {
        private String Name { get; set; }
        private decimal Price { get; set; }
        private int Quantity { get; set; }

        public Product(String name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public string Get_Name()
        {
            return Name; 
        }
       
        public override string ToString()
        {
            return $"Product: {Name}, Price:{Price}, Quantuty:{Quantity}";
        }
    }
}
