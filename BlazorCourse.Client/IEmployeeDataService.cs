using BethanysPieShopHRM.Shared.Domain;

namespace BlazorCourse.Client;

public interface IEmployeeDataService
{
    Task<IEnumerable<Employee>> GetAllEmployees();
    Task<Employee> GetEmployeeDetails(int employeeId);
    Task<Employee> AddEmployee(Employee employee);
    Task<Employee> UpdateEmployee(Employee employee);
    Task DeleteEmployee(int employeeId);
}
