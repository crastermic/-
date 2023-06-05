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
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace курсач_тц_новый
{
    /// <summary>
    /// Логика взаимодействия для PlanM.xaml
    /// </summary>
    public partial class PlanM : Window
    {
        public PlanM()
        {
            InitializeComponent();
        }

        private void Closewin(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
