using BlazorDapperDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDapperDataAccess.Repositories
{
    public class StudentService : IStudentService
    {
        private readonly ISqlDapperHelper db;

        public StudentService(ISqlDapperHelper db)
        {
            this.db = db;
        }

        public Task<List<StudentModel>> GetStudents()
        {
            string query = "select * from Students";
            return db.ExecuteQuery<StudentModel, dynamic>(query, new { });
        }

        public Task<StudentModel> GetStudentById(int id)
        {
            string query = @"select * from Students where id = @id";
            return db.ExecuteSingle<StudentModel, dynamic>(query, new { id });
        }

        public Task AddStudent(NewStudentModel newStudent)
        {
            string query = @"insert into students (FirstName,LastName, EmailAddress, MiddleName)
                            Values (@FirstName,@LastName, @EmailAddress, @MiddleName)";
            return db.ExecuteNonQuery<NewStudentModel>(query, newStudent);
        }

        public Task EditStudent(StudentModel student)
        {
            string query = @"UPDATE Students SET FirstName = @FirstName, LastName = @LastName, 
                            EmailAddress = @EmailAddress, MiddleName = @MiddleName WHERE Id = @Id";
            return db.ExecuteNonQuery<StudentModel>(query, student);
        }

        public Task DeleteStudent(int id)
        {
            string query = @"DELETE FROM Students WHERE Id = @id";
            return db.ExecuteNonQuery<dynamic>(query, new { id });
        }
    }
}
