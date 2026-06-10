using System.Windows.Controls;
using kheten_erp.wpf.Models;

namespace kheten_erp.wpf.Views
{
    public partial class PurchasingView : UserControl
    {
        public PurchasingView()
        {
            InitializeComponent();
            DataContext = new { Purchases = SampleData.Purchases };
        }
    }
}
