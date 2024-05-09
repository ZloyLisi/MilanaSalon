using MI2.Model;
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


namespace MI2.View
{
    /// <summary>
    /// Логика взаимодействия для OrdeWindow.xaml
    /// </summary>
    public partial class OrdeWindow : Window
    {
        private Product _selectedProduct;

        public OrdeWindow(Product selectedProduct)
        {
            InitializeComponent();
            _selectedProduct = selectedProduct;
            ProductNam.Content = selectedProduct.Name;
        }
        
        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(SurnameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PhoneTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                string.IsNullOrWhiteSpace(ChestTextBox.Text) ||
                string.IsNullOrWhiteSpace(WaistTextBox.Text) ||
                string.IsNullOrWhiteSpace(HipsTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

           
            var newUser = new User  
            {
                Name = NameTextBox.Text,
                Surname = SurnameTextBox.Text,
                Patronymic = PatronymicTextBox.Text,
                Phone = PhoneTextBox.Text,
                Email = EmailTextBox.Text,
                IdRole = 3 
            };

            var newOrder = new Order 
            {
                IdProduct = _selectedProduct.Id,
                Og = (ChestTextBox.Text),
                Ob = (WaistTextBox.Text),
                Ot = (HipsTextBox.Text)
               
            };

            
            using (var context = new SalonBDEntities()) 
            {
                context.User.Add(newUser);
                context.SaveChanges(); 

                newOrder.IdUser = newUser.Id; 
                context.Order.Add(newOrder);
                context.SaveChanges(); 
            }

            DialogResult = true; 
            Close();
        }

        private void ValidateNumberInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
           
            e.Handled = !IsValidNumberInput(textBox.Text, e.Text);
        }

        private void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                TextBox textBox = sender as TextBox;
                string pasteText = (string)e.DataObject.GetData(typeof(String));
              
                e.CancelCommand();
                if (IsValidNumberInput(textBox.Text, pasteText, true))
                {
                    textBox.Text = pasteText;
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                e.Handled = false;
            }
        }
        private bool IsValidNumberInput(string currentText, string newText, bool isPaste = false)
        {
           
            bool containsComma = currentText.Contains(',');

         
            if (newText.All(c => Char.IsDigit(c) || (c == ',' && !containsComma)))
            {
                
                if (newText.StartsWith(",") && currentText.Length == 0)
                    return false;
         
                if (isPaste && !double.TryParse(newText, out double _))
                    return false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
}
