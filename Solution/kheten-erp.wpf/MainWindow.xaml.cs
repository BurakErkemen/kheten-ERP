using System.Windows;
using System.Windows.Controls.Primitives;
using kheten_erp.wpf.Models;
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
            else if (sender == NavEcom)       MainContent.Content = new EcommerceView();
            else if (sender == NavContacts)   MainContent.Content = new ContactsView();
            else if (sender == NavSettings)   MainContent.Content = new SettingsView();
        }

        // ===== ÜST BAR: YENİ KAYIT MENÜSÜ =====
        private void NewRecord_Click(object sender, RoutedEventArgs e)
        {
            if (NewRecordBtn.ContextMenu is null) return;
            NewRecordBtn.ContextMenu.PlacementTarget = NewRecordBtn;
            NewRecordBtn.ContextMenu.Placement = PlacementMode.Bottom;
            NewRecordBtn.ContextMenu.IsOpen = true;
        }

        private void NewProduct_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ProductEditWindow { Owner = this };
            if (dlg.ShowDialog() == true) DataStore.Current.Products.Add(dlg.Result);
        }

        private void NewContact_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ContactEditWindow { Owner = this };
            if (dlg.ShowDialog() == true) DataStore.Current.Contacts.Add(dlg.Result);
        }

        private void NewSale_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SalesEditWindow { Owner = this };
            if (dlg.ShowDialog() == true) DataStore.Current.Sales.Insert(0, dlg.Result);
        }

        private void NewPurchase_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new PurchaseEditWindow { Owner = this };
            if (dlg.ShowDialog() == true) DataStore.Current.Purchases.Insert(0, dlg.Result);
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
