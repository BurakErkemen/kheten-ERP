using System.Windows.Controls;
using System.Windows.Data;
using kheten_erp.wpf.Models;

namespace kheten_erp.wpf.Views
{
    public partial class EcommerceView : UserControl
    {
        public EcommerceView()
        {
            InitializeComponent();

            DataContext = new
            {
                Orders = DataStore.Current.EcomOrders,
                Channels = DataStore.Current.Channels,
            };

            // Kritik stok: durumu uyarı/tükendi olan ürünler (paylaşılan listeden filtrelenir)
            var critical = new CollectionViewSource { Source = DataStore.Current.Products }.View;
            critical.Filter = o => o is ProductItem p && (p.StatusKind == "warn" || p.StatusKind == "err");
            CriticalGrid.ItemsSource = critical;

            CriticalCount.Text = DataStore.Current.Products
                .Count(p => p.StatusKind == "warn" || p.StatusKind == "err").ToString();
        }
    }
}
