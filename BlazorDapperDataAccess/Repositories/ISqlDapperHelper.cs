using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDapperDataAccess.Repositories
{
    public interface ISqlDapperHelper
    {
        Task ExecuteNonQuery<U>(string sql, U parameter);
        Task<List<T>> ExecuteQuery<T, U>(string sql, U parameter);
        Task<T> ExecuteSingle<T, U>(string sql, U parameter);
    }
}