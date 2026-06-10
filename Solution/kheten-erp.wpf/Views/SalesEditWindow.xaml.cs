using System.Windows;
using kheten_erp.wpf.Models;

namespace kheten_erp.wpf.Views
{
    public partial class SalesEditWindow : Window
    {
        public SalesItem Result { get; }

        public SalesEditWindow(SalesItem? existing = null)
        {
            InitializeComponent();

            if (existing is null)
            {
                Result = new SalesItem
                {
                    No = DataStore.Current.NextSalesNo(),
                    Date = System.DateTime.Now.ToString("dd.MM.yyyy"),
                    Status = "Taslak",
                };
                HeaderTitle.Text = "Yeni Satış Faturası";
            }
            else
            {
                Result = existing.Clone();
                HeaderTitle.Text = "Faturayı Düzenle";
            }

            DataContext = Result;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Result.Customer))
            {
                MessageBox.Show("Lütfen müşteri girin.", "Eksik bilgi",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}
