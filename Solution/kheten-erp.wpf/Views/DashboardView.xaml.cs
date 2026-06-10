using System.Windows.Controls;
using kheten_erp.wpf.Models;

namespace kheten_erp.wpf.Views
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
            DataContext = new
            {
                LowStock = SampleData.LowStock,
                TopProducts = SampleData.TopProducts,
            };
        }
    }
}
