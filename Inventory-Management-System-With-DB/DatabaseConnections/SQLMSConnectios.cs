using Microsoft.Data.SqlClient;

namespace Inventory_Management_System.DataBaseConnection
{
    public class SQLMSConnections
    {
        private readonly string connectionString;

        public SQLMSConnections()
        {
            connectionString = "Server=localhost;Database=InventoryDB;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}

