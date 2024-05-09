using MI2.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MI2.View
{
    /// <summary>
    /// Логика взаимодействия для AddTovarWindow.xaml
    /// </summary>
    public partial class AddTovarWindow : Window
    {
        private string _imagePath;
        private Product _productToEdit;
        private bool _isEditMode;
        

        public AddTovarWindow(Product productToEdit = null)
        {
            InitializeComponent();
            LoadCategories();
            if (productToEdit != null)
            {
                _productToEdit = productToEdit;
                _isEditMode = true;
                NameTextBox.Text = productToEdit.Name;
                PriceTextBox.Text = productToEdit.Price.ToString();
                DescriptionTextBox.Text = productToEdit.Descriprion;
                CategoryComboBox.SelectedValue = productToEdit.IdCategory;


                _imagePath = productToEdit.Foto; 

               
                if (!string.IsNullOrEmpty(_imagePath))
                {
                    DressImage.Source = new BitmapImage(new Uri(_imagePath, UriKind.RelativeOrAbsolute));
                }
            }
            if (productToEdit != null)
            {
                
                this.Title = "Редактирование записи";
             
            }
            else
            {
              
                this.Title = "Добавление записи";
            }

        }
        private void LoadCategories()
        {
            
            
                CategoryComboBox.ItemsSource = SalonBDEntities.GetContext().Category.ToList();
            
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(DescriptionTextBox.Text) ||
                string.IsNullOrWhiteSpace(PriceTextBox.Text) ||

                CategoryComboBox.SelectedItem == null ||
                (_isEditMode && string.IsNullOrWhiteSpace(_imagePath))) 
            {
                MessageBox.Show("Все поля должны быть заполнены, включая выбор изображение.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

         
            if (!decimal.TryParse(PriceTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price) || HasMoreThanTwoDecimalPlaces(price))
            {
                MessageBox.Show("Введите корректную цену с не более чем двумя десятичными знаками.");
                return;
            }
            

            var product = _isEditMode ? _productToEdit : new Product();

            product.Name = NameTextBox.Text;
            product.Price = price;
            product.Foto = _imagePath; 
            product.Descriprion = DescriptionTextBox.Text;
            product.IdCategory = (int)CategoryComboBox.SelectedValue;

            try
            {
               
                    if (_isEditMode)
                    {
                        SalonBDEntities.GetContext().Entry(product).State = EntityState.Modified;
                    }
                    else
                    {
                    SalonBDEntities.GetContext().Product.Add(product);
                    }
                SalonBDEntities.GetContext().SaveChanges();
                

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при сохранении продукта: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool HasMoreThanTwoDecimalPlaces(decimal dec)
        {
            decimal value = Math.Round(dec * 100);
            return value != dec * 100;
        }

        private void UploadFoto_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void AddPhotoButton_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == true)
            {
                _imagePath = openFileDialog.FileName;
           
                DressImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text) || (e.Text == "." && ((TextBox)sender).Text.Contains("."));
        }

        private void PriceTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                var text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
        private bool IsTextAllowed(string text)
        {
            Regex regex = new Regex(@"[^0-9.]+");
            return !regex.IsMatch(text) && !(text.Contains(".") && PriceTextBox.Text.Contains("."));
        }
    }
    
    
}
