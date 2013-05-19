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
    /// Logika głównego okna aplikacji.
    /// </summary>
    public partial class wRoja : Window
    {
        public wRoja()
        {
            InitializeComponent();
            
            // Zamknięcie aplikacji.
            CloseButton.Click += (o, e) => { Close(); };
        }      
    }
}
