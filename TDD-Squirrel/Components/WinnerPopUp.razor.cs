using Microsoft.AspNetCore.Components;

namespace TDD_Squirrel.Components
{
    public partial class WinnerPopUp
    {
        [Parameter]
        public int? WinnerId { get; set; }

        private int? _winnerId;

        protected override void OnParametersSet()
        {
            _winnerId = WinnerId;
        }

        private void Close()
        {
            _winnerId = null;
        }
    }
}
