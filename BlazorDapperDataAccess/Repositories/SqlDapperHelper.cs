using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDapperDataAccess.Repositories
{
    public class SqlDapperHelper : ISqlDapperHelper
    {
        private readonly string ConnectionStringName = "Default";

        private readonly IConfiguration config;

        public SqlDapperHelper(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<List<T>> ExecuteQuery<T, U>(string sql, U parameter)
        {
            try
            {
                string conString = config.GetConnectionString(ConnectionStringName);
                using (IDbConnection connection = new SqlConnection(conString))
                {
                    var data = await connection.QueryAsync<T>(sql, parameter);
                    return data.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task ExecuteNonQuery<U>(string sql, U parameter)
        {
            try
            {
                string conString = config.GetConnectionString(ConnectionStringName);
                using (IDbConnection connection = new SqlConnection(conString))
                {
                    await connection.ExecuteAsync(sql, parameter);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> ExecuteSingle<T,U>(string sql, U parameter)
        {
            try
            {
                string conString = config.GetConnectionString(ConnectionStringName);
                using (IDbConnection connection = new SqlConnection(conString))
                {
                    return await connection.QuerySingleOrDefaultAsync<T>(sql, parameter);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
