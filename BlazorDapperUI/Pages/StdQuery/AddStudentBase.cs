using BlazorDapperDataAccess.Models;
using BlazorDapperDataAccess.Repositories;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDapperUI.Pages.StdQuery
{
    public class AddStudentBase : ComponentBase
    {
        [Inject]
        public IStudentService StudentService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected NewStudentModel NewStudent = new NewStudentModel();

        protected void AddStudent()
        {
            StudentService.AddStudent(NewStudent);
            NewStudent = new NewStudentModel();
            NavigationManager.NavigateTo("/students");
        }
    }
}
