using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace migrationDemo.Models
{
    public class Departments
    {
        [Key]
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}