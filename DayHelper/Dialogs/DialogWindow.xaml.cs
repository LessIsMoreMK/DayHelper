using System.Windows;

namespace DayHelper
{
    public partial class DialogWindow : Window
    {
        #region Private Members

        private DialogViewModel mViewModel;

        #endregion

        #region Public Properties

        public DialogViewModel ViewModel
        {
            get => mViewModel;
            set
            {
                mViewModel = value;

                DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor

        public DialogWindow()
        {
            InitializeComponent();
        }

        #endregion
    }
}
