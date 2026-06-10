using System.Windows.Controls;
using kheten_erp.wpf.Models;

namespace kheten_erp.wpf.Views
{
    public partial class ContactsView : UserControl
    {
        public ContactsView()
        {
            InitializeComponent();
            DataContext = new { Contacts = SampleData.Contacts };
        }
    }
}
