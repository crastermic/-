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

namespace курсач_тц_новый
{
    /// <summary>
    /// Логика взаимодействия для Contact.xaml
    /// </summary>
    public partial class Contact : Window
    {

        public List<Contact> contacts;  
        public List<TblPavilion> tblPavilion;

        public Contact(TblPavilion selectedPavilion)
        {
            InitializeComponent();
            tblPavilion = DB.GetInstance().TblPavilions.ToList();
            SelectedPavilion = selectedPavilion;
            DataContext = this;
        }

        public TblPavilion SelectedPavilion { get; }

        private void closewin(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
