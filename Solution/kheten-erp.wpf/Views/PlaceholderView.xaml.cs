using System.Windows.Controls;

namespace kheten_erp.wpf.Views
{
    public partial class PlaceholderView : UserControl
    {
        public PlaceholderView()
        {
            InitializeComponent();
        }

        public PlaceholderView(string title) : this()
        {
            TitleText.Text = title;
        }
    }
}
