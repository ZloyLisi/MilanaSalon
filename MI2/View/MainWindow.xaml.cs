using MI2.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MI2.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Visibility _editButtonVisibility = Visibility.Visible;
        private Visibility _deletButtonVisibility = Visibility.Visible;

        private SalonBDEntities _context;
        private ZakazWindow _addZakaz;

        public MainWindow()
        {
            InitializeComponent();
            _context = SalonBDEntities.GetContext();
            LoadCategories();
        }
        public Visibility EditButtonVisibility
        {
            get { return _editButtonVisibility; }
            set
            {
                _editButtonVisibility = value;
                OnPropertyChanged(nameof(EditButtonVisibility));
            }
        }

        public Visibility DeletButtonVisibility
        {
            get { return _deletButtonVisibility; }
            set
            {
                _deletButtonVisibility = value;
                OnPropertyChanged(nameof(EditButtonVisibility));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void LoadCategories()
        {
            SubCategoryComboBox.ItemsSource = _context.Category.ToList();
            if (SubCategoryComboBox.Items.Count > 0)
                SubCategoryComboBox.SelectedIndex = 0;
        }

        private void UpdateProductList(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategory = SubCategoryComboBox.SelectedItem as Category;
            if (selectedCategory != null)
            {
                ItemsControl.ItemsSource = _context.Product
                    .Where(p => p.IdCategory == selectedCategory.Id).ToList();
            }
        }


        private void Description_Click(object sender, RoutedEventArgs e)
        {
            Button detailsButton = sender as Button;
            Product selectedItem = detailsButton.DataContext as Product;

            if (selectedItem != null)
            {
                DetailsWindow detailsWindow = new DetailsWindow
                {
                    DataContext = selectedItem 
                };
                detailsWindow.ShowDialog(); 
            }
        }
        private void OrderButton(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var product = button.DataContext as Product;
            if (product != null)
            {
                var orderWindow = new OrdeWindow(product); 
                var result = orderWindow.ShowDialog(); 

                if (result == true)
                {
                
                }
            }
        }

        private void AddTovar(object sender, RoutedEventArgs e)
        {
            var addTovatWindow = new AddTovarWindow();
            var result = addTovatWindow.ShowDialog();

            if (result == true)
            {
               
                UpdateProductList(null,null);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Button editButton = sender as Button;
            Product selectedProduct = editButton.DataContext as Product;

            if (selectedProduct != null)
            {
                AddTovarWindow addEditDressWindow = new AddTovarWindow(selectedProduct);
                var result = addEditDressWindow.ShowDialog();

                if (result == true)
                {
                   
                    UpdateProductList(null,null);
                }
            }
        }

        private void Delet_Click(object sender, RoutedEventArgs e)
        {

           
            Button deleteButton = sender as Button;
            if (deleteButton != null)
            {
             
                Product product = deleteButton.DataContext as Product;
                if (product != null)
                {
                    MessageBoxResult confirmationResult = MessageBox.Show(
                        "Вы уверены, что хотите удалить этот элемент?",
                        "Подтверждение удаления",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);

                    if (confirmationResult == MessageBoxResult.Yes)
                    {
                       
                        SalonBDEntities.GetContext().Product.Remove(product);
                        SalonBDEntities.GetContext().SaveChanges();

                        // Обновляем ItemsControl
                        UpdateProductList(null,null);
                    }
                }
            }
        }

        private void ZakazWindow(object sender, RoutedEventArgs e)
        {
            if (_addZakaz == null || !_addZakaz.IsVisible)
            {
                _addZakaz = new ZakazWindow();
                _addZakaz.Show();
            }
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.ShowDialog();
        }

        private void User(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.ShowDialog();
        }

        private void ExitWindow(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                
                Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

                
                for (int i = Application.Current.Windows.Count - 1; i >= 0; i--)
                {
                    var window = Application.Current.Windows[i];
                    if (window != this)
                    {
                        window.Close();
                    }
                }

                
                this.Close();

               
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();

                
                Application.Current.ShutdownMode = ShutdownMode.OnLastWindowClose;
            }
        }
    }
    
}
