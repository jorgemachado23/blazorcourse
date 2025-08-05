using BethanysPieShopHRM.Shared.Domain;
using BlazorCourse.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorCourse.Components.Pages;

public partial class EmployeeDetail
{
    [Parameter]
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = new Employee();

    protected async override Task OnInitializedAsync()
    {
        await Task.Delay(1000); // Simulate a delay for data fetching
        Employee = MockDataService.Employees?.FirstOrDefault(e => e.EmployeeId == EmployeeId) ?? new Employee();
    }

    private void ChangeHolidayState()
    {
        Employee.IsOnHoliday = !Employee.IsOnHoliday;
    }
}
