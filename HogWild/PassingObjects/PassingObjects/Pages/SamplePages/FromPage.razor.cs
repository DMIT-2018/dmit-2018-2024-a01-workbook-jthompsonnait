#nullable disable
using Microsoft.AspNetCore.Components;
using PassingObjects.Data;

namespace PassingObjects.Pages.SamplePages
{
    public partial class FromPage
    {
        #region Fields
        private EmployeeView employee;
        #endregion

        #region Properties
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        AppState AppState { get; set; }
        #endregion

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            employee = new() { FirstName = "Jake", LastName = "Smith", Age = 25 };
            await InvokeAsync(StateHasChanged);
        }

        private void SendToToPage()
        {
            AppState.EmployeeView = employee;
            NavigationManager.NavigateTo($"/SamplePages/ToPage");
        }
    }
}
