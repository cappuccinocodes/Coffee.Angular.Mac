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
        CoffeeRecord GetById(int id);
        void Add(CoffeeRecord record);
        void Delete(int id);
        void Update(CoffeeRecord record);
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

        public CoffeeRecord GetById(int id)
        {
            using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                var query =
                    @"SELECT * FROM Records Where Id = @Id";

                var record = connection.QuerySingle<CoffeeRecord>(query, new { Id = id });

                return record;
            }
        }

        public void Add(CoffeeRecord record)
        {
            using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                var sql = "INSERT INTO Records (Type, Bean, Location, DateCreated, Score, NoOfShots, Price ) Values(@Type, @Bean, @Location, @DateCreated, @Score, @NoOfShots, @Price)";
                connection.Execute(sql, record);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                var sql = "DELETE FROM Recordss WHERE Id = @id";
                connection.Execute(sql, new { id });
            }
        }

        public void Update(CoffeeRecord record)
        {
            using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                var sql = "UPDATE Records SET Type = @Type, Bean = @Bean, Location = @Location, DateCreated = @DateCreated, Score = @Score, NoOfShots = @NoOfShots, Price = @Price WHERE Id = @Id";
                connection.Execute(sql, record);
            }
        }
    }
}

