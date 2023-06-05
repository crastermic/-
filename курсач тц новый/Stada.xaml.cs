using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace курсач_тц_новый
{
    /// <summary>
    /// Логика взаимодействия для Stada.xaml
    /// </summary>
    public partial class Stada : Window
    {
        public List<TblStat> TblStats { get; set; }
        public List<TblStat> Stats = new List<TblStat>();
        public List<Stada> stadas;
        private TblStat SelectedStat { get; set; }
        public TblStat stat { get; set; }
        private TblStat Statred = new TblStat();


        public TblStat SelectedStatistic { get => selectedStatistic;  set { selectedStatistic = value; Fill(); } }


        public List<TblPavilion> tblPavilion;
        public List<TblStat> tblStat;
        private TblStat selectedStatistic;

        public TblPavilion SelectedPavilion { get; }
        public Stada(TblStat selectedStat, TblPavilion selectedPavilion)
        {
            InitializeComponent();
            //Jop.ItemsSource = DB.GetInstance().TblStats.ToList();
            TblStats = DB.GetInstance().TblStats.ToList();


            DataContext = new TblStat();


            DataContext = Statred;
            DataContext = SelectedStat;

            tblPavilion = DB.GetInstance().TblPavilions.ToList();
            SelectedPavilion = selectedPavilion;

            tblStat = DB.GetInstance().TblStats.ToList();
            //SelectedStat = selectedStat;

            SelectedStat = selectedStat;
            stat = new TblStat();
            stat = selectedStat;

            DataContext = this;
        }

        private void Sadd(object sender, RoutedEventArgs e)
        {
            new RedacStat(new TblStat()).ShowDialog();
            Signal(nameof(TblStats));

            //new TblStat();
            //TblStats = DB.GetInstance().TblStats.ToList();
            //SelectedStat = new TblStat();//мб понадобится сделать SelectedStat.и_тут_типо_навигэйшенс
            //DB.GetInstance().TblStats.Add(SelectedStat);
            //DB.GetInstance().SaveChanges();
            //Signal(nameof(TblStats));
        }

        private void Fill([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private void Srem(object sender, RoutedEventArgs e)
        {
            new RedacStat(SelectedStatistic).ShowDialog();
            Search();
        }
    
        private void Sdel(object sender, RoutedEventArgs e)
        {
            var result2 = MessageBox.Show("Вы действительно хотите удалить эту запись?", "Подтвердить", MessageBoxButton.YesNo);
            if (result2 == MessageBoxResult.Yes)
            {

                var remove = DB.GetInstance().TblStats.Find(SelectedStatistic.IdStat);
                DB.GetInstance().TblStats.Remove(remove);
               
                tblStat = DB.GetInstance().TblStats.Where(s => s.IdStat == SelectedStatistic.IdStat).ToList();
                DB.GetInstance().SaveChanges();
                Search();
                InitializeComponent();
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public void Search()
        {
            Signal(nameof(Stats));
        }

    }
}
