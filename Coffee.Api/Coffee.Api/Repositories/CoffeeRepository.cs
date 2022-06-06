using System;
using System.Data;
using Coffee.Api.Models;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Coffee.Api.Repositories
{
    public interface ICoffeeRepository
    {
        List<CoffeeRecord> Get();
    }

    public class CoffeeRepository: ICoffeeRepository
    {
        private readonly IConfiguration _configuration;

        public CoffeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<CoffeeRecord> Get()
        {
            using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                var query =
                    @"SELECT * FROM Records";

                var allTransactions = connection.Query<CoffeeRecord>(query);

                return allTransactions.ToList();
            }
        }
    }
}

