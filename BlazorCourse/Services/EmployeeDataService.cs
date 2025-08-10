using BethanysPieShopHRM.Shared.Domain;
using BlazorCourse.Client;
using BlazorCourse.Contracts.Repositories;
using Microsoft.AspNetCore.Hosting;

namespace BlazorCourse.Services;

public class EmployeeDataService : IEmployeeDataService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EmployeeDataService(IEmployeeRepository employeeRepository, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
    {
        _employeeRepository = employeeRepository;
        _httpContextAccessor = httpContextAccessor;
        _webHostEnvironment = webHostEnvironment;
    }

    public Task<Employee> AddEmployee(Employee employee)
    {
        return _employeeRepository.AddEmployee(employee);
    }

    public Task DeleteEmployee(int employeeId)
    {
        return _employeeRepository.DeleteEmployee(employeeId);
    }

    public Task<IEnumerable<Employee>> GetAllEmployees()
    {
        return _employeeRepository.GetAllEmployees();
    }

    public Task<Employee> GetEmployeeDetails(int employeeId)
    {
        return _employeeRepository.GetEmployeeById(employeeId);
    }

    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        if (employee.ImageContent != null)
        {
            string currentUrl = _httpContextAccessor.HttpContext.Request.Host.Value;
            var path = $"{_webHostEnvironment.WebRootPath}\\uploads\\{employee.ImageName}";
            var fileStream = System.IO.File.Create(path);
            fileStream.Write(employee.ImageContent, 0, employee.ImageContent.Length);
            fileStream.Close();

            employee.ImageName = $"https://{currentUrl}/uploads/{employee.ImageName}";
        }
        return await _employeeRepository.UpdateEmployee(employee);
    }
}
