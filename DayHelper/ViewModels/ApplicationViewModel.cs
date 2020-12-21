namespace DayHelper
{
    public class ApplicationViewModel : BaseViewModel
    {
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Main;

        public void GoToPage(ApplicationPage page)
        {
            CurrentPage = page;
        }
    }
}
