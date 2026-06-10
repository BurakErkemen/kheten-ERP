using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using kheten_erp.wpf.Models;

namespace kheten_erp.wpf.Views
{
    public partial class ContactsView : UserControl
    {
        private readonly System.ComponentModel.ICollectionView _view;

        public ContactsView()
        {
            InitializeComponent();

            _view = new CollectionViewSource { Source = DataStore.Current.Contacts }.View;
            _view.Filter = MatchesFilter;
            Grid.ItemsSource = _view;

            DataStore.Current.Contacts.CollectionChanged += (_, _) => UpdateResultCount();
            UpdateResultCount();
        }

        private bool MatchesFilter(object obj)
        {
            if (obj is not ContactItem c) return false;

            var q = SearchBox?.Text?.Trim() ?? "";
            if (q.Length > 0 &&
                !(c.Name.Contains(q, System.StringComparison.OrdinalIgnoreCase) ||
                  c.Code.Contains(q, System.StringComparison.OrdinalIgnoreCase)))
                return false;

            var type = TypeFilter?.SelectedItem as string;
            if (!string.IsNullOrEmpty(type) && type != "Tip: Tümü" && c.Type != type)
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
            var total = DataStore.Current.Contacts.Count;
            ResultCount.Text = shown == total ? $"{total} cari" : $"{shown} / {total} cari";
        }

        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ContactEditWindow { Owner = Window.GetWindow(this) };
            if (dlg.ShowDialog() == true)
                DataStore.Current.Contacts.Add(dlg.Result);
        }

        private void EditContact_Click(object sender, RoutedEventArgs e)
        {
            if (((FrameworkElement)sender).DataContext is not ContactItem row) return;

            var dlg = new ContactEditWindow(row) { Owner = Window.GetWindow(this) };
            if (dlg.ShowDialog() == true)
            {
                row.CopyFrom(dlg.Result);
                _view.Refresh();
            }
        }

        private void DeleteContact_Click(object sender, RoutedEventArgs e)
        {
            if (((FrameworkElement)sender).DataContext is not ContactItem row) return;

            var answer = MessageBox.Show(
                $"\"{row.Name}\" carisini silmek istediğinize emin misiniz?",
                "Cariyi Sil", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (answer == MessageBoxResult.Yes)
                DataStore.Current.Contacts.Remove(row);
        }
    }
}
