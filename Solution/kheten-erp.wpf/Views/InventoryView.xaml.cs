using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using kheten_erp.wpf.Models;

namespace kheten_erp.wpf.Views
{
    public partial class InventoryView : UserControl
    {
        // Canlı koleksiyon: ekleme/düzenleme/silme tabloya anında yansır.
        private readonly ObservableCollection<ProductItem> _products;

        public InventoryView()
        {
            InitializeComponent();

            _products = new ObservableCollection<ProductItem>();
            foreach (var p in SampleData.Products)
            {
                var item = new ProductItem
                {
                    Code = p.Code,
                    Name = p.Name,
                    Category = p.Category,
                    Unit = p.Unit,
                    Price = p.Price,
                    Stock = p.Stock,   // Stock setter durumu otomatik hesaplar
                };
                _products.Add(item);
            }

            DataContext = new { Products = _products };
        }

        // ===== EKLE =====
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ProductEditWindow { Owner = Window.GetWindow(this) };
            if (dlg.ShowDialog() == true)
                _products.Add(dlg.Result);
        }

        // ===== DÜZENLE =====
        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (((FrameworkElement)sender).DataContext is not ProductItem row) return;

            var dlg = new ProductEditWindow(row) { Owner = Window.GetWindow(this) };
            if (dlg.ShowDialog() == true)
                row.CopyFrom(dlg.Result);   // düzenlemeyi orijinal satıra uygula
        }

        // ===== SİL =====
        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (((FrameworkElement)sender).DataContext is not ProductItem row) return;

            var answer = MessageBox.Show(
                $"\"{row.Name}\" ürününü silmek istediğinize emin misiniz?",
                "Ürünü Sil", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (answer == MessageBoxResult.Yes)
                _products.Remove(row);
        }
    }
}
