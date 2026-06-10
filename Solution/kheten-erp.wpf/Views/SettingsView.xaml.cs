using System.Windows;
using System.Windows.Controls;
using kheten_erp.wpf.Views.Settings;

namespace kheten_erp.wpf.Views
{
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            SectionContent.Content = new GeneralSettingsView();
        }

        private void Sec_Checked(object sender, RoutedEventArgs e)
        {
            if (SectionContent is null) return;

            if (sender == SecGeneral)            SectionContent.Content = new GeneralSettingsView();
            else if (sender == SecCompany)       SectionContent.Content = new CompanySettingsView();
            else if (sender == SecIntegrations)  SectionContent.Content = new IntegrationsSettingsView();
            else if (sender == SecNotifications) SectionContent.Content = new NotificationsSettingsView();
        }
    }
}
