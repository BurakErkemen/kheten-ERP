using System.Windows;
using System.Windows.Controls;
using kheten_erp.wpf.Services;

namespace kheten_erp.wpf.Views.Settings
{
    public partial class GeneralSettingsView : UserControl
    {
        public GeneralSettingsView()
        {
            InitializeComponent();
            // Mevcut temayı seçili göster
            if (ThemeManager.Current == AppTheme.Dark) DarkOpt.IsChecked = true;
            else LightOpt.IsChecked = true;
        }

        private void Light_Click(object sender, RoutedEventArgs e) => ThemeManager.Apply(AppTheme.Light);
        private void Dark_Click(object sender, RoutedEventArgs e) => ThemeManager.Apply(AppTheme.Dark);
    }
}
