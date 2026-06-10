using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using kheten_erp.wpf.Models;

namespace kheten_erp.wpf.Views
{
    public partial class SalesView : UserControl
    {
        private readonly System.ComponentModel.ICollectionView _view;

        public SalesView()
        {
            InitializeComponent();

            _view = new CollectionViewSource { Source = DataStore.Current.Sales }.View;
            _view.Filter = MatchesFilter;
            Grid.ItemsSource = _view;

            DataStore.Current.Sales.CollectionChanged += (_, _) => UpdateResultCount();
            UpdateResultCount();
        }

        private string CurrentStatus()
        {
            if (TabPaid.IsChecked == true)    return "Ödendi";
            if (TabPending.IsChecked == true) return "Bekliyor";
            if (TabLate.IsChecked == true)    return "Gecikti";
            return "";   // Tümü
        }

        private bool MatchesFilter(object obj)
        {
            if (obj is not SalesItem s) return false;
            var status = CurrentStatus();
            return status.Length == 0 || s.Status == status;
        }

        private void Tab_Checked(object sender, RoutedEventArgs e)
        {
            _view?.Refresh();
            UpdateResultCount();
        }

        private void UpdateResultCount()
        {
            if (_view is null) return;
            var shown = _view.Cast<object>().Count();
            ResultCount.Text = $"{shown} fatura";
        }

        private void AddSale_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SalesEditWindow { Owner = Window.GetWindow(this) };
            if (dlg.ShowDialog() == true)
                DataStore.Current.Sales.Insert(0, dlg.Result);
        }

        private void EditSale_Click(object sender, RoutedEventArgs e)
        {
            if (((FrameworkElement)sender).DataContext is not SalesItem row) return;

            var dlg = new SalesEditWindow(row) { Owner = Window.GetWindow(this) };
            if (dlg.ShowDialog() == true)
            {
                row.CopyFrom(dlg.Result);
                _view.Refresh();
                UpdateResultCount();
            }
        }

        private void DeleteSale_Click(object sender, RoutedEventArgs e)
        {
            if (((FrameworkElement)sender).DataContext is not SalesItem row) return;

            var answer = MessageBox.Show(
                $"\"{row.No}\" faturasını silmek istediğinize emin misiniz?",
                "Faturayı Sil", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (answer == MessageBoxResult.Yes)
                DataStore.Current.Sales.Remove(row);
        }
    }
}
