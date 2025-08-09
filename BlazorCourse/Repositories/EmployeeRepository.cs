using BethanysPieShopHRM.Shared.Domain;
using BlazorCourse.Contracts.Repositories;
using BlazorCourse.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorCourse.Repositories;

public class EmployeeRepository : IEmployeeRepository, IDisposable
{
    private readonly AppDbContext _context;

    public EmployeeRepository(IDbContextFactory<AppDbContext> context)
    {
        _context = context.CreateDbContext();
    }

    public async Task<Employee> AddEmployee(Employee employee)
    {
        var addedEmployee = await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return addedEmployee.Entity;
    }

    public async Task DeleteEmployee(int employeeId)
    {
        var foundEmployee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        if (foundEmployee == null) return;

        _context.Employees.Remove(foundEmployee);
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
    
    public async Task<IEnumerable<Employee>> GetAllEmployees()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee> GetEmployeeById(int employeeId)
    {
        return await _context?.Employees?.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
    }

    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        var foundEmployee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

        if (foundEmployee != null)
        {
            foundEmployee.CountryId = employee.CountryId;
            foundEmployee.MaritalStatus = employee.MaritalStatus;
            foundEmployee.BirthDate = employee.BirthDate;
            foundEmployee.City = employee.City;
            foundEmployee.Email = employee.Email;
            foundEmployee.FirstName = employee.FirstName;
            foundEmployee.LastName = employee.LastName;
            foundEmployee.Gender = employee.Gender;
            foundEmployee.PhoneNumber = employee.PhoneNumber;
            foundEmployee.Smoker = employee.Smoker;
            foundEmployee.Street = employee.Street;
            foundEmployee.Zip = employee.Zip;
            foundEmployee.JobCategoryId = employee.JobCategoryId;
            foundEmployee.Comment = employee.Comment;
            foundEmployee.ExitDate = employee.ExitDate;
            foundEmployee.JoinedDate = employee.JoinedDate;
            foundEmployee.ImageContent = employee.ImageContent;
            foundEmployee.ImageName = employee.ImageName;

            await _context.SaveChangesAsync();

            return foundEmployee;
        }

        return null;
    }
}
