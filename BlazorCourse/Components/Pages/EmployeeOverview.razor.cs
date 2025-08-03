using BethanysPieShopHRM.Shared.Domain;
using BlazorCourse.Services;

namespace BlazorCourse.Components.Pages;

public partial class EmployeeOverview
{
    public List<Employee> Employees { get; set; } = default!;

    protected async override Task OnInitializedAsync()
    {
        await Task.Delay(1000); // Simulate a delay for data fetching
        Employees = MockDataService.Employees;
    }
}
