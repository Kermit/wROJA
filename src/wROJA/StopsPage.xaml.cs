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
    /// Logika obsługująca zakładkę "Wyszukiwanie".
    /// </summary>
    public partial class StopsPage : Page
    {
        private StopsLogic logic = new StopsLogic();

        public StopsPage()
        {
            InitializeComponent();

            // Pobranie danych.
            StopsListBox.ItemsSource = logic.GetAllStops();

            // Przypisanie handlerów.
            StopsListBox.SelectionChanged += new SelectionChangedEventHandler(this.GetLinesForStop);
            LinesForStopListBox.SelectionChanged += new SelectionChangedEventHandler(this.GetTimetable);
        }

        private void GetLinesForStop(object sender, SelectionChangedEventArgs e)
        {
            object selectedItem = StopsListBox.SelectedItem;
            if (selectedItem != null)
            {
                LinesForStopListBox.ItemsSource = logic.GetLinesForStop((StopsService.Stop)selectedItem);
            }
        }

        private void GetTimetable(object sender, SelectionChangedEventArgs e)
        {
            TimetableStopTextBox.Document.Blocks.Clear();

            object selectedItem = LinesForStopListBox.SelectedItem;
            if (selectedItem != null)
            {
                TimetableStopTextBox.Document.Blocks.AddRange(logic.GetTimetable((StopsService.Line)selectedItem));
            }
        }
    }
}
