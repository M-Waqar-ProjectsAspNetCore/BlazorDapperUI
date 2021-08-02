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
    public class SPSqlDapperHelper : ISPSqlDapperHelper
    {
        private readonly string ConnectionStringName = "Default";
        private readonly IConfiguration config;
        public SPSqlDapperHelper(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<List<T>> ExecuteQuery<T, U>(string sp, U parameter)
        {
            try
            {
                string conString = config.GetConnectionString(ConnectionStringName);
                using (IDbConnection connection = new SqlConnection(conString))
                {
                    var data = await connection.QueryAsync<T>(sp, parameter, commandType: CommandType.StoredProcedure);
                    return data.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task ExecuteNonQuery<U>(string sp, U parameter)
        {
            try
            {
                string conString = config.GetConnectionString(ConnectionStringName);
                using (IDbConnection connection = new SqlConnection(conString))
                {
                    await connection.ExecuteAsync(sp, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> ExecuteSingleQuery<T, U>(string sp, U parameter)
        {
            try
            {
                string conString = config.GetConnectionString(ConnectionStringName);
                using (IDbConnection connection = new SqlConnection(conString))
                {
                    return await connection.QuerySingleOrDefaultAsync<T>(sp, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
