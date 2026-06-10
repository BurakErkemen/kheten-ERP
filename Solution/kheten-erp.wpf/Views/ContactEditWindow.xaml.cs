using System.Windows;
using kheten_erp.wpf.Models;

namespace kheten_erp.wpf.Views
{
    public partial class ContactEditWindow : Window
    {
        public ContactItem Result { get; }

        public ContactEditWindow(ContactItem? existing = null)
        {
            InitializeComponent();

            if (existing is null)
            {
                Result = new ContactItem { Code = DataStore.Current.NextContactCode() };
                HeaderTitle.Text = "Yeni Cari";
            }
            else
            {
                Result = existing.Clone();
                HeaderTitle.Text = "Cariyi Düzenle";
            }

            DataContext = Result;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Result.Name))
            {
                MessageBox.Show("Lütfen ünvanı girin.", "Eksik bilgi",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}
