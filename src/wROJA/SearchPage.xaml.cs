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
            List<StopsService.Stop> stopsList = new List<StopsService.Stop>();
            stopsList.Add(new StopsService.Stop());
            stopsList.AddRange(stopsLogic.GetAllStops());

            StartStopCB.ItemsSource = stopsList;
            EndStopCB.ItemsSource = stopsList;
            
            StartStopCB.SelectedIndex = 0;
            EndStopCB.SelectedIndex = 0;

            // Przypisanie handlerów.
            ClearButton.Click += ClearButtonClickHandler;
            SearchButton.Click += SearchButtonClickHandler;
            RoutesListBox.SelectionChanged += RoutesListBoxSelectionChangedHandler;
            StartStopCB.SelectionChanged += ComboBoxSelectionChanged;
            EndStopCB.SelectionChanged += ComboBoxSelectionChanged;
        }

        void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StopsService.Stop StartStop = (StopsService.Stop)StartStopCB.SelectedItem;
            StopsService.Stop EndStop = (StopsService.Stop)EndStopCB.SelectedItem;

            if (StartStop != null && EndStop != null &&
                !string.IsNullOrEmpty(StartStop.Name) && !string.IsNullOrEmpty(EndStop.Name))
            {
                if (StartStop.Name == EndStop.Name)
                {                    
                    MessageBox.Show("Przystanek początkowy i końcowy muszą być różne.", "Błąd wyszukiwania");
                    ((ComboBox)sender).SelectedItem = e.RemovedItems[0];
                    SearchButton.IsEnabled = false;
                }
                else
                {
                    SearchButton.IsEnabled = true;
                }
            }
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

            SearchService.RouteOptions[] result = searchLogic.GetRoutes(StartStop.ID, EndStop.ID);

            if (result.Length != 0)
            {
                RoutesListBox.ItemsSource = result;
            }
            else
            {
                MessageBox.Show("Nie znaleziono bezpośrednich połączeń", "Brak wyników");
            }
        }

        private void ClearButtonClickHandler(object sender, RoutedEventArgs e)
        {
            StartStopCB.Text = "";
            EndStopCB.Text = "";
            SearchButton.IsEnabled = false;
        }
    }
}
