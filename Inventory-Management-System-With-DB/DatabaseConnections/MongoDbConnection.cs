using MongoDB.Driver;

namespace Inventory_Management_System.DataBaseConnection
{
    public class MongoDbConnection
    {
        private readonly IMongoDatabase _database;

        public MongoDbConnection()
        {
           
            var connectionString = "mongodb://localhost:27017/";
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("InventoryDB");
        }

        public IMongoCollection<Models.Product> GetProductsCollection()
        {
            return _database.GetCollection<Models.Product>("Products");
        }
    }
}