
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
        Wv2.Source = e.Uri;
    }
    
    private void InitComboBox()
    {
        
        var poiNames = DbContext.GetAllPoiNames();
        Cobx.ItemsSource = poiNames;
        Cobx.IsEditable = true;
        Cobx.IsReadOnly = true;
        Cobx.Text = "-- Select Location --";
    }

    private void Cobx_OnSelected(object sender, RoutedEventArgs e)
    {
        Poi poi = DbContext.GetPoiByName(Cobx.SelectedValue.ToString());
        
        LblPoi.Content = poi.GetName();
        TxtBemerkung.Text = poi.GetBemerkung();
        LblLng.Content = poi.GetLaengengrad();
        LblLat.Content = poi.GetBreitengrad();
        HypLink.NavigateUri = new Uri(poi.GetLink());
        TxtLink.Text = poi.GetLink();
        
        Wv2.Source = new Uri($"https://www.openstreetmap.org/#map=18/{poi.GetBreitengrad()}/{poi.GetLaengengrad()}");
    }
}