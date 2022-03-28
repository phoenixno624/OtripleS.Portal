using Microsoft.AspNetCore.Components;
using OtripleS.Portal.Web.Views.Bases;

namespace OtripleS.Portal.Web.Views.Components
{
    public partial class StudentRegistrationComponent : ComponentBase
    {
        public TextBoxBase TextBox { get; set; }

        public void ButtonClicked()
        {
            string textBoxValue = TextBox.Value;
            Console.WriteLine(textBoxValue);
        }
    }
}