using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Inventory_Management_System
{
    class Product
    {
        private string Name;
        private decimal Price;
        private int Quantity;

        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string Get_Name()
        {
            return Name;
        }

        public decimal Get_Price()
        {
            return Price;
        }

        public int Get_Quantity()
        {
            return Quantity;
        }

        public void Set_Name(string name)
        {
            Name = name;
        }

        public void Set_Price(decimal price)
        {
            Price = price;
        }

        public void Set_Quantity(int quantity)
        {
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Product: {Name}, Price: {Price}, Quantity: {Quantity}";
        }
    }
}
