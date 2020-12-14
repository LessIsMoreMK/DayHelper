using System.Windows.Input;

namespace DayHelper
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Public Properties

        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }

        #endregion

        #region Constructor

        public RegisterViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        #endregion

        #region Methods
        public void Login()
        {
            IoC.Application.GoToPage(ApplicationPage.Login);
        }
        #endregion
    }
}
