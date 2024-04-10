using Microsoft.AspNetCore.Components;
using PassingObjects.Data;

namespace PassingObjects.Pages.SamplePages
{
    public partial class ToPage
    {
        #region Fields
        private EmployeeView employee;
        #endregion

        #region Properties

        [Inject]
        AppState AppState { get; set; }
        #endregion

        protected override void OnInitialized()
        {
            if (AppState.EmployeeView is null) return;
            employee = AppState.EmployeeView;
        }
    }
}
