using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BlazorCourse.Client.Pages;

public partial class EmployeeOverview
{
    public List<Employee> Employees { get; set; } = default!;
    private Employee? _selectedEmployee;
    private string Title = "Employee Overview";

    [Inject]
    private IEmployeeDataService EmployeeDataService { get; set; } = default!;

    protected async override Task OnInitializedAsync()
    {
        Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
    }

    private void ShowQuickView(Employee selectedEmployee)
    {
        _selectedEmployee = selectedEmployee;
    }
}
