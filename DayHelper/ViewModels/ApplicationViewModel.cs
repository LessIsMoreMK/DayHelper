namespace DayHelper
{
    public class ApplicationViewModel : BaseViewModel
    {
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Task;

        public void GoToPage(ApplicationPage page)
        {
            CurrentPage = page;
        }
    }
}
