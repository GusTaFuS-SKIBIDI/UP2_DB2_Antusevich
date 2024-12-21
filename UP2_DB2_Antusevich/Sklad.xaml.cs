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
    /// Логика взаимодействия для Sklad.xaml
    /// </summary>
    public partial class Sklad : Page
    {
        public Sklad()
        {
            InitializeComponent();
            DataGridUser.ItemsSource = DB_UP2Entities.GetContext().Склад.ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SkladEdit(null));
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            var ДолжностьForRemoving = DataGridUser.SelectedItems.Cast<Склад>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {ДолжностьForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DB_UP2Entities.GetContext().Склад.RemoveRange(ДолжностьForRemoving);
                    DB_UP2Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DataGridUser.ItemsSource = DB_UP2Entities.GetContext().Склад.ToList();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());

                }
            }
        }
        private void BntEdit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonBeck_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();


        }
    }
}
