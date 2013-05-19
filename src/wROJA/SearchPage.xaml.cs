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
    /// Logika obsługująca zakładkę "Przystanki".
    /// </summary>
    public partial class SearchPage : Page
    {
        private StopsLogic stopsLogic = new StopsLogic();
        private SearchLogic searchLogic = new SearchLogic();

        public SearchPage()
        {
            InitializeComponent();

            // Pobranie danych.
            StartStopCB.ItemsSource = stopsLogic.GetAllStops();
            EndStopCB.ItemsSource = stopsLogic.GetAllStops();

            // Przypisanie handlerów.
            ClearButton.Click += ClearButtonClickHandler;
            SearchButton.Click += SearchButtonClickHandler;
            RoutesListBox.SelectionChanged += RoutesListBoxSelectionChangedHandler;
        }

        private void RoutesListBoxSelectionChangedHandler(object sender, SelectionChangedEventArgs e)
        {
            RoutesTextBox.Document.Blocks.Clear();

            object selectedItem = RoutesListBox.SelectedItem;
            if (selectedItem != null)
            {
                RoutesTextBox.Document.Blocks.AddRange(searchLogic.GetTimetable((SearchService.RouteOptions)selectedItem));
            }
        }

        private void SearchButtonClickHandler(object sender, RoutedEventArgs e)
        {
            StopsService.Stop StartStop = (StopsService.Stop)StartStopCB.SelectedItem;
            StopsService.Stop EndStop = (StopsService.Stop)EndStopCB.SelectedItem;

            RoutesListBox.ItemsSource = searchLogic.GetRoutes(StartStop.ID, EndStop.ID);
        }

        private void ClearButtonClickHandler(object sender, RoutedEventArgs e)
        {
            StartStopCB.Text = "";
            EndStopCB.Text = "";
            SearchButton.IsEnabled = false;
        }
    }
}
