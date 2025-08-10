using BethanysPieShopHRM.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorCourse.ComponentLibrary;

public partial class Map
{
    string elementId = $"map-{Guid.NewGuid:D}";

    [Parameter]
    public double Zoom { get; set; }

    [Parameter]
    public List<Marker> Markers { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await JSRuntime.InvokeVoidAsync(
        "deliveryMap.showOrUpdate",
        elementId,
        Markers);

    }
}
