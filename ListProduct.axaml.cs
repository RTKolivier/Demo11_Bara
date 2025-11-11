using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Runtime.ConstrainedExecution;

namespace Barashikhina_Sofia;

public partial class ListProduct : Window
{
    public ListProduct()
    {
        InitializeComponent();
    }

    private void Create_OnClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        CreateOrder createOrder = new CreateOrder();
        createOrder.Show();
        Close();
    }
}