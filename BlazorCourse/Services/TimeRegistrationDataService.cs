using BethanysPieShopHRM.Shared.Domain;
using BlazorCourse.Contracts.Repositories;
using BlazorCourse.Contracts.Services;

namespace BlazorCourse.Services;

public class TimeRegistrationDataService : ITimeRegistrationDataService
{
    private readonly ITimeRegistrationRepository _timeRegistrationRepository;

    public TimeRegistrationDataService(ITimeRegistrationRepository timeRegistrationRepository)
    {
        _timeRegistrationRepository = timeRegistrationRepository;
    }

    public Task<List<TimeRegistration>> GetTimeRegistrationsForEmployee(int employeeId)
    {
        return _timeRegistrationRepository.GetTimeRegistrationsForEmployee(employeeId);
    }

    public Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployee(int employeeId, int pageSize, int start)
    {
        return _timeRegistrationRepository.GetPagedTimeRegistrationsForEmployee(employeeId, pageSize, start);
    }

    public Task<int> GetTimeRegistrationCountForEmployeeId(int employeeId)
    {
        return _timeRegistrationRepository.GetTimeRegistrationCountForEmployeeId(employeeId);
    }
}