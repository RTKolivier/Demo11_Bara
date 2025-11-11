using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Barashikhina_Sofia
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void Next_Onclick(object? sender, RoutedEventArgs e)
        {
            ListProduct listProduct = new ListProduct();
            listProduct.Show();
            Close();

        }

        private void Admin_OnClick(object? sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            Close ();
        }
    }
}