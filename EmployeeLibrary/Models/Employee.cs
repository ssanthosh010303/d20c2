/*
 * Author: Sakthi Santhosh
 * Created on: 19/04/2024
 */
namespace EmployeeLibrary.Models;

public class Employee
{
    private int _id;
    private string _name;
    private string _department;
    private decimal _salary;

    public int Id
    {
        get { return _id; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Employee ID must be greater than zero.");
            _id = value;
        }
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Employee name cannot be null or whitespace.");
            _name = value.Trim();
        }
    }

    public string Department
    {
        get { return _department; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Department cannot be null or whitespace.");
            _department = value.Trim();
        }
    }

    public decimal Salary
    {
        get { return _salary; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Salary must be a non-negative value.");
            _salary = value;
        }
    }
}
