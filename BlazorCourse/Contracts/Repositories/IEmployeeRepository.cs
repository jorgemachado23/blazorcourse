using BethanysPieShopHRM.Shared.Domain;

namespace BlazorCourse.Contracts.Repositories;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllEmployees();
    Task<Employee> GetEmployeeById(int employeeId);
}
