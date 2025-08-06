using BethanysPieShopHRM.Shared.Domain;

namespace BlazorCourse.Contracts.Services;

public interface ITimeRegistrationDataService
{
    Task<List<TimeRegistration>> GetTimeRegistrationsForEmployee(int employeeId);
    Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployee(int employeeId, int pageSize, int start);
    Task<int> GetTimeRegistrationCountForEmployeeId(int employeeId);
}
