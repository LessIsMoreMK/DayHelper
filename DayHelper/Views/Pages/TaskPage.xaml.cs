using GalaSoft.MvvmLight.Messaging;
using System.Windows.Data;

namespace DayHelper
{
    public partial class TaskPage : BasePage<TaskViewModel>
    {
        public TaskPage()
        {
            InitializeComponent();
            Messenger.Default.Send(new ViewCollectionViewSourceMessageToken() { CVS = (CollectionViewSource)(this.Resources["X_CVS"]) });
        }
    }
}
