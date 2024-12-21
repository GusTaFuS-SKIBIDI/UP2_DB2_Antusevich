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
    /// Логика взаимодействия для MakingEdit.xaml
    /// </summary>
    public partial class MakingEdit : Page
    {
        private Производство _currentДолжность = new Производство();
        public MakingEdit(Производство selectedДолжность)
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
            NavigationService.Navigate(new Making());
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();



            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentДолжность.Название)))
            {
                errors.AppendLine("Введите наименование Название");

            }

            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentДолжность.Дата_Начала)))
            {
                errors.AppendLine("Введите Дата_Начала");

            }


            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentДолжность.ID_Продукции)))
            {
                errors.AppendLine("Введите ID_Продукции");

            }
            



            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            if (_currentДолжность.ID_Производства == 0)
            {
                DB_UP2Entities.GetContext().Производство.Add(_currentДолжность);
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
