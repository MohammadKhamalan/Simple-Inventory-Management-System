using MongoDB.Driver;
using Inventory_Management_System.Models;
using Inventory_Management_System.DataBaseConnection; 
using System.Collections.Generic;

namespace Inventory_Management_System.Services
{
    public class InventoryMongo
    {
        private readonly IMongoCollection<Product> _productsCollection;

        public InventoryMongo()
        {
            var mongoConnection = new MongoDbConnection(); 
            _productsCollection = mongoConnection.GetProductsCollection();
        }

        public void AddProduct(Product product)
        {
            _productsCollection.InsertOne(product);
        }

        public List<Product> GetAllProducts()
        {
            var projection = Builders<Product>.Projection.Exclude("_id");
            return _productsCollection.Find(product => true)
                                     .Project<Product>(projection)
                                     .ToList();
        }
        public Product SearchProduct(string productName)
        {
            var projection = Builders<Product>.Projection.Exclude("_id");
            return _productsCollection.Find(p => p.Name == productName)
                                     .Project<Product>(projection)
                                     .FirstOrDefault();
        }
        public void UpdateProduct(string oldName, Product updatedProduct)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Name, oldName);
            _productsCollection.ReplaceOne(filter, updatedProduct);
        }

        public void DeleteProduct(string productName)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Name, productName);
            _productsCollection.DeleteOne(filter);
        }
    }
}
