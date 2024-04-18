using ProductsListDatabase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace ProductsList.Pages
{
    /// <summary>
    /// Логика взаимодействия для TradeListWindow.xaml
    /// </summary>
    public partial class TradeListWindow : Window
    {
        private ProductsListDatabase.TradeEntities database;
        public ObservableCollection<ProductsListDatabase.Product> products { get; set; }
        public ObservableCollection<ProductsListDatabase.Manafacturer> manafacturers { get; set; }

        public class sortElement
        {
            public string name { get; set; }
            public SortDescription sortDescription { get; set; }
        }

        public ObservableCollection<sortElement> sortElementsCollection { get; set; }

        public TradeListWindow()
        {
            InitializeComponent();
            database = new ProductsListDatabase.TradeEntities();
            products = new ObservableCollection<ProductsListDatabase.Product>(database.Products);
            manafacturers = new ObservableCollection<Manafacturer>(database.Manafacturers);
            LVProducts.ItemsSource = products;
            CBManafacturers.ItemsSource = manafacturers;
            CBManafacturers.DisplayMemberPath = "Name";
            manafacturers.Insert(0, new Manafacturer
            {
                ID = 0,
                Name = "Все производители",
            });
            CBManafacturers.SelectedIndex = 0;
            sortElementsCollection = new ObservableCollection<sortElement>
            {
                new sortElement {name = "Сортировать по возрастанию цены", sortDescription = new SortDescription(propertyName: "ProductCost", direction: ListSortDirection.Ascending)},
                new sortElement {name = "Сортировать по убыванию цены", sortDescription = new SortDescription(propertyName: "ProductCost", direction: ListSortDirection.Descending)},
            };
            CBSort.ItemsSource = sortElementsCollection;
            CBSort.DisplayMemberPath = "name";
        }

        private void TBProductSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            LVProducts.SelectedIndex = -1;
            var text = TBProductSearch.Text.Trim().ToLower();

            var manafacturer = CBManafacturers.SelectedItem as Manafacturer;

            var filter = CollectionViewSource.GetDefaultView(LVProducts.ItemsSource);
            filter.Filter = (object a) =>
            {
                var item = a as ProductsListDatabase.Product;
                if (item == null) return true;

                if (manafacturer != null && manafacturer != manafacturers[0])
                {
                    if (item.Manafacturer != manafacturer) return false;
                }
                if (text.Length > 0)
                {
                    if (item.ProductName.ToLower().Contains(text)) return true;
                    if (item.ProductCost.ToString().Contains(text)) return true;
                    if (item.ProductDescription.ToLower().Contains(text)) return true;
                    if (item.Manafacturer.Name.ToLower().Contains(text)) return true;

                    return false;
                }

                return true;
            };
        }

        private void Sort()
        {
            var selectedSort = CBSort.SelectedItem as sortElement;
            var sort = CollectionViewSource.GetDefaultView(LVProducts.ItemsSource);
            sort.SortDescriptions.Clear();
            sort.SortDescriptions.Add(selectedSort.sortDescription);

        }

        private void CBManafacturers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Filter();
            
        }

        private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort();
        }

        private void OpenAddItemPage_Click(object sender, RoutedEventArgs e)
        {
            Pages.AddNewItem addNewItem = new AddNewItem(database, false);
            addNewItem.Owner = this;
            addNewItem.Show();
            Hide();
        }

        private void LVProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LVProducts.SelectedIndex != -1) { 
            Pages.AddNewItem addNewItem = new AddNewItem(database, true);
            addNewItem.setItem(LVProducts.SelectedItem as ProductsListDatabase.Product);
            addNewItem.Show();
            Close();
            }
        }
    }
}