using Inventory_Management_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Interfaces
{
    public interface IInventoryFactory
    {
        IInventory Create(string dbChoice);
    }

}
