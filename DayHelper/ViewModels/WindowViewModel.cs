using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace DayHelper
{
    /// <summary>
    /// Window View Model for custom window style
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Member

        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 15;

        private Brush backgroundBrush = Brushes.White;
        private Color surfaceBrush;
        private Color primaryBrush;
        private Color secondaryBrush;
        private Color onBackgroundBrush;
        private Color onSurfaceBrush;
        private Color onPrimaryBrush;
        private Color onSecondaryBrush;

        #endregion

        #region Public Properties
        public bool lightTheme = true;
        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder); } }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get => mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            set => mWindowRadius = value;
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// Background brush property
        /// </summary>
        public Brush BackgroundBrush
        {
            get 
            { 
                return backgroundBrush; 
            }
            set 
            {
                backgroundBrush = value;
                OnPropertyChanged("BackgroundBrush");
            }
        }

        public Color SurfaceBrush
        {
            get
            {
                return surfaceBrush;
            }
            set
            {
                surfaceBrush = value;
                OnPropertyChanged("SurfaceBrush");
            }
        }

        public Color PrimaryBrush
        {
            get
            {
                return primaryBrush;
            }
            set
            {
                primaryBrush = value;
                OnPropertyChanged("PrimaryBrush");
            }
        }
        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to show the system menu of the window
        /// </summary>
        public ICommand MenuCommand { get; set; }

        public ICommand ThemeChangeCommand { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            // Listen out for the window resizing
            mWindow.StateChanged += (sender, e) =>
            {
                // Fire off events for all properties that are affected by a resize
                OnPropertyChanged(() => ResizeBorderThickness);
                OnPropertyChanged(() => WindowRadius);
                OnPropertyChanged(() => WindowCornerRadius);
            };

            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            ThemeChangeCommand = new RelayCommand(() => ChangeTheme());
            // Fix window resize issue
            var resizer = new WindowResizer(mWindow);


        }

        #endregion

        #region Methods
        /// <summary>
        /// Change theme Method
        /// </summary>
        /// <returns></returns>
        public void ChangeTheme()
        {
            if (lightTheme == true)
            {
                BackgroundBrush = Brushes.Gray;
                SurfaceBrush = (Color)ColorConverter.ConvertFromString("#403d39");
                PrimaryBrush = (Color)ColorConverter.ConvertFromString("#eb5e28");

                lightTheme = false;
            }
            else
            {
                BackgroundBrush = Brushes.White;
                SurfaceBrush = (Color)ColorConverter.ConvertFromString("#ccc5b9");
                PrimaryBrush = (Color)ColorConverter.ConvertFromString("#eb5e28");
                lightTheme = true;
            }
        }
        #endregion

        #region Private Helpers

        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        private Point GetMousePosition()
        {
            var position = Mouse.GetPosition(mWindow);

            if (Application.Current.MainWindow.WindowState == WindowState.Normal)
                return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
            else
                return new Point(position.X, position.Y);
        }

        #endregion
    }
}
