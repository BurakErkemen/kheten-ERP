using System.Windows;
using kheten_erp.wpf.Services;
using kheten_erp.wpf.Views;

namespace kheten_erp.wpf
{
    /// <summary>
    /// Uygulama kabuğu: sol menü navigasyonu + tema değiştirme.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Başlangıç görünümü
            MainContent.Content = new DashboardView();
        }

        private void Nav_Checked(object sender, RoutedEventArgs e)
        {
            // Pencere kurulurken (IsChecked="True") MainContent henüz oluşmamış olabilir.
            if (MainContent is null) return;

            if (sender == NavDashboard)       MainContent.Content = new DashboardView();
            else if (sender == NavInventory)  MainContent.Content = new InventoryView();
            else if (sender == NavSales)      MainContent.Content = new SalesView();
            else if (sender == NavPurchasing) MainContent.Content = new PurchasingView();
            else if (sender == NavContacts)   MainContent.Content = new ContactsView();
            else if (sender == NavSettings)   MainContent.Content = new PlaceholderView("Ayarlar");
        }

        private void ThemeToggle_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.Toggle();
            // Koyu temadaysak güneş (açığa dön), açık temadaysak ay simgesi göster.
            var key = theme == AppTheme.Dark ? "Icon.Sun" : "Icon.Moon";
            ThemeIcon.Data = (System.Windows.Media.Geometry)Application.Current.Resources[key];
        }
    }
}
