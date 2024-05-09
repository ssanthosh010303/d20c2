/*
 * Author: Sakthi Santhosh
 * Created on: 19/04/2024
 */
using EmployeeLibrary.Models;

using Microsoft.EntityFrameworkCore;

namespace EmployeeLibrary.Repository;

public interface IEmployeeRepository
{
    Employee GetById(int id);
    IEnumerable<Employee> GetAll();
    void Add(string name, string department, decimal salary);
    void Update(int id, string name, string department, decimal salary);
    void Delete(int id);
}

public class EmployeeRepository : IEmployeeRepository
{
    private readonly DbContext _context;

    public EmployeeRepository(DbContext context)
    {
        _context = context;
    }

    public Employee GetById(int id)
    {
        return _context.Employees.FirstOrDefault(e => e.Id == id) ?? throw new NullReferenceException("No employee with that ID found.");
    }

    public IEnumerable<Employee> GetAll()
    {
        return _context.Employees.ToList();
    }

    public void Add(string name, string department, decimal salary)
    {
        var newEmployee = new Employee
        {
            Name = name,
            Department = department,
            Salary = salary
        };

        _context.Employees.Add(newEmployee);
        _context.SaveChanges();
    }

    public void Update(int id, string name, string department, decimal salary)
    {
        var existingEmployee = GetById(id);

        if (existingEmployee != null)
        {
            existingEmployee.Name = name;
            existingEmployee.Department = department;
            existingEmployee.Salary = salary;

            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var employeeToDelete = GetById(id);

        if (employeeToDelete != null)
        {
            _context.Employees.Remove(employeeToDelete);
            _context.SaveChanges();
        }
    }
}
