using System.Windows.Input;

namespace DayHelper
{
    public class LoginViewModel : BaseViewModel
    {
        #region Public Properties

        #endregion

        #region Commands

        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructor

        public LoginViewModel()
        {
            RegisterCommand = new RelayCommand(Register);
        }

        #endregion

        #region Methods

        public void Register()
        {
            IoC.Application.GoToPage(ApplicationPage.Register);
        }

        #endregion
    }
}
