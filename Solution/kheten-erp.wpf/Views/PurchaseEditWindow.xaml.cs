using System.Windows;
using kheten_erp.wpf.Models;

namespace kheten_erp.wpf.Views
{
    public partial class PurchaseEditWindow : Window
    {
        public PurchaseItem Result { get; }

        public PurchaseEditWindow(PurchaseItem? existing = null)
        {
            InitializeComponent();

            if (existing is null)
            {
                Result = new PurchaseItem
                {
                    No = DataStore.Current.NextPurchaseNo(),
                    Date = System.DateTime.Now.ToString("dd.MM.yyyy"),
                    Status = "Sipariş Verildi",
                };
                HeaderTitle.Text = "Yeni Satınalma Siparişi";
            }
            else
            {
                Result = existing.Clone();
                HeaderTitle.Text = "Siparişi Düzenle";
            }

            DataContext = Result;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Result.Supplier))
            {
                MessageBox.Show("Lütfen tedarikçi girin.", "Eksik bilgi",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}
