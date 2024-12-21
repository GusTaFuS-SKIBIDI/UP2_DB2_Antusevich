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

namespace UP2_DB2_Antusevich
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonSotrudniki_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Works();
        }

        private void ButtonPartneri_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Partners();
        }

        private void ButtonProizvodstvo_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Making();
        }

        private void ButtonProdukciya_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Produkt();
        }

        private void ButtonSklad_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Sklad();
        }
        private void Buttonsales_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Sales();
        }
    }
}
