using Inventory_Management_System.Models;

namespace Inventory_Management_System.Interfaces
{
    public interface IInventory
    {
        void Add_product(Product product);
        void View_products();
        void Edit_product(string product_name);
        void Delete_product(string product_name);
        void search_for_product(string product_name);
    }
}
