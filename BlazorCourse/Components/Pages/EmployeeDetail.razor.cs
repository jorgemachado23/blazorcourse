using BethanysPieShopHRM.Shared.Domain;
using BethanysPieShopHRM.Shared.Models;
using BlazorCourse.Client;
using BlazorCourse.Contracts.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace BlazorCourse.Components.Pages;

public partial class EmployeeDetail
{
    [Parameter]
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = new Employee();
    public List<TimeRegistration> TimeRegistrations { get; set; } = [];

    [Inject]
    private IEmployeeDataService? EmployeeDataService { get; set; }

    [Inject]
    private ITimeRegistrationDataService? TimeRegistrationDataService { get; set; }

    protected IQueryable<TimeRegistration>? itemsQueryable;
    protected int queryableCount = 0;
    public PaginationState pagination = new() { ItemsPerPage = 10 };

    public List<Marker> MapMarkers { get; set; } = new List<Marker>();

    protected async override Task OnInitializedAsync()
    {
        Employee = await EmployeeDataService?.GetEmployeeDetails(EmployeeId);
        // TimeRegistrations = await TimeRegistrationDataService?.GetTimeRegistrationsForEmployee(EmployeeId);
        itemsQueryable = (await TimeRegistrationDataService?.GetTimeRegistrationsForEmployee(EmployeeId)
        ).AsQueryable();
        queryableCount = itemsQueryable?.Count() ?? 0;

        if (Employee.Longitude.HasValue && Employee.Latitude.HasValue)
        {
            MapMarkers = new List<Marker>
            {
                new Marker{Description = $"{Employee.FirstName} {Employee.LastName}",  ShowPopup = false, X = Employee.Longitude.Value, Y = Employee.Latitude.Value}
            };
        }
    }

    public async ValueTask<ItemsProviderResult<TimeRegistration>> LoadTimeRegistrations(ItemsProviderRequest request)
    {
        int totalNumberOfTimeRegistrations = await TimeRegistrationDataService.GetTimeRegistrationCountForEmployeeId(EmployeeId);

       var numberOfTimeRegistrations = Math.Min(request.Count, totalNumberOfTimeRegistrations - request.StartIndex);
       var listItems = await TimeRegistrationDataService.GetPagedTimeRegistrationsForEmployee(EmployeeId, numberOfTimeRegistrations, request.StartIndex);

       return new ItemsProviderResult<TimeRegistration>(listItems, totalNumberOfTimeRegistrations);

    }

    private void ChangeHolidayState()
    {
        Employee.IsOnHoliday = !Employee.IsOnHoliday;
    }
}
