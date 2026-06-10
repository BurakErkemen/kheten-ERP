using System.Windows;

namespace kheten_erp.wpf.Services
{
    public enum AppTheme { Light, Dark }

    /// <summary>
    /// Açık/Koyu tema arasında geçiş yapar. Tema sözlüğü her zaman
    /// App.Resources.MergedDictionaries[0] konumundadır; sadece o değiştirilir,
    /// böylelikle Icons/Controls sözlükleri korunur.
    /// </summary>
    public static class ThemeManager
    {
        public static AppTheme Current { get; private set; } = AppTheme.Light;

        private const string LightUri = "Themes/LightTheme.xaml";
        private const string DarkUri = "Themes/DarkTheme.xaml";

        public static void Apply(AppTheme theme)
        {
            var dict = new ResourceDictionary
            {
                Source = new Uri(theme == AppTheme.Dark ? DarkUri : LightUri, UriKind.Relative)
            };

            // İlk slot tema renk sözlüğüne ayrılmıştır.
            Application.Current.Resources.MergedDictionaries[0] = dict;
            Current = theme;
        }

        public static AppTheme Toggle()
        {
            Apply(Current == AppTheme.Light ? AppTheme.Dark : AppTheme.Light);
            return Current;
        }
    }
}
