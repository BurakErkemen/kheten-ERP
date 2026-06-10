using System.Windows;
using System.Windows.Controls;
using kheten_erp.wpf.Models;

namespace kheten_erp.wpf.Views
{
    public partial class PurchasingView : UserControl
    {
        public PurchasingView()
        {
            InitializeComponent();
            Grid.ItemsSource = DataStore.Current.Purchases;
        }

        private void AddPurchase_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new PurchaseEditWindow { Owner = Window.GetWindow(this) };
            if (dlg.ShowDialog() == true)
                DataStore.Current.Purchases.Insert(0, dlg.Result);
        }

        private void EditPurchase_Click(object sender, RoutedEventArgs e)
        {
            if (((FrameworkElement)sender).DataContext is not PurchaseItem row) return;

            var dlg = new PurchaseEditWindow(row) { Owner = Window.GetWindow(this) };
            if (dlg.ShowDialog() == true)
                row.CopyFrom(dlg.Result);
        }

        private void DeletePurchase_Click(object sender, RoutedEventArgs e)
        {
            if (((FrameworkElement)sender).DataContext is not PurchaseItem row) return;

            var answer = MessageBox.Show(
                $"\"{row.No}\" belgesini silmek istediğinize emin misiniz?",
                "Belgeyi Sil", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (answer == MessageBoxResult.Yes)
                DataStore.Current.Purchases.Remove(row);
        }
    }
}
