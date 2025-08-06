using BethanysPieShopHRM.Shared.Domain;
using BlazorCourse.Contracts.Repositories;
using BlazorCourse.Contracts.Services;

namespace BlazorCourse.Services;

public class EmployeeDataService : IEmployeeDataService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeDataService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public Task<IEnumerable<Employee>> GetAllEmployees()
    {
        return _employeeRepository.GetAllEmployees();
    }

    public Task<Employee> GetEmployeeById(int employeeId)
    {
        return _employeeRepository.GetEmployeeById(employeeId);
    }
}
