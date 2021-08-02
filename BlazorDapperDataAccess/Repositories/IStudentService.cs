using BlazorDapperDataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDapperDataAccess.Repositories
{
    public interface IStudentService
    {
        Task<List<StudentModel>> GetStudents();
        Task<StudentModel> GetStudentById(int id);
        Task AddStudent(NewStudentModel newStudent);
        Task EditStudent(StudentModel student);
        Task DeleteStudent(int id);
    }
}