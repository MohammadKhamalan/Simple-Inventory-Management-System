using System;
using Inventory_Management_System.Interfaces;
using Inventory_Management_System.Services;

public class InventoryFactory : IInventoryFactory
{
    public IInventory Create(string dbChoice)
    {
        if (string.IsNullOrWhiteSpace(dbChoice))
        {
            Console.WriteLine("Please enter a valid database choice.");
            return null;
        }

        dbChoice = dbChoice.ToLower();

        return dbChoice switch
        {
            "sql" => new InventorySql(),
            "mongo" => new InventoryMongo(),
            _ => InvalidChoice()
        };
    }

    private IInventory InvalidChoice()
    {
        Console.WriteLine("Unsupported database type. Please enter 'sql' or 'mongo'.");
        return null;
    }
}
