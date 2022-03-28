using Microsoft.AspNetCore.Components;

namespace OtripleS.Portal.Web.Views.Bases
{
    public partial class TextBoxBase : ComponentBase
    {
        [Parameter]
        public string Value { get; set; }
        [Parameter]
        public string Placeholder { get; set; }

        public void SetValue(string value) =>
            Value = value;
        public void SetPlaceholder(string value) =>
            Value = value;
    }
}