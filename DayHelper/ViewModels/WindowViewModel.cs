using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DayHelper
{
    /// <summary>
    /// Window View Model for custom window style
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Member

        public double WindowMinimumWidth { get; set; } = 800;

        public double WindowMinimumHeight { get; set; } = 500;
        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 15;

        /// <summary>
        /// Flag indicating theme style(true-dark)
        /// </summary>
        private bool theme = false;

        #endregion

        #region Public Properties

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder => mWindow.WindowState == WindowState.Maximized ? 0 : 6;

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
        /// The command to switch theme
        /// </summary>
        public ICommand ThemeCommand { get; set; }

        // Navigation Commands
        public ICommand LoginCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        public ICommand MainCommand { get; set; }
        public ICommand DialogCommand { get; set; }
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

            ThemeCommand = new RelayCommand(ChangeTheme);

            LoginCommand = new RelayCommand(Login);
            SettingsCommand = new RelayCommand(Settings);
            MainCommand = new RelayCommand(Main);
            DialogCommand = new RelayCommand(async () => await Dialog());



            // Fix window resize issue
            var resizer = new WindowResizer(mWindow);
        }

        #endregion

        #region Navigation

        public void Login()
        {
            IoC.Application.GoToPage(ApplicationPage.Login);
        }
        public void Settings()
        {
            IoC.Application.GoToPage(ApplicationPage.Settings);
        }
        public void Main()
        {
            IoC.Application.GoToPage(ApplicationPage.Main);
        }
        public async Task Dialog()
        {
            await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Custom Dialog",
                Message = "bleble"
            });
        }

        #endregion

        #region Private Helpers

        private void ChangeTheme()
        {
            var app = App.Current as App;
            if (theme)
            {
                app.ChangeTheme(new Uri(@"/Styles/ColorsLight.xaml", UriKind.Relative));
                theme = false;
            }
            else
            {
                app.ChangeTheme(new Uri(@"/Styles/ColorsDark.xaml", UriKind.Relative));
                theme = true;
            }
        }

        private Point GetMousePosition()
        {
            var position = Mouse.GetPosition(mWindow);

            if (mWindow.WindowState == WindowState.Normal)
                return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
            else
                return new Point(position.X, position.Y);
        }

        #endregion
    }
}
