using BlazorDapperDataAccess.Models;
using BlazorDapperDataAccess.Repositories;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDapperUI.Pages.StdSp
{
    public class CreateStudentBase : ComponentBase
    {
        [Inject]
        public ISPStudentService SPStudentService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected SPStudentModel spStudentModel = new SPStudentModel();

        protected async Task StudentCreate()
        {
            await SPStudentService.CreateStudent(spStudentModel);
            NavigationManager.NavigateTo("/sp-students");
        }
    }
}
