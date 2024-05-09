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
    /// Логика взаимодействия для ZakazWindow.xaml
    /// </summary>
    public partial class ZakazWindow : Window
    {
        public ZakazWindow()
        {
            InitializeComponent();
            DGrid.ItemsSource = SalonBDEntities.GetContext().Order.ToList();
        }

        private void DeletOrder_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrders = DGrid.SelectedItems.Cast<Order>().ToList();
            if (selectedOrders.Count == 0) return;

            if (MessageBox.Show($"Вы точно хотите удалить следующие {selectedOrders.Count()} элементов?", "Внимание", MessageBoxButton.YesNo,
                MessageBoxImage.Question) != MessageBoxResult.Yes)
            {
                return;
            }

            var context = SalonBDEntities.GetContext();
            try
            {
                foreach (var order in selectedOrders)
                {
                    var user = context.User.FirstOrDefault(u => u.Id == order.IdUser);
                    if (user != null)
                    {
                        context.User.Remove(user); 
                    }
                    context.Order.Remove(order);
                }
                context.SaveChanges();
                MessageBox.Show("Данные удалены!");
                DGrid.ItemsSource = context.Order.ToList(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}");
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       

        private void Description_Click_1(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
           
            Order selectedOrder = button.DataContext as Order;

            if (selectedOrder != null)
            {
                
                DetailsOrderWindow detailsOrderWindow = new DetailsOrderWindow();
             
                detailsOrderWindow.DataContext = selectedOrder;
                detailsOrderWindow.ShowDialog();
            }
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                FlowDocument doc = new FlowDocument();
                DataGrid dataGrid = DGrid;

                var selectedItems = dataGrid.SelectedItems;

                if (selectedItems.Count == 0) 
                {
                    using (var context = new SalonBDEntities())
                    {
                        var allOrder = context.Order.ToList();

                        foreach (var order in allOrder)
                        {
                            Paragraph paragraph = new Paragraph();
                            var orderInfo = order;

                            if (orderInfo != null)
                            {
                                paragraph.Inlines.Add(new Run("Название товара: " + orderInfo.Product.Name));
                                paragraph.Inlines.Add(new LineBreak());
                                paragraph.Inlines.Add(new Run("Имя заказчика: " + orderInfo.User.Name));
                                paragraph.Inlines.Add(new LineBreak());
                                paragraph.Inlines.Add(new Run("Фамилия заказчика: " + orderInfo.User.Surname));
                                paragraph.Inlines.Add(new LineBreak());
                                paragraph.Inlines.Add(new Run("Отчество заказчика: " + orderInfo.User.Patronymic));
                                paragraph.Inlines.Add(new LineBreak());
                                paragraph.Inlines.Add(new Run("Номер телефона: " + orderInfo.User.Phone));
                                paragraph.Inlines.Add(new LineBreak());
                                paragraph.Inlines.Add(new Run("Email: " + orderInfo.User.Email));
                                paragraph.Inlines.Add(new LineBreak());
                                paragraph.Inlines.Add(new Run("Обхват груди: " + orderInfo.Og));
                                paragraph.Inlines.Add(new LineBreak());
                                paragraph.Inlines.Add(new Run("Обхват талии: " + orderInfo.Ot));
                                paragraph.Inlines.Add(new LineBreak());
                                paragraph.Inlines.Add(new Run("Обхват бедер: " + orderInfo.Ob));
                            }


                            doc.Blocks.Add(paragraph);
                            doc.Blocks.Add(new BlockUIContainer(new Separator()));
                        }
                    }
                }
                else
                {
                    foreach (var selectedItem in selectedItems)
                    {
                        Paragraph paragraph = new Paragraph();

                        var orderInfo = selectedItem as Order;

                        if (orderInfo != null)
                        {
                            paragraph.Inlines.Add(new Run("Название товара: " + orderInfo.Product.Name));
                            paragraph.Inlines.Add(new LineBreak());
                            paragraph.Inlines.Add(new Run("Имя заказчика: " + orderInfo.User.Name));
                            paragraph.Inlines.Add(new LineBreak());
                            paragraph.Inlines.Add(new Run("Фамилия заказчика: " + orderInfo.User.Surname));
                            paragraph.Inlines.Add(new LineBreak());
                            paragraph.Inlines.Add(new Run("Отчество заказчика: " + orderInfo.User.Patronymic));
                            paragraph.Inlines.Add(new LineBreak());
                            paragraph.Inlines.Add(new Run("Номер телефона: " + orderInfo.User.Phone));
                            paragraph.Inlines.Add(new LineBreak());
                            paragraph.Inlines.Add(new Run("Email: " + orderInfo.User.Email));
                            paragraph.Inlines.Add(new LineBreak());
                            paragraph.Inlines.Add(new Run("Обхват груди: " + orderInfo.Og));
                            paragraph.Inlines.Add(new LineBreak());
                            paragraph.Inlines.Add(new Run("Обхват талии: " + orderInfo.Ot));
                            paragraph.Inlines.Add(new LineBreak());
                            paragraph.Inlines.Add(new Run("Обхват бедер: " + orderInfo.Ob));
                        }


                        doc.Blocks.Add(paragraph);
                        doc.Blocks.Add(new BlockUIContainer(new Separator()));
                    }
                }
                

                printDialog.PrintDocument(((IDocumentPaginatorSource)doc).DocumentPaginator, "Печать выделенных элементов или всех товаров");
            }
        }
    }
}
