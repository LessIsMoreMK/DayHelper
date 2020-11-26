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

        #region BRUSHES FIELDS
        /// <summary>
        /// BRUSHES
        /// </summary>
        private Brush backgroundBrush = new BrushConverter().ConvertFromString("#fffcf2") as SolidColorBrush;
        private Brush surfaceBrush = new BrushConverter().ConvertFromString("#ccc5b9") as SolidColorBrush;
        private Brush primaryBrush = new BrushConverter().ConvertFromString("#eb5e28") as SolidColorBrush;
        private Brush secondaryBrush = new BrushConverter().ConvertFromString("#219ebc") as SolidColorBrush;
        private Brush onBackgroundBrush = new BrushConverter().ConvertFromString("#403d39") as SolidColorBrush;
        private Brush onSurfaceBrush = new BrushConverter().ConvertFromString("#252422") as SolidColorBrush;
        private Brush onPrimaryBrush = new BrushConverter().ConvertFromString("#fffcf2") as SolidColorBrush;
        private Brush onSecondaryBrush = new BrushConverter().ConvertFromString("#fffcf2") as SolidColorBrush;
        #endregion

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

        #region BRUSHES PROPERTIES
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
        public Brush SurfaceBrush
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
        public Brush PrimaryBrush
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
        public Brush SecondaryBrush
        {
            get
            {
                return secondaryBrush;
            }
            set
            {
                secondaryBrush = value;
                OnPropertyChanged("SecondaryBrush");
            }
        }
        public Brush OnBackgroundBrush
        {
            get
            {
                return onBackgroundBrush;
            }
            set
            {
                onBackgroundBrush = value;
                OnPropertyChanged("OnBackgroundBrush");
            }
        }
        public Brush OnSurfaceBrush
        {
            get
            {
                return onSurfaceBrush;
            }
            set
            {
                onSurfaceBrush = value;
                OnPropertyChanged("OnSurfaceBrush");
            }
        }
        public Brush OnPrimaryBrush
        {
            get
            {
                return onPrimaryBrush;
            }
            set
            {
                onPrimaryBrush = value;
                OnPropertyChanged("OnPrimaryBrush");
            }
        }
        public Brush OnSecondaryBrush
        {
            get
            {
                return onSecondaryBrush;
            }
            set
            {
                onSecondaryBrush = value;
                OnPropertyChanged("OnSecondaryBrush");
            }
        }
        #endregion

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

        /// <summary>
        /// The command to change the color palette
        /// </summary>
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

            // Light/Dark theme indicator
            bool lightTheme = true;
    }

    #endregion

    #region Methods
    /// <summary>
    /// CHANGE THEME METHOD
    /// </summary>
    public void ChangeTheme()
        {
            if (lightTheme == true)
            {
                BackgroundBrush = new BrushConverter().ConvertFromString("#252422") as SolidColorBrush;
                SurfaceBrush = new BrushConverter().ConvertFromString("#403d39") as SolidColorBrush;
                PrimaryBrush = new BrushConverter().ConvertFromString("#eb5e28") as SolidColorBrush;
                SecondaryBrush = new BrushConverter().ConvertFromString("#219ebc") as SolidColorBrush;
                OnBackgroundBrush = new BrushConverter().ConvertFromString("#ccc5b9") as SolidColorBrush;
                OnSurfaceBrush = new BrushConverter().ConvertFromString("#fffcf2") as SolidColorBrush;
                OnPrimaryBrush = new BrushConverter().ConvertFromString("#252422") as SolidColorBrush;
                OnSecondaryBrush = new BrushConverter().ConvertFromString("#252422") as SolidColorBrush;

                lightTheme = false;
            }
            else
            {
                BackgroundBrush = new BrushConverter().ConvertFromString("#fffcf2") as SolidColorBrush;
                SurfaceBrush = new BrushConverter().ConvertFromString("#ccc5b9") as SolidColorBrush;
                PrimaryBrush = new BrushConverter().ConvertFromString("#eb5e28") as SolidColorBrush;
                SecondaryBrush = new BrushConverter().ConvertFromString("#219ebc") as SolidColorBrush;
                OnBackgroundBrush = new BrushConverter().ConvertFromString("#403d39") as SolidColorBrush;
                OnSurfaceBrush = new BrushConverter().ConvertFromString("#252422") as SolidColorBrush;
                OnPrimaryBrush = new BrushConverter().ConvertFromString("#fffcf2") as SolidColorBrush;
                OnSecondaryBrush = new BrushConverter().ConvertFromString("#fffcf2") as SolidColorBrush;

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
