using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
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
using static курсач_тц_новый.MainWindow;
using static курсач_тц_новый.RedacterCard;

namespace курсач_тц_новый
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string searchText = "";
        private int selectedSorting;
        private TblHall SelectedHall;

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public TblPavilion SelectedPavilion { get; set; }
        public TblStat SelectedStat { get; set; }
        public TblCardhall SelectedCardhall { get; set; }

        public List<TblHall> Halls { get; set; }
        public List<TblStat> TblStats { get; set; }
        public List<TblCardhall> Cardhalls { get; set; }
        public List<TblPavilion> Pavilions { get; set; }
        public List<string> Sorting { get; set; } = new List<string>() { "Без сортировки", "Сначала новые записи", "Сначала старые записи" };
        public Visibility IsAdminVisibility { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            
            Halls = DB.GetInstance().TblHalls.ToList();
            Ivan.ItemsSource = Halls;
            var result =  DB.GetInstance().TblCardhalls.
                Include(s => s.CardPavNavigation).
                Include(s => s.CardHallNavigation).
                Include(s => s.CardRoomNavigation);
            Cardhalls = result.ToList();
            Signal(nameof(Cardhalls));

            
            DataContext = this;
           
        }

        public int SelectedSorting
        {
            get => selectedSorting;
            set
            {
                selectedSorting = value;
                Search();
            }
        }
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                Search();
            }
        }
        public TblHall SelectedHalls
        {
            get => SelectedHall;
            set
            {
                SelectedHall = value;
                Search();
            }
        }

        private void ClStat(object sender, RoutedEventArgs e)
        {
            if (SelectedCardhall !=null)
            {
                Stada stada = new Stada(SelectedStat,SelectedCardhall.CardPavNavigation);
                stada.Show();
            }
            else
            {
                MessageBox.Show("Выберите объект");
            }
        }

        private void ClCont(object sender, RoutedEventArgs e)
        {
            if (SelectedCardhall != null)
            {
              Contact contact = new Contact(SelectedCardhall.CardPavNavigation);
              contact.Show();
            }
            else
            {
                MessageBox.Show("Выберите объект");
            }
        }


        private void ClPlan(object sender, RoutedEventArgs e)
        {
                PlanM planM = new PlanM();
                            planM.Show();
        }

        private void Search()
        {
            var result = DB.GetInstance().TblCardhalls.
                Include(s => s.CardPavNavigation).
                Include(s => s.CardHallNavigation).
                Include(s => s.CardRoomNavigation).Where(s =>
                    s.CardPavNavigation.PavTitle.Contains(searchText)  ||
                    s.CardPavNavigation.PavName.Contains(searchText) ||
                    s.CardPavNavigation.PavOwner.Contains(searchText) ||
                    s.CardHallNavigation.HallSide.Contains(searchText) ||
                    s.CardRoomNavigation.RoomName.Contains(searchText)
                );
            if (SelectedHall != null && SelectedHall.IdHall != 0)
                result = result.Where(s => s.CardHall == SelectedHall.IdHall);
            if (selectedSorting == 1)
                result = result.OrderByDescending(s => s.CardPav);
            else if (selectedSorting == 2)
                result = result.OrderBy(s => s.CardPav);
            Cardhalls = result.ToList();
            Signal(nameof(Cardhalls));
        }

        private void AddPav(object sender, RoutedEventArgs e)
        {
            new RedacterCard(new TblCardhall()).ShowDialog();
            Search();
        }

        public void EditPav(object sender, RoutedEventArgs e)
        {
            if (SelectedCardhall != null)
            {
                new RedacterCard(SelectedCardhall).ShowDialog();
                Search();
            }
            else
            {
                MessageBox.Show("Выберите редактируемый объект");
            }
        }
        


        private void Update(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            DataContext = this;
            Halls = DB.GetInstance().TblHalls.ToList();
            Ivan.ItemsSource = Halls;
        }

        private void RemovePav(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить этот объект?", "Подтвердить", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var db = DB.GetInstance();
                db.TblCardhalls.Remove(SelectedCardhall);
                SelectedCardhall = null;
                db.SaveChanges();
                Search();
              
            }
        }

        
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
