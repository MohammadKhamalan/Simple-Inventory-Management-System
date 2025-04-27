using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Inventory_Management_System.Models;

namespace Inventory_Management_System.DataBaseConnection
{
    public class SQLMSConnections
    {
        private readonly string connectionString;

        public SQLMSConnections()
        {
            connectionString = "Server=localhost;Database=InventoryDB;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public void AddProduct(Product product)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"INSERT INTO Products (ProductName, Price, Quantity) 
                                    VALUES (@ProductName, @Price, @Quantity)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();

            using (var connection = new SqlConnection(connectionString))
            {
                const string query = "SELECT ProductID, ProductName, Price, Quantity FROM Products";

                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product(
                                reader["ProductName"].ToString(),
                                Convert.ToDecimal(reader["Price"]),
                                Convert.ToDecimal(reader["Quantity"])
                            ));
                        }
                    }
                }
            }

            return products;
        }

        public Product SearchProduct(string productName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = "SELECT ProductName, Price, Quantity FROM Products WHERE ProductName = @ProductName";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", productName);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Product(
                                reader["ProductName"].ToString(),
                                Convert.ToDecimal(reader["Price"]),
                                Convert.ToDecimal(reader["Quantity"])
                            );
                        }
                    }
                }
            }

            return null;
        }

        public void UpdateProduct(string oldName, Product updatedProduct)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"UPDATE Products 
                                    SET ProductName = @NewName, Price = @Price, Quantity = @Quantity 
                                    WHERE ProductName = @OldName";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewName", updatedProduct.Name);
                    command.Parameters.AddWithValue("@Price", updatedProduct.Price);
                    command.Parameters.AddWithValue("@Quantity", updatedProduct.Quantity);
                    command.Parameters.AddWithValue("@OldName", oldName);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProduct(string productName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = "DELETE FROM Products WHERE ProductName = @ProductName";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", productName);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}