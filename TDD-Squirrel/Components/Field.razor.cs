using Microsoft.AspNetCore.Components;

namespace TDD_Squirrel.Components
{
    public partial class Field
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
