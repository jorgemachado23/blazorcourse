using BethanysPieShopHRM.Shared.Domain;
using BlazorCourse.Contracts.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorCourse.Components.Pages;

public partial class EmployeeAdd
{
    [SupplyParameterFromForm]
    public Employee Employee { get; set; }

    [Inject]
    public IEmployeeDataService? EmployeeDataService { get; set; }
    protected string Message = string.Empty;
    protected bool IsSaved = false;

    protected override void OnInitialized()
    {
        Employee ??= new();
    }

    private async Task OnSubmit()
    {
        await EmployeeDataService?.AddEmployee(Employee);
        IsSaved = true;
        Message = "Employee added successfully!";
    }
}
