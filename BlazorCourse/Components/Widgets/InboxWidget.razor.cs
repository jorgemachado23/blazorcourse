using BlazorCourse.State;
using Microsoft.AspNetCore.Components;

namespace BlazorCourse.Components.Widgets
{
    public partial class InboxWidget
    {
        [Inject]
        private ApplicationState ApplicationState { get; set; }

        public int MessageCount { get; set; } = 0;

        protected override void OnInitialized()
        {
            // MessageCount = new Random().Next(10);
            MessageCount = ApplicationState.NumberOfMessages;
        }
    }
}
