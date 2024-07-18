using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace migrationDemo.Models;

public class Employees
{
    [Key] // Indicates that this field will be the Primary Key
    public int EmployeeID { get; set; }
    [Required (ErrorMessage = "First name is required")]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}