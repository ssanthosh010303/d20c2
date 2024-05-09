/*
 * Author: Sakthi Santhosh
 * Created on: 09/05/2024
 */
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeLibrary.Models;

public class Department
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Department name cannot be null or whitespace.")]
    public string Name { get; set; }

    public int DepartmentHeadId { get; set; }

    [ForeignKey("DepartmentHeadId")]
    public Employee DepartmentHead { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Department other = (Department)obj;
        return this.Name.Equals(other.Name);
    }

    public override string ToString()
    {
        string data = "";

        data += "+----------------------------------------+";
        data += "| Department                             |";
        data += "+----------------------------------------+";
        data += $"  ID:   ${Id}                           ";
        data += $"  Name: ${Name}                         ";
        data += $"  Head: ${DepartmentHeadId}             ";
        data += "+----------------------------------------+";

        return data;
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
