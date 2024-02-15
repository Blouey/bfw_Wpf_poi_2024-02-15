
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace Wpf_PointOfInterest_2024_02_15;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        InitComboBox();
        Wv2.EnsureCoreWebView2Async(null);
        
    }

    private void HypLink_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        DbContext dbContext = new DbContext();
        dbContext.ConsoleAllPoi();
    }
    
    private void InitComboBox()
    {
        DbContext dbContext = new DbContext();
        var poiNames = dbContext.GetAllPoiNames();
        Cobx.ItemsSource = poiNames;
        Cobx.IsEditable = true;
        Cobx.IsReadOnly = true;
        Cobx.Text = "-- Select Location --";
    }
}