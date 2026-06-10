using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using kheten_erp.wpf.Models;

namespace kheten_erp.wpf.Views
{
    public partial class InventoryView : UserControl
    {
        private readonly System.ComponentModel.ICollectionView _view;

        public InventoryView()
        {
            InitializeComponent();

            // Kendi bağımsız görünümümüz (paylaşılan koleksiyonu bozmadan filtreleriz)
            _view = new CollectionViewSource { Source = DataStore.Current.Products }.View;
            _view.Filter = MatchesFilter;
            Grid.ItemsSource = _view;

            DataStore.Current.Products.CollectionChanged += (_, _) => UpdateSummary();
            UpdateSummary();
        }

        private bool MatchesFilter(object obj)
        {
            if (obj is not ProductItem p) return false;

            // Arama
            var q = SearchBox?.Text?.Trim() ?? "";
            if (q.Length > 0 &&
                !(p.Name.Contains(q, System.StringComparison.OrdinalIgnoreCase) ||
                  p.Code.Contains(q, System.StringComparison.OrdinalIgnoreCase)))
                return false;

            // Kategori
            var cat = CategoryFilter?.SelectedItem as string;
            if (!string.IsNullOrEmpty(cat) && cat != "Kategori: Tümü" && p.Category != cat)
                return false;

            return true;
        }

        private void Filter_Changed(object sender, RoutedEventArgs e)
        {
            _view?.Refresh();
            UpdateResultCount();
        }

        private void UpdateResultCount()
        {
            if (_view is null) return;
            var shown = _view.Cast<object>().Count();
            var total = DataStore.Current.Products.Count;
            ResultCount.Text = shown == total ? $"{total} ürün" : $"{shown} / {total} ürün";
        }

        private void UpdateSummary()
        {
            var all = DataStore.Current.Products;
            TotalText.Text = all.Count.ToString();
            CriticalText.Text = all.Count(p => p.StatusKind == "warn").ToString();
            OutText.Text = all.Count(p => p.StatusKind == "err").ToString();
            UpdateResultCount();
        }

        // ===== EKLE =====
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ProductEditWindow { Owner = Window.GetWindow(this) };
            if (dlg.ShowDialog() == true)
                DataStore.Current.Products.Add(dlg.Result);
        }

        // ===== DÜZENLE =====
        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (((FrameworkElement)sender).DataContext is not ProductItem row) return;

            var dlg = new ProductEditWindow(row) { Owner = Window.GetWindow(this) };
            if (dlg.ShowDialog() == true)
            {
                row.CopyFrom(dlg.Result);
                _view.Refresh();
                UpdateSummary();
            }
        }

        // ===== SİL =====
        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (((FrameworkElement)sender).DataContext is not ProductItem row) return;

            var answer = MessageBox.Show(
                $"\"{row.Name}\" ürününü silmek istediğinize emin misiniz?",
                "Ürünü Sil", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (answer == MessageBoxResult.Yes)
                DataStore.Current.Products.Remove(row);
        }
    }
}
