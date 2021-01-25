using DayHelper.DataModel;
using GalaSoft.MvvmLight.Command;
using Microsoft.Office.Interop.Excel;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;
using Excel = Microsoft.Office.Interop.Excel;

namespace DayHelper
{
    public class AnalyzeViewModel : BaseViewModel
    {
        #region Private Members
        private readonly ConnectedRepository repository = new ConnectedRepository();
        private ObservableCollection<Data> statisticData;
        #endregion

        #region Public Properties
        public ObservableCollection<Data> StatisticData
        {
            get
            {
                if (statisticData == null)
                {
                    statisticData = new ObservableCollection<Data>();
                }

                return statisticData;
            }
            set
            {
                if (value != null)
                {
                    statisticData = value;
                }
            }
        }
        #endregion

        #region Commands
        public RelayCommand<DataGrid> ExportCommand
        {
            get
            {
                return new RelayCommand<DataGrid>(v =>
                {
                    ExportDataGrid(v);
                });
            }
        }
        public RelayCommand<Visual> PrintCommand
        {
            get
            {
                return new RelayCommand<Visual>(v =>
                {
                    PrintDialog printDlg = new PrintDialog();
                    printDlg.PrintVisual(v, "DayHelper. Dane Statystyczne.");
                });
            }
        }
        #endregion

        #region Constructor
        public AnalyzeViewModel()
        {
            StatisticData = new ObservableCollection<Data>();
            CreateData();
        }
        #endregion

        #region Methods
        public void CreateData()
        {
            StatisticData.Add(new Data("Aktywne zadania: ", repository.AmountOfActiveTasks()));
            StatisticData.Add(new Data("Skończone zadania: ", repository.AmountOfFinishedTasks()));
            StatisticData.Add(new Data("Ilość zadań znajdujących się w koszu: ", repository.AmountOfFDeletedTasks()));
            StatisticData.Add(new Data("Średnia ilość dni potrzebnych na wykonanie zadania: ", repository.AverageFinishTime()));
            StatisticData.Add(new Data("Ilość dni najdłuższej trwającego zakończonego zadania: ", repository.DaysOfLongestTask()));

            StatisticData.Add(new Data("Wykonanych zadań na poziomie trudne: ", repository.AmountOfFinishedHardTasks()));
            StatisticData.Add(new Data("Wykonanych zadań na poziomie średnie: ", repository.AmountOfFinishedMediumTasks()));
            StatisticData.Add(new Data("Wykonanych zadań na poziomie łatwe: ", repository.AmountOfFinishedEasyTasks()));
            StatisticData.Add(new Data("Wykonanych zadań bez określonego poziomu: ", repository.AmountOfFinishedUndefinedTasks()));
            
            StatisticData.Add(new Data("Wykonanych zadań o priorytecie normalnym: ", repository.AmountOfFinishedHardTasks()));
            StatisticData.Add(new Data("Wykonanych zadań o priorytecie ważnym: ", repository.AmountOfFinishedImportantTasks()));
            StatisticData.Add(new Data("Wykonanych zadań o priorytecie krytycznym: ", repository.AmountOfFinishedCriticalTasks()));
            StatisticData.Add(new Data("Wykonanych zadań bez określonego priorytetu: ", repository.AmountOfFinishedUndefinedPriorityTasks()));

            StatisticData.Add(new Data("Średnia ilość dni potrzebna na wykonanie zadania o priorytecie normlanym: ", repository.AmountOfDaysNeededForFinishingNormalTasks()));
            StatisticData.Add(new Data("Średnia ilość dni potrzebna na wykonanie zadania o priorytecie ważnym: ", repository.AmountOfDaysNeededForFinishingImportantTasks()));
            StatisticData.Add(new Data("Średnia ilość dni potrzebna na wykonanie zadania o priorytecie krytycznym: ", repository.AmountOfDaysNeededForFinishingCriticalTasks()));
            StatisticData.Add(new Data("Średnia ilość dni potrzebna na wykonanie zadania bez określonego priorytetu: ", repository.AmountOfDaysNeededForFinishingUndefinedTasks()));

            StatisticData.Add(new Data("Średnia ilość dni potrzebna na wykonanie trudnych zadań: ", repository.AmountOfDaysNeededForFinishingHardTasks()));
            StatisticData.Add(new Data("Średnia ilość dni potrzebna na wykonanie średnich zadań: ", repository.AmountOfDaysNeededForFinishingMediumTasks()));
            StatisticData.Add(new Data("Średnia ilość dni potrzebna na wykonanie łatwych zadań: ", repository.AmountOfDaysNeededForFinishingCriticalTasks()));
            StatisticData.Add(new Data("Średnia ilość dni potrzebna na wykonanie zadań bez okreśłonego poziomu: ", repository.AmountOfDaysNeededForFinishingEasyTasks()));
        }

        #endregion

        public static void ExportDataGrid(DataGrid dgrid)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true; 
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < dgrid.Columns.Count; j++) 
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true; 
                sheet1.Columns[j + 1].ColumnWidth = 15; 
                myRange.Value2 = dgrid.Columns[j].Header;
            }
            for (int i = 0; i < dgrid.Columns.Count; i++)
            { 
                for (int j = 0; j < dgrid.Items.Count; j++)
                {
                    TextBlock b = dgrid.Columns[i].GetCellContent(dgrid.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    if(!(b==null))
                        myRange.Value2 = b.Text;
                }
            }
        }

    }

    public class Data
        {
            public string Description { get; set; }
            public int? Value { get; set; }

            public Data()
            {

            }
            public Data(string description, int value)
            {
                Description = description;
                Value = value;
            }
        }
    
}
