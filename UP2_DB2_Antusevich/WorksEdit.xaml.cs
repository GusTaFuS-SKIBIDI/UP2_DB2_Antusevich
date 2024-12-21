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
    /// Логика взаимодействия для WorksEdit.xaml
    /// </summary>
    public partial class WorksEdit : Page
    {
        private Сотрудники _currentДолжность = new Сотрудники();
        public WorksEdit(Сотрудники selectedДолжность)
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
            NavigationService.Navigate(new Works());
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();



            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentДолжность.ФИО)))
            {
                errors.AppendLine("Введите наименование должности");

            }

            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentДолжность.Дата_Приема_На_Работу)))
            {
                errors.AppendLine("Введите количество квалификации");

            }


            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentДолжность.Должность)))
            {
                errors.AppendLine("Введите зарплата");

            }



            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            if (_currentДолжность.ID_Сотрудника == 0)
            {
                DB_UP2Entities.GetContext().Сотрудники.Add(_currentДолжность);
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
