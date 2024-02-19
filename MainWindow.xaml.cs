
using System.Globalization;
using System.Windows;
using System.Windows.Navigation;


namespace Wpf_PointOfInterest_2024_02_15;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string _conn =  App.ConnectionString;
    
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
        IAccessible dal = new SQLiteDal(_conn);
        var poiNames = dal.GetAllPoiNames();
        Cobx.ItemsSource = poiNames;
        Cobx.IsEditable = true;
        Cobx.IsReadOnly = true;
        Cobx.Text = "-- Select Location --";
    }

    private void Cobx_OnSelected(object sender, RoutedEventArgs e)
    {
        SQLiteDal dal = new SQLiteDal(_conn);
        Poi poi = dal.GetPoiByName(Cobx.SelectedValue.ToString()!);
        
        LblPoi.Content = poi.GetName();
        TxtBemerkung.Text = poi.GetBemerkung();
        LblLng.Content = poi.GetLaengengrad();
        LblLat.Content = poi.GetBreitengrad();
        HypLink.NavigateUri = new Uri(poi.GetLink());
        TxtLink.Text = poi.GetLink();
        
        //Wv2.Source = new Uri($"https://www.openstreetmap.org/#map=18/{poi.GetBreitengrad()}/{poi.GetLaengengrad()}");
        
        
        string HtmlCode = @$"
                            <!DOCTYPE html>
                                <html lang=""de"">
                                    <head>
                                        <meta charset=""UTF-8"">
                                        <meta name=""viewport"" content=""width=device-width,initial-scale=1"">
                                        <title></title>
                                    </head>
                                    <body>
                                        <div style=""width: 100%"">
                                            <iframe width=""100%"" height=""{(wvMap.ActualHeight - 20).ToString()}"" 
                                                frameborder=""0"" scrolling=""no"" marginheight=""0"" marginwidth=""0"" 
                                                src=""https://maps.google.com/maps?width=100%25&height={(wvMap.ActualHeight - 20).ToString()}&hl=de&q={poi.GetBreitengrad().ToString(CultureInfo.InvariantCulture)},{poi.GetLaengengrad().ToString(CultureInfo.InvariantCulture)}&t=k&z=17&ie=UTF8&iwloc=B&output=embed"" />
                                        </div>
                                    </body>
                                </html>";

        Wv2.NavigateToString(HtmlCode);
    }
}