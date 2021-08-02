using BlazorDapperDataAccess.Models;
using BlazorDapperDataAccess.Repositories;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDapperUI.Pages.StdSp
{
    public class UpdateStudentBase : ComponentBase
    {
        [Inject]
        public ISPStudentService SPStudentService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int Id { get; set; }

        protected SPStudentModel StdModel = new SPStudentModel();

        protected override async Task OnInitializedAsync()
        {
            StdModel = await SPStudentService.GetStudentById(Id);
        }

        protected async Task StudentUpdate()
        {
            await SPStudentService.EditStudent(StdModel);
            NavigationManager.NavigateTo("/sp-students");
        }
    }
}
