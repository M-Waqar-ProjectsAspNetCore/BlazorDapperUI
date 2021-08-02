using BlazorDapperDataAccess.Models;
using BlazorDapperDataAccess.Repositories;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDapperUI.Pages.StdSp
{
    public class ListStudentBase : ComponentBase
    {
        [Inject]
        public ISPStudentService SPStudentService { get; set; }

        protected List<SPStudentModel> Studentlist;

        protected override async Task OnInitializedAsync()
        {
            Studentlist = await SPStudentService.GetStudentList();
        }

        protected async Task DeleteEmployee(int id)
        {
            await SPStudentService.DeleteStudent(id);
            Studentlist = await SPStudentService.GetStudentList();
        }
    }
}
