using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wROJA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LinesService.ILinesService linesService;
        private StopsService.IStopsService stopsService;

        public MainWindow()
        {
            linesService = new LinesService.LinesServiceClient();
            stopsService = new StopsService.StopsServiceClient();

            InitializeComponent();
            
            CloseButton.Click += new System.Windows.RoutedEventHandler(this.CloseButtonClickHandler);
            LinesTabItem.Loaded += new System.Windows.RoutedEventHandler(this.GetLinesData);
            LinesListBox.SelectionChanged += new SelectionChangedEventHandler(this.GetStopsForLine);
            StopsForLineListBox.SelectionChanged += new SelectionChangedEventHandler(this.GetTimetableForStop);
        }

        private void CloseButtonClickHandler(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GetLinesData(object sender, RoutedEventArgs e)
        {
            LinesListBox.ItemsSource = linesService.GetAllLines();
            StopsListBox.ItemsSource = stopsService.GetAllStops();
            //LinesListBox.Items.Filter = new Predicate<object>(test);
        }

        /*
        private bool test(object item)
        {
            LinesService.Line line = item as LinesService.Line;
            return line.Number.Contains("2");
        }
         * */

        private void GetStopsForLine(object sender, SelectionChangedEventArgs e)
        {
            object selectedItem = LinesListBox.SelectedItem;
            if (selectedItem != null)
            {
                int lineID = ((LinesService.Line)selectedItem).ID;
                int routeID = ((LinesService.Line)selectedItem).RouteID;

                StopsForLineListBox.ItemsSource = linesService.GetStopsForLine(lineID, routeID);
            }
        }

        private void GetTimetableForStop(object sender, SelectionChangedEventArgs e)
        {
            TimetableLineTextBox.Document.Blocks.Clear();

            object selectedItem = StopsForLineListBox.SelectedItem;
            if (selectedItem != null)
            {
                int routeDetailsID = ((LinesService.Stop)selectedItem).RouteDetailsID;

                LinesService.Timetable[] timetables = linesService.GetTimetableForStop(routeDetailsID);

                foreach (LinesService.Timetable timetable in timetables)
                {
                    Run dayNameRun = new Run("<sup>" + timetable.DayName + "</sup>");
                    dayNameRun.FontSize = 12;
                    dayNameRun.FontWeight = FontWeights.Bold;

                    //Dodać ładneijszy wygląd
                    Paragraph p = new Paragraph();
                    p.Inlines.Add(dayNameRun);
                    p.Inlines.Add(Environment.NewLine);
                    p.Inlines.Add(new Run(timetable.Table));
                    p.Inlines.Add(Environment.NewLine);
                    p.Inlines.Add(new Run(timetable.Legend));
                    TimetableLineTextBox.Document.Blocks.Add(p);                    
                }
            }
        }
    }
}
