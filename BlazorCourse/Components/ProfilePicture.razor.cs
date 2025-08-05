using Microsoft.AspNetCore.Components;

namespace BlazorCourse.Components;

public partial class ProfilePicture
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
