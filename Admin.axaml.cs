using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Barashikhina_Sofia;

public partial class Admin : Window
{
    public Admin()
    {
        InitializeComponent();
    }

    private void NextSec_Onclick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ListProduct listProduct = new ListProduct();
        listProduct.Show();
        Close();
    }
}