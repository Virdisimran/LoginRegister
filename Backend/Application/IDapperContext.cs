using Dapper;
using Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IDapperContext
    {
        Task<List<Product>> GetAll(string command,object parms);    
        Task<string> AddProduct(string command,object parms);
        Task<string> DeleteProduct(string command, object parms);
        Task<string> UpdateProduct(string command,object parms);
    }

    public class DapperContext:IDapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("connection");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);

        public async Task<List<Product>> GetAll(string command,object parms=null)
        {
           using IDbConnection dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();
            var result = (await dbConnection.QueryAsync<Product>(command,parms)).ToList();
            return result;
        }

        public async Task<string> AddProduct(string command, object parms)
        {
            try
            {
                using IDbConnection dbConnection = new SqlConnection(_connectionString);
                dbConnection.Open();
                var result = await dbConnection.ExecuteScalarAsync(command, parms);
                return "Added Successfully";
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }

        public async Task<string> DeleteProduct(string command, object parms)
        {
            try
            {
                using IDbConnection dbConnection = new SqlConnection(_connectionString);
                dbConnection.Open();
                var result = await dbConnection.ExecuteAsync(command, parms);
                return "deleted Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<string> UpdateProduct(string command, object parms)
        {
            try
            {
                using IDbConnection dbConnection = new SqlConnection(_connectionString);
                dbConnection.Open();
                var result = await dbConnection.ExecuteAsync(command, parms);
                return "Updated Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
