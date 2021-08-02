using BlazorDapperDataAccess.Models;
using BlazorDapperDataAccess.Repositories;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDapperUI.Pages.StdQuery
{
    public class EditStudentBase : ComponentBase
    {
        [Inject]
        public IStudentService StudentService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public int Id { get; set; }

        protected StudentModel Student = new StudentModel();

        protected override async Task OnInitializedAsync()
        {
            Student = await StudentService.GetStudentById(Id);
        }

        protected void EditStudent()
        {
            StudentService.EditStudent(Student);
            NavigationManager.NavigateTo("/students");
        }
    }
}
