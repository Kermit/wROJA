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
    /// Logika obłsugi zakładki "Linie".
    /// </summary>
    public partial class LinesPage : Page
    {
        private LinesLogic linesLogic = new LinesLogic();

        public LinesPage()
        {
            InitializeComponent();

            // Pobranie danych dla głównej listy.
            LinesListBox.ItemsSource = linesLogic.GetAllLines();

            // Przypisanie handlerów.
            LinesListBox.SelectionChanged += new SelectionChangedEventHandler(this.GetStopsForLine);
            StopsForLineListBox.SelectionChanged += new SelectionChangedEventHandler(this.GetTimetable);
        }

        private void GetStopsForLine(object sender, SelectionChangedEventArgs e)
        {
            object selectedItem = LinesListBox.SelectedItem;
            if (selectedItem != null)
            {
                StopsForLineListBox.ItemsSource = linesLogic.GetStopsForLine((LinesService.Line)selectedItem);
            }
        }

        private void GetTimetable(object sender, SelectionChangedEventArgs e)
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
