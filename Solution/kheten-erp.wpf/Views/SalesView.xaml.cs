using System.Windows.Controls;
using kheten_erp.wpf.Models;

namespace kheten_erp.wpf.Views
{
    public partial class SalesView : UserControl
    {
        public SalesView()
        {
            InitializeComponent();
            DataContext = new { Sales = SampleData.Sales };
        }
    }
}
