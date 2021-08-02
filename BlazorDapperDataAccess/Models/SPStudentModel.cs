using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorDapperDataAccess.Models
{
    public class SPStudentModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string MiddleName { get; set; }
        public int DeptId { get; set; }
        public string Department { get; set; }
    }
}
