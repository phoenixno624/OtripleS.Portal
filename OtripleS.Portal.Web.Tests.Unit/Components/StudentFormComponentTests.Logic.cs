using FluentAssertions;
using OtripleS.Portal.Web.Models.Basics;
using OtripleS.Portal.Web.Views.Components;
using Xunit;

namespace OtripleS.Portal.Web.Tests.Unit.Components
{
    public partial class StudentFormComponentTests
    {
        [Fact]
        public void ShouldInitializeComponent()
        {
            // given . when
            var initialStudentFormComponent = new StudentFormComponent();

            // then
            initialStudentFormComponent.StudentNameTextBox
                .Should()
                .BeNull();
        }

        [Fact]
        public void ShouldRenderComponent()
        {
            // given
            var expectedState = ComponentState.Content;

            // when
            this.renderedStudentFormComponent = RenderComponent<StudentFormComponent>();

            // then
            this.renderedStudentFormComponent.Instance.State
                .Should()
                .Be(expectedState);

            this.renderedStudentFormComponent.Instance.StudentNameTextBox
                .Should()
                .NotBeNull();

            this.renderedStudentFormComponent.Instance.StudentNameTextBox.PlaceHolder
                .Should()
                .Be("Name");
        }
    }
}