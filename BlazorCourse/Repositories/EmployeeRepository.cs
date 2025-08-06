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
}
