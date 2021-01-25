using DayHelper.DataModel;
using System.Windows;
using System.Windows.Input;

namespace DayHelper
{
    public class RemoveListWindowViewModel : WindowViewModel
    {
        #region Private Fields
        private readonly ConnectedRepository repository = new ConnectedRepository();
        private string selectedText;
        private Window thisWindow;
        #endregion

        #region Public Properties
        public string SelectedText
        {
            get { return selectedText; }
            set
            {
                selectedText = value;
                OnPropertyChanged("SelectedText");
            }
        }
        #endregion

        #region Commands
        public ICommand SaveCommand { get; set; }
        #endregion

        #region Constructor

        public RemoveListWindowViewModel(Window window) : base(window)
        {
            SaveCommand = new RelayCommand(Save);
            thisWindow = window;
        }
        #endregion

        #region Methods
        public void Save()
        {
            repository.RemoveList(SelectedText);

            thisWindow.Close();
        }
        #endregion
    }
}
