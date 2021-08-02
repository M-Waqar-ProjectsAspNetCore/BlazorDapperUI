using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorDapperDataAccess.Models
{
    public class NewStudentModel
    {
        [Required]
        [MinLength(3,ErrorMessage = "First Name is too Short")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Last Name is too Short")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string MiddleName { get; set; }
    }
}
