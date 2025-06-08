using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Employeemanage.Models
{
    public class Admin 
    {
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; }        

        public int Salary {  get; set; }
        public string Department {  get; set; }

        public Login Login { get; set; }

    }
}
