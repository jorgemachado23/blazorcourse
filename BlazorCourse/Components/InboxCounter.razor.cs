using BlazorCourse.State;
using Microsoft.AspNetCore.Components;

namespace BlazorCourse.Components;

public partial class InboxCounter
{
    private int MessageCount;

    [Inject]
    private ApplicationState ApplicationState { get; set; }

    protected override void OnInitialized()
    {
        MessageCount = new Random().Next(1, 100);

        ApplicationState.NumberOfMessages = MessageCount;
    }
}
