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


        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;
        #endregion

        #region Commands
        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand2 { get; set; }
        #endregion

        #region Constructor

        public ClockDialogViewModel(Window window) : base(window)
<<<<<<< HEAD
        {  
=======
        {
            cWindow = window;
            WindowMinimumWidth = 300;
            WindowMinimumHeight = 300;
>>>>>>> 04a018682d0da939d693c91c9a252a7a6476ab5d
            TitleHeight = 30;



            CloseCommand2 = new RelayCommand(essa);


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