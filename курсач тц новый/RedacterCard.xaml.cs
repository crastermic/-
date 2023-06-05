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
    /// Логика взаимодействия для RedacterPav.xaml
    /// </summary>
    public partial class RedacterCard : Window
    {
        private string searchText = "";
        private int selectedSorting;
        private TblHall SelectedHall;

        public List<TblCardhall> Cardhalls { get; set; }
        public bool Editable { get; set; }
        public List<TblPavilion> TblPavilion { get; set; }
        
        public List<TblCardhall> tblCardhalls { get; set; }
        public List<TblPavilion> tblPavilions { get; set; }
        public List<TblHall> tblHalls { get; set; }
        public List<TblRoom> tblRooms { get; set; }

        public TblCardhall SelectedCardhall { get; set; }

        public RedacterCard(TblCardhall selectedCardhall)
        {
            InitializeComponent();
            DB.GetInstance().SaveChanges();
            tblCardhalls = DB.GetInstance().TblCardhalls.ToList();
            tblPavilions = DB.GetInstance().TblPavilions.ToList();
            tblHalls = DB.GetInstance().TblHalls.ToList();
            tblRooms = DB.GetInstance().TblRooms.ToList();

            pavbuthall.ItemsSource = tblHalls;
            rooma.ItemsSource = tblRooms;


            if (selectedCardhall.IdCard == 0 || selectedCardhall.IdCard == null)
            {
                SelectedCardhall = selectedCardhall;
                SelectedCardhall.CardPavNavigation = new TblPavilion();
            }
            else
            {
                SelectedCardhall = selectedCardhall.Clone();
                Editable = true;
            }
            
            DataContext = this;
            
        }

        void Signal(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public void Search()
        {
            Signal(nameof(Cardhalls));
        }

        

        public event PropertyChangedEventHandler? PropertyChanged;

        private void SaveClose(object sender, RoutedEventArgs e)
        {

            if (!Editable)
            {
                DB.GetInstance().TblCardhalls.Add(SelectedCardhall);
            }
            else
            {
                var original = DB.GetInstance().TblCardhalls.FirstOrDefault(x => x.IdCard == SelectedCardhall.IdCard);
            }
            DB.GetInstance().SaveChanges();
            Search();
            Close();
        }


        private void rooma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void pavbuthall_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void otdelbutpav_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
        public static class ProductExtension
        {
            public static TblCardhall Clone(this TblCardhall tblCardhall)
            {
                var values = DB.GetInstance().TblCardhalls.Entry(tblCardhall).CurrentValues.Clone();
                var clone = (TblCardhall)values.ToObject();
                clone.CardHallNavigation = tblCardhall.CardHallNavigation;
                clone.CardPavNavigation = tblCardhall.CardPavNavigation;
                clone.CardRoomNavigation = tblCardhall.CardRoomNavigation;
                return clone;
            }
        }
    
}
