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
    /// Логика взаимодействия для Works.xaml
    /// </summary>
    public partial class Works : Page
    {
        public Works()
        {
            InitializeComponent();
            DataGridUser.ItemsSource = DB_UP2Entities.GetContext().Сотрудники.ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WorksEdit(null));
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            var ДолжностьForRemoving = DataGridUser.SelectedItems.Cast<Сотрудники>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {ДолжностьForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DB_UP2Entities.GetContext().Сотрудники.RemoveRange(ДолжностьForRemoving);
                    DB_UP2Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DataGridUser.ItemsSource = DB_UP2Entities.GetContext().Сотрудники.ToList();

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
