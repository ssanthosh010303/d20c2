/*
 * Author: Sakthi Santhosh
 * Created on: 19/04/2024
 */
using EmployeeLibrary.Models;
using EmployeeLibrary.Repository;

namespace EmployeeLibrary.BusinessLogic;

public class EmployeeService(IEmployeeRepository employeeRepository)
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;

    public Employee GetEmployeeById(int id)
    {
        return _employeeRepository.GetById(id);
    }

    public IEnumerable<Employee> GetAllEmployees()
    {
        return _employeeRepository.GetAll();
    }

    public void AddEmployee(string name, string department, decimal salary)
    {
        _employeeRepository.Add(name, department, salary);
    }

    public void UpdateEmployee(int id, string name, string department, decimal salary)
    {
        _employeeRepository.Update(id, name, department, salary);
    }

    public void DeleteEmployee(int id)
    {
        _employeeRepository.Delete(id);
    }

    public void ApplyYearlySalaryIncrease(string performanceRating)
    {
        var employees = _employeeRepository.GetAll();

        foreach (var employee in employees)
        {
            decimal salaryIncreasePercentage = GetSalaryIncreasePercentage(performanceRating);

            if (salaryIncreasePercentage > 0)
            {
                decimal increaseAmount = employee.Salary * salaryIncreasePercentage;

                employee.Salary += increaseAmount;
                _employeeRepository.Update(employee.Id, employee.Name, employee.Department, employee.Salary);
            }
        }
    }

    private static decimal GetSalaryIncreasePercentage(string performanceRating)
    {
        return performanceRating.ToLower() switch
        {
            "excellent" => 0.10m,
            "good" => 0.05m,
            "average" => 0.03m,
            "poor" => 0,
            _ => 0,
        };
    }
}
