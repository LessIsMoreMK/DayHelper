namespace DayHelper
{
    public class MainViewModel : BaseViewModel
    {
        #region Fields

        private string _Tekst { get; set; } = "Asdf";

        #endregion

        #region Properties
        public string Tekst
        {
            get => _Tekst;
            set
            {
                if (_Tekst != value)
                {
                    _Tekst = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Commands

        public RelayCommand StartCommand { get; set; }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            StartCommand = new RelayCommand(Start);
        }

        #endregion

        #region Methods

        public void Start()
        {
            Tekst = "asdfasdf";
        }

        #endregion
    }
}
