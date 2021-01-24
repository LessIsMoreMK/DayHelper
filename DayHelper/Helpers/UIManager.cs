using System.Threading.Tasks;
using System.Windows;

namespace DayHelper
{
    public class UIManager : IUIManager
    {
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            var tcs = new TaskCompletionSource<bool>();

            Application.Current.Dispatcher.Invoke(async () =>
            {
                try
                {
                    //await new DialogMessageBox().ShowDialog(viewModel);
                }
                finally
                {
                    tcs.SetResult(true);
                }
            });
            return tcs.Task;
        }

    }
}