/*
 * Author: Sakthi Santhosh
 * Created on: 09/05/2024
 */
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeLibrary.Models;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Employee name cannot be null or whitespace.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Department cannot be null or whitespace.")]
    public string Department { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Salary must be a non-negative value.")]
    public decimal Salary { get; set; }

    public override string ToString()
    {
        string data = "";

        data += "+----------------------------------------+";
        data += "| Employee                               |";
        data += "+----------------------------------------+";
        data += $"  ID:         ${Id}                     ";
        data += $"  Name:       ${Name}                   ";
        data += $"  Department: ${Department}             ";
        data += $"  Salary:     ${Salary}                 ";
        data += "+----------------------------------------+";

        return data;
    }
}
