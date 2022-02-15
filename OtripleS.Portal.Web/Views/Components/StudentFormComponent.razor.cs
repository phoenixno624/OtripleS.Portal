using Microsoft.AspNetCore.Components;
using OtripleS.Portal.Web.Models.Basics;
using OtripleS.Portal.Web.Views.Bases;

namespace OtripleS.Portal.Web.Views.Components
{
    public partial class StudentFormComponent : ComponentBase
    {
        public TextBoxBase? StudentNameTextBox { get; set; }
        public ComponentState State { get; set; }

        protected override void OnInitialized()
        {
            State = ComponentState.Content;
        }
    }
}