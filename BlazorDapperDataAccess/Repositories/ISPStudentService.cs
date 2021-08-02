using BlazorDapperDataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDapperDataAccess.Repositories
{
    public interface ISPStudentService
    {
        Task CreateStudent(SPStudentModel model);
        Task DeleteStudent(int id);
        Task EditStudent(SPStudentModel model);
        Task<SPStudentModel> GetStudentById(int id);
        Task<List<SPStudentModel>> GetStudentList();
    }
}