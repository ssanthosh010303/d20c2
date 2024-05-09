/*
 * Author: Sakthi Santhosh
 * Created on: 19/04/2024
 */
using EmployeeLibrary.Models;

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
    private readonly List<Employee> _employees;

    public EmployeeRepository()
    {
        _employees = [];
    }

    public Employee GetById(int id)
    {
        var employee = _employees.FirstOrDefault(e => e.Id == id) ?? throw new NullReferenceException("No employee with that ID found.");

        return employee;
    }

    public IEnumerable<Employee> GetAll()
    {
        return _employees;
    }

    public void Add(string name, string department, decimal salary)
    {
        _employees.Add(new Employee
        {
            Id = _employees.Count != 0 ? _employees.Max(e => e.Id) + 1 : 1,
            Name = name,
            Department = department,
            Salary = salary
        });
    }

    public void Update(int id, string name, string department, decimal salary)
    {
        var existingEmployee = GetById(id);

        if (existingEmployee != null)
        {
            existingEmployee.Name = name;
            existingEmployee.Department = department;
            existingEmployee.Salary = salary;
        }
    }

    public void Delete(int id)
    {
        var employeeToDelete = GetById(id);

        if (employeeToDelete != null)
            _employees.Remove(employeeToDelete);
    }
}
