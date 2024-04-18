using Microsoft.Win32;
using ProductsListDatabase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

namespace ProductsList.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddNewItem.xaml
    /// </summary>
    public partial class AddNewItem : Window
    {
        private ProductsListDatabase.TradeEntities database;
        public ObservableCollection<ProductsListDatabase.Product> product { get; set; }
        public ObservableCollection<ProductsListDatabase.ProductCategory> category { get; set; }
        public ObservableCollection<ProductsListDatabase.Manafacturer> manafacturers { get; set; }
        public ObservableCollection<Provider> providers { get; set; }
        public ObservableCollection<Unit> units { get; set; }

        private bool isEdit;
        private byte[] imageBytes;

        public AddNewItem(ProductsListDatabase.TradeEntities database, bool isEdit)
        {
            InitializeComponent();
            this.database = database;
            this.isEdit = isEdit;
            product = new ObservableCollection<ProductsListDatabase.Product>(database.Products);
            category = new ObservableCollection<ProductsListDatabase.ProductCategory>(database.ProductCategories);
            manafacturers = new ObservableCollection<Manafacturer>(database.Manafacturers);
            providers = new ObservableCollection<Provider>(database.Providers);
            units = new ObservableCollection<Unit>(database.Units);
            if (isEdit)
            {
                TBLabel.Text = "Изменение товара";
                Title = "Изменение товара";
                CBManafacturers.SetBinding(ItemsControl.ItemsSourceProperty, new Binding()
                {
                    Source = manafacturers
                });
                CBCategory.SetBinding(ItemsControl.ItemsSourceProperty, new Binding()
                {
                    Source = category
                });
                CBProvider.SetBinding(ItemsControl.ItemsSourceProperty, new Binding()
                {
                    Source = providers
                });
                CBUnit.SetBinding(ItemsControl.ItemsSourceProperty, new Binding()
                {
                    Source = units
                });
            }
            DataContext = this;
        }

        public void setItem(ProductsListDatabase.Product product)
        {
            DataContext = product;
        }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            SelectImage();
        }

        private void SelectImage()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Файлы изображений|*.jpg;*.jpeg;*.png;";
            fileDialog.Multiselect = false;
            if (fileDialog.ShowDialog() == true)
            {
                Stream fileStream = fileDialog.OpenFile();
                imageBytes = new byte[fileStream.Length];
                fileStream.Read(imageBytes, 0, (int)fileStream.Length);

                fileStream.Seek(0, SeekOrigin.Begin);
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = fileStream;
                bitmap.EndInit();
                ImagePreview.Visibility = Visibility.Visible;
                TBPlaceForImage.Visibility = Visibility.Collapsed;
                ImagePreview.Fill = new ImageBrush(bitmap);
            }
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            var selectedCategory = CBCategory.SelectedItem as ProductCategory;
            var selectedManufacturer = CBManafacturers.SelectedItem as Manafacturer;
            var selectedProvider = CBProvider.SelectedItem as Provider;
            var selectedUnit = CBUnit.SelectedItem as Unit;
            try
            {
                if (isEdit)
                {
                    database.SaveChanges();
                    TradeListWindow tradeListWindow1 = new TradeListWindow();
                    tradeListWindow1.Show();
                    Close();
                    return;
                }
                else
                {
                    var newItem = new Product
                    {
                        ProductArticleNumber = TBArticle.Text.Trim().ToUpper(),
                        ProductName = TBProductName.Text.Trim(),
                        ProductDescription = TBDescription.Text.Trim(),
                        ProductCategory = category.Where(a => a.Name == selectedCategory.Name).FirstOrDefault().ID,
                        ProductPhoto = imageBytes,
                        ProductManufacturer = manafacturers.Where(a => a.Name == selectedManufacturer.Name).FirstOrDefault().ID,
                        ProductProvider = providers.Where(a => a.Name == selectedProvider.Name).FirstOrDefault().ID,
                        ProductCost = Convert.ToDecimal(TBPrice.Text),
                        ProductDiscountAmount = Convert.ToByte(TBDiscount.Text),
                        ProductMaxDiscount = Convert.ToByte(TBMaxDiscount.Text),
                        ProductQuantityInStock = Convert.ToInt16(TBCount.Text),
                        Unit = units.Where(a => a.Name == selectedUnit.Name).FirstOrDefault().ID,
                    };
                    database.Products.Add(newItem);
                    product.Add(newItem);
                    database.SaveChanges();
                    TradeListWindow tradeListWindow = new TradeListWindow();
                    tradeListWindow.Show();
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Произошла непредвиденная ошибка", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
