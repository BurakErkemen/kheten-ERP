using System.Windows;
using kheten_erp.wpf.Models;

namespace kheten_erp.wpf.Views
{
    /// <summary>
    /// Ürün ekle/düzenle modal formu. Çalışma kopyası üzerinde düzenleme yapar;
    /// "Kaydet" denirse DialogResult=true döner ve Result düzenlenmiş ürünü verir.
    /// </summary>
    public partial class ProductEditWindow : Window
    {
        public ProductItem Result { get; }

        public ProductEditWindow(ProductItem? existing = null)
        {
            InitializeComponent();

            if (existing is null)
            {
                Result = new ProductItem();
                HeaderTitle.Text = "Yeni Ürün";
            }
            else
            {
                Result = existing.Clone();   // orijinali ancak Kaydet sonrası değiştiririz
                HeaderTitle.Text = "Ürünü Düzenle";
            }

            DataContext = Result;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Result.Name))
            {
                MessageBox.Show("Lütfen ürün adını girin.", "Eksik bilgi",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}
