using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Логика взаимодействия для RedacStat.xaml
    /// </summary>
    public partial class RedacStat : Window
    {
        public List<TblStat> TblStats { get; set; }
        public bool Editable { get; set; }
        public List<TblStat> tblStats = new List<TblStat>();
        public List<TblStat> Stats = new List<TblStat>();

        public TblStat SelectedDate { get; set; }
        public TblStat SelectedStat { get; set; }
        public TblStat SelectedStatistic { get; set; }
        public List<TblCardhall> tblCardhalls { get; set; }

        public RedacStat(TblStat selectedStatistic)
        {
            InitializeComponent();
            DB.GetInstance().SaveChanges();
            tblStats = DB.GetInstance().TblStats.ToList();
            tblCardhalls = DB.GetInstance().TblCardhalls.ToList();

            if (selectedStatistic.IdStat == 0 || selectedStatistic.IdStat == null)
            {
                SelectedStatistic = selectedStatistic;
                SelectedStatistic = new TblStat();
            }
            else
            {
                SelectedStatistic = selectedStatistic.Clones();
                Editable = true;

            }

            DataContext = this;
        }

        void Signal(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public void Search()
        {
            Signal(nameof(Stats));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void SaveCloss(object sender, RoutedEventArgs e)
        {

            if (!Editable)
            {
                DB.GetInstance().TblStats.Add(SelectedStatistic);
            }
            else
            {
                var original = DB.GetInstance().TblStats.FirstOrDefault(x => x.IdStat == SelectedStatistic.IdStat);

                // var original = DB.GetInstance().TblStats.
                //Find(SelectedStatistic.IdStat);
                DB.GetInstance().TblStats.Entry(original)

                     .CurrentValues.SetValues(SelectedStatistic);


            }
            DB.GetInstance().SaveChanges();
            Search();
            Close();
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    public static class ProductExtensions
    {
        public static TblStat Clones(this TblStat tblStat)
        {
            var values = DB.GetInstance().TblStats.Entry(tblStat).CurrentValues.Clone();
            var clones = (TblStat)values.ToObject();
            return clones;
        }
    }
}
