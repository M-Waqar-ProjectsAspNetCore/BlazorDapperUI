using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDapperDataAccess.Repositories
{
    public interface ISPSqlDapperHelper
    {
        Task ExecuteNonQuery<U>(string sp, U parameter);
        Task<List<T>> ExecuteQuery<T, U>(string sp, U parameter);
        Task<T> ExecuteSingleQuery<T, U>(string sp, U parameter);
    }
}