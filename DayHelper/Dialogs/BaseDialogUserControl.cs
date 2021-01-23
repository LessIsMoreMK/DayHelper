using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DayHelper
{
    public class BaseDialogUserControl : UserControl
    {

        #region Private Members

        private readonly DialogWindow mDialogWindow;

        #endregion

        #region Public Properties

        public int WindowMinimumWidth { get; set; } = 250;

        public int WindowMinimumHeight { get; set; } = 100;

        public int TitleHeight { get; set; } = 30;

        public string Title { get; set; } = "Ok";

        #endregion

        #region Public Commands

        public ICommand CloseCommand { get; private set; }

        #endregion

        #region Constructor

        public BaseDialogUserControl()
        {
            mDialogWindow = new DialogWindow();

            mDialogWindow.ViewModel = new DialogViewModel(mDialogWindow);

            CloseCommand = new RelayCommand(() => mDialogWindow.Close());
        }

        #endregion

        #region Public Methods

        public Task ShowDialog<T>(T viewModel)
            where T : BaseDialogViewModel
        {
            // Create a task awaiting for closing popup
            var tcs = new TaskCompletionSource<bool>();

            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    // Match controls expected sizes to dialog window view model
                    mDialogWindow.ViewModel.TitleHeight = TitleHeight;
                    mDialogWindow.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title) ? Title : viewModel.Title;

                    // Set this dialog to the dialog window content 
                    mDialogWindow.ViewModel.Content = this;

                    // Setup this controls data context binding to the view model 
                    DataContext = viewModel;

                    mDialogWindow.Show();
                }
                finally
                {
                    // Let caller know we finish
                    tcs.TrySetResult(true);
                }
            });

            return tcs.Task;
        }

        #endregion
    }
}
