using BlazorDapperDataAccess.Models;
using BlazorDapperDataAccess.Repositories;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDapperUI.Pages.StdQuery
{
    public class StudentListBase : ComponentBase
    {
        [Inject]
        public IStudentService StudentService { get; set; }

        protected List<StudentModel> list;

        protected override async Task OnInitializedAsync()
        {
            list = await StudentService.GetStudents();
        }

        protected async Task DeleteEmployee(int id)
        {
            await StudentService.DeleteStudent(id);
            list = await StudentService.GetStudents();
        }
    }
}
