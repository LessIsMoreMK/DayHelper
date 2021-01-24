using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DayHelper
{
    public class ClockDialogViewModel : WindowViewModel
    {
        #region Private Fields
        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window cWindow;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int cWindowRadius = 15;



        #endregion

        #region Public Properties

        public string Title { get; set; }

        public Control Content { get; set; }

        public Thickness OuterMarginThickness { get; set; } = new Thickness(1);


        
        #endregion

        #region Commands
        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand2 { get; set; }
        #endregion

        #region Constructor

        public ClockDialogViewModel(Window window) : base(window)
        {
           // CloseCommand = new RelayCommand(() => mWindow.Close());
           // CloseCommand2 = new RelayCommand(essa);


        }
        #endregion

        #region Methods
        void essa()
        {
            cWindow.Hide();


        }
        void startClock()
        {

        }
        void pauseClock()
        {

        }
        #endregion
    }
}