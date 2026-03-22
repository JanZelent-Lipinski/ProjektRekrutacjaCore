using ProjektRekrutacjaCore.Models;
using ProjektRekrutacjaCore.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace ProjektRekrutacjaCore.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Constructor

        public MainWindowViewModel()
        {
            ClearSearchCommand = new RelayCommand(() =>
            {
                SearchText = string.Empty;
            });

            LoadProducts();
        }

        #endregion

        #region Properties

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                LoadProducts();
            }
        }

        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        #endregion

        #region Commands

        public ICommand ClearSearchCommand { get; set; }

        #endregion

        #region Methods

        public void LoadProducts()
        {
            using (var context = new AppDbContext())
            {
                var productsList = BuildQuery(context).ToList();

                Products.Clear();

                foreach (var product in productsList)
                {
                    Products.Add(product);
                }
            }
        }

        private IQueryable<Product> BuildQuery(AppDbContext context)
        {
            var asortymenty = context.Asortymenty.ToList();
            var waluty = context.Waluty.ToList();
            var stanyMagazynowe = context.StanyMagazynowe.ToList();
            var jednostkiMiarAsortymentow = context.JednostkiMiarAsortymentow.ToList();
            var jednostkiMiar = context.JednostkiMiar.ToList();
            var kodyKreskowe = context.KodyKreskowe.ToList();

            var searchTextLower = SearchText?.ToLower();

            var query =
                from asortyment in asortymenty

                where string.IsNullOrEmpty(searchTextLower)
                   || (asortyment.Nazwa != null && asortyment.Nazwa.ToLower().Contains(searchTextLower))
                   || kodyKreskowe.Any(k =>
                        k.JednostkaMiaryAsortymentu_Id == asortyment.Id &&
                        k.Kod != null && k.Kod.ToLower().Contains(searchTextLower))

                join waluta in waluty
                    on asortyment.WalutaCenyEwidencyjnej_Id equals waluta.Id into walutyJoin
                from waluta in walutyJoin.DefaultIfEmpty()

                join stan in stanyMagazynowe
                    on asortyment.Id equals stan.Asortyment_Id into stanyJoin

                join jma in jednostkiMiarAsortymentow
                    on asortyment.Id equals jma.Asortyment_Id into jmaJoin
                from jma in jmaJoin.DefaultIfEmpty()

                join jednostka in jednostkiMiar
                    on jma != null ? jma.JednostkaMiary_Id : 0 equals jednostka.Id into jednostkiJoin
                from jednostka in jednostkiJoin.DefaultIfEmpty()

                join kod in kodyKreskowe
                    on asortyment.Id equals kod.JednostkaMiaryAsortymentu_Id into kodyJoin

                select new Product
                {
                    Name = asortyment.Nazwa,
                    Price = asortyment.CenaEwidencyjna ?? 0,
                    Currency = waluta != null ? waluta.Symbol : null,
                    Quantity = stanyJoin.Sum(s => (decimal?)s.IloscDostepna) ?? 0,
                    Unit = jednostka != null ? jednostka.Nazwa : null,
                    Barcode = kodyJoin.Select(k => k.Kod).FirstOrDefault()
                };

            return query.AsQueryable();
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}