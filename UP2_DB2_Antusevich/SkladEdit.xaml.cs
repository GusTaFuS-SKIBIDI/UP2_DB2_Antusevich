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
    /// Логика взаимодействия для SkladEdit.xaml
    /// </summary>
    public partial class SkladEdit : Page
    {
        private Склад _currentДолжность = new Склад();
        public SkladEdit(Склад selectedДолжность)
        {
            InitializeComponent();
            if (selectedДолжность != null)
            {
                _currentДолжность = selectedДолжность;
            }
            DataContext = _currentДолжность;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Sklad());
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();



            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentДолжность.Название)))
            {
                errors.AppendLine("Введите наименование должности");

            }

            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentДолжность.Адрес)))
            {
                errors.AppendLine("Введите количество квалификации");

            }


            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentДолжность.Вместимость)))
            {
                errors.AppendLine("Введите зарплата");

            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentДолжность.ID_Продукции)))
            {
                errors.AppendLine("Введите зарплата");

            }



            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            if (_currentДолжность.ID_Склада == 0)
            {
                DB_UP2Entities.GetContext().Склад.Add(_currentДолжность);
            }

            try
            {
                DB_UP2Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }
    }
}
