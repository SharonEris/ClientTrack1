using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using ClientTrack.DBL.Models;
using Microsoft.Extensions.Configuration;

namespace ClientTrack.DBL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly string _connectionString;

        public ClientRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<CountryModel> GetCountries()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<CountryModel>("SELECT CountryId, CountryName FROM Countries");
            }
        }

        //public IEnumerable<StatusModel> GetStatuses()
        //{
        //    using (IDbConnection db = new SqlConnection(_connectionString))
        //    {
        //        return db.Query<StatusModel>("SELECT StatusId, StatusName FROM Statuses");
        //    }
        //}

        public IEnumerable<ProductModel> GetProducts()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<ProductModel>("SELECT ProductId, ProductName FROM Products");
            }
        }

        public async Task<int> CreateClientAsync(ClientModel client)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                // Insert client into Clients table
                var query = @"
                    INSERT INTO Clients (ClientName, Email, Phone,CountryId,Address)
                    OUTPUT INSERTED.ClientId
                    VALUES (@ClientName, @Email, @Phone, @CountryId, @Address)";

                var clientId = await db.ExecuteScalarAsync<int>(query, client);

                //Stored procedure
                //Have a screen for manage clients with two screens one for the clients and the other for products and a button to add products. 

                // Insert selected products into ClientProducts table
                //if (client.ProductIds != null && client.ProductIds.Count > 0)
                //{
                //    foreach (var productId in client.ProductIds)
                //    {
                //        // Insert each product selection into ClientProducts
                //        var productQuery = @"
                //    INSERT INTO ClientProducts (ClientId, ProductId)
                //    VALUES (@ClientId, @ProductId)";


                //        await db.ExecuteAsync(productQuery, new { ClientId = clientId, ProductId = productId });

                      
                //    }
                //}

                return clientId;
            }
        }

        public async Task<IEnumerable<ClientModel>> GetAllClientsAsync()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM vw_ClientDetails";
                return await db.QueryAsync<ClientModel>(query);


            }
        }

        //public async Task<ClientModel> GetClientAsync(int clientId)
        //{
        //    using (IDbConnection db = new SqlConnection(_connectionString))
        //    {
        //        var query = "SELECT * FROM Clients WHERE ClientId = @ClientId";

        //        return await db.QuerySingleOrDefaultAsync<ClientModel>(query, new { ClientId = clientId });
        //    }
        //}

        public async Task<ClientModel> GetClientAsync(int clientId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM vw_ClientDetails WHERE ClientId = @ClientId";

                var client = await db.QuerySingleOrDefaultAsync<ClientModel>(query, new { ClientId = clientId });

                if (client == null)
                {
                    Console.WriteLine($"ClientRepository: No client found for ID {clientId}");
                }
                else
                {
                    Console.WriteLine($"ClientRepository: Found client {client.ClientName}");
                }

                return client;
            }
        }


    }
}
    