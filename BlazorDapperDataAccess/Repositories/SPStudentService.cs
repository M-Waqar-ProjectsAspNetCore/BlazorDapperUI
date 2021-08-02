using BlazorDapperDataAccess.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDapperDataAccess.Repositories
{
    public class SPStudentService : ISPStudentService
    {
        private readonly ISPSqlDapperHelper db;
        public SPStudentService(ISPSqlDapperHelper db)
        {
            this.db = db;
        }

        public async Task<List<SPStudentModel>> GetStudentList()
        {
            return await db.ExecuteQuery<SPStudentModel, dynamic>("GETALLSTUDENTS", new { });
        }

        public async Task<SPStudentModel> GetStudentById(int id)
        {
            var spParameter = new DynamicParameters();
            spParameter.Add("Id", id, DbType.Int32);
            return await db.ExecuteSingleQuery<SPStudentModel, DynamicParameters>("GETSTUDENTBYID", spParameter);
        }

        public async Task CreateStudent(SPStudentModel model)
        {
            var spParam = new DynamicParameters();
            spParam.Add("FirstName", model.FirstName, DbType.String);
            spParam.Add("LastName", model.LastName, DbType.String);
            spParam.Add("EmailAddress", model.EmailAddress, DbType.String);
            spParam.Add("MiddleName", model.MiddleName, DbType.String);
            spParam.Add("DeptId", model.DeptId, DbType.Int32);
            await db.ExecuteNonQuery<dynamic>("CREATESTUDENT", spParam);
        }

        public async Task EditStudent(SPStudentModel model)
        {
            var spParam = new DynamicParameters();
            spParam.Add("Id", model.Id, DbType.Int32);
            spParam.Add("FirstName", model.FirstName, DbType.String);
            spParam.Add("LastName", model.LastName, DbType.String);
            spParam.Add("EmailAddress", model.EmailAddress, DbType.String);
            spParam.Add("MiddleName", model.MiddleName, DbType.String);
            spParam.Add("DeptId", model.DeptId, DbType.Int32);
            await db.ExecuteNonQuery<dynamic>("UPDATESTUDENT", spParam);
        }

        public async Task DeleteStudent(int id)
        {
            var spParam = new DynamicParameters();
            spParam.Add("Id", id, DbType.Int32);
            await db.ExecuteNonQuery<dynamic>("DELETESTUDENT", spParam);
        }
    }
}
