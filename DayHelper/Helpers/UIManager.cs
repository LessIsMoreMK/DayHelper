using System.Threading.Tasks;

namespace DayHelper
{
    public class UIManager : IUIManager
    {
        /// <summary>
        /// Displays a single message box to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            return new DialogMessageBox().ShowDialog(viewModel);
        }

        public Task ShowMessage2(ClockDialogViewModel clockDialogViewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}