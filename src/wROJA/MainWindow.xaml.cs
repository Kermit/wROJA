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
using wROJA.logic;

namespace wROJA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LinesLogic linesLogic = new LinesLogic();
        private StopsLogic stopsLogic = new StopsLogic();

        public MainWindow()
        {
            InitializeComponent();
            
            CloseButton.Click += new System.Windows.RoutedEventHandler(this.CloseButtonClickHandler);
            LinesTabItem.Loaded += new System.Windows.RoutedEventHandler(this.GetLinesData);

            // Handlery dla Linii
            LinesListBox.SelectionChanged += new SelectionChangedEventHandler(this.GetStopsForLine);
            StopsForLineListBox.SelectionChanged += new SelectionChangedEventHandler(this.GetTimetableForStop);

            // Handlery dla Przystanków
            StopsListBox.SelectionChanged += (o, e) =>
            {
                object selectedItem = StopsListBox.SelectedItem;
                if (selectedItem != null)
                {
                    LinesForStopListBox.ItemsSource = stopsLogic.GetLinesForStop((StopsService.Stop)selectedItem);
                }
            };

            LinesForStopListBox.SelectionChanged += (o, e) =>
            {
                TimetableStopTextBox.Document.Blocks.Clear();

                object selectedItem = LinesForStopListBox.SelectedItem;
                if (selectedItem != null)
                {
                    TimetableStopTextBox.Document.Blocks.AddRange(stopsLogic.GetTimetable((StopsService.Line)selectedItem));
                }
            };

        }

        private void CloseButtonClickHandler(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GetLinesData(object sender, RoutedEventArgs e)
        {
            LinesListBox.ItemsSource = linesLogic.GetAllLines();
            StopsListBox.ItemsSource = stopsLogic.GetAllStops();
            //LinesListBox.Items.Filter = new Predicate<object>(test);
        }

        /*
        private bool test(object item)
        {
            LinesService.Line line = item as LinesService.Line;
            return line.Number.Contains("2");
        }
         */

        private void GetStopsForLine(object sender, SelectionChangedEventArgs e)
        {
            object selectedItem = LinesListBox.SelectedItem;
            if (selectedItem != null)
            {
                StopsForLineListBox.ItemsSource = linesLogic.GetStopsForLine((LinesService.Line)selectedItem);
            }
        }

        private void GetLinesForStop(object sender, SelectionChangedEventArgs e)
        {            
        }

        private void GetTimetableForStop(object sender, SelectionChangedEventArgs e)
        {
            TimetableLineTextBox.Document.Blocks.Clear();

            object selectedItem = StopsForLineListBox.SelectedItem;
            if (selectedItem != null)
            {
                TimetableLineTextBox.Document.Blocks.AddRange(linesLogic.GetTimetable((LinesService.Stop)selectedItem));                                
            }
        }
    }
}
