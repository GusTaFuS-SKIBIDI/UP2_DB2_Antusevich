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
    /// Логика взаимодействия для Sales.xaml
    /// </summary>
    /// 

    public partial class Sales : Page
    {
        private bool isDataLoaded = false;

        public Sales()
        {
            InitializeComponent();

            // Проверка, если данные уже были загружены
            if (DataGridUser.ItemsSource == null)
            {
                // Загружаем данные из базы
                var partners = DB_UP2Entities.GetContext().Партнеры.ToList();

                // Для каждого партнёра считаем количество уникальных ID_Производства
                var data = partners.Select(p => new
                {
                    Название = p.Название,
                    КоличествоПроизводств = DB_UP2Entities.GetContext().Производство
                        .Where(pr => pr.ID_Производства == p.ID_Производства)  // Фильтрация по ID_Производства
                        .Select(pr => pr.ID_Производства)
                        .Distinct()
                        .Count(), // Подсчитываем количество уникальных ID_Производства
                                  // Логика расчета скидки
                    Скидка = CalculateDiscount(DB_UP2Entities.GetContext().Производство
                        .Where(pr => pr.ID_Производства == p.ID_Производства)
                        .Select(pr => pr.ID_Производства)
                        .Distinct()
                        .Count())
                }).ToList();

                // Привязываем данные к DataGrid
                DataGridUser.ItemsSource = data;
            }
        }

        // Метод для расчета скидки
        private int CalculateDiscount(int productionCount)
        {
            if (productionCount >= 0 && productionCount <= 10)
                return 10;
            else if (productionCount >= 11 && productionCount <= 100)
                return 20;
            else if (productionCount >= 101 && productionCount <= 500)
                return 30;
            else
                return 0; // или любая другая скидка, если количество больше 500
        }

        private void ButtonBeck_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
          
        }
    }
    
}
