using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace kheten_erp.wpf.Controls
{
    /// <summary>
    /// Bir e-ticaret/pazaryeri entegrasyonu kartı. Başlık, durum rozeti, etkinleştirme
    /// anahtarı ve Test/Kaydet butonlarını ortak sağlar; kimlik/anahtar alanları
    /// (Fields) tüketici tarafından doldurulur.
    /// </summary>
    [ContentProperty(nameof(Fields))]
    public partial class IntegrationCard : UserControl
    {
        public IntegrationCard()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty StoreNameProperty =
            DependencyProperty.Register(nameof(StoreName), typeof(string), typeof(IntegrationCard), new PropertyMetadata(""));
        public string StoreName { get => (string)GetValue(StoreNameProperty); set => SetValue(StoreNameProperty, value); }

        public static readonly DependencyProperty InitialProperty =
            DependencyProperty.Register(nameof(Initial), typeof(string), typeof(IntegrationCard), new PropertyMetadata(""));
        public string Initial { get => (string)GetValue(InitialProperty); set => SetValue(InitialProperty, value); }

        public static readonly DependencyProperty BrandColorProperty =
            DependencyProperty.Register(nameof(BrandColor), typeof(Brush), typeof(IntegrationCard),
                new PropertyMetadata(Brushes.SlateGray));
        public Brush BrandColor { get => (Brush)GetValue(BrandColorProperty); set => SetValue(BrandColorProperty, value); }

        public static readonly DependencyProperty IsConnectedProperty =
            DependencyProperty.Register(nameof(IsConnected), typeof(bool), typeof(IntegrationCard), new PropertyMetadata(false));
        public bool IsConnected { get => (bool)GetValue(IsConnectedProperty); set => SetValue(IsConnectedProperty, value); }

        public static readonly DependencyProperty FieldsProperty =
            DependencyProperty.Register(nameof(Fields), typeof(object), typeof(IntegrationCard), new PropertyMetadata(null));
        public object Fields { get => GetValue(FieldsProperty); set => SetValue(FieldsProperty, value); }

        private void Test_Click(object sender, RoutedEventArgs e)
            => MessageBox.Show($"{StoreName} bağlantısı test ediliyor...\n(Demo — gerçek API çağrısı henüz bağlanmadı.)",
                "Bağlantı Testi", MessageBoxButton.OK, MessageBoxImage.Information);

        private void Save_Click(object sender, RoutedEventArgs e)
            => MessageBox.Show($"{StoreName} ayarları kaydedildi.\n(Demo — kalıcı kayıt için backend bağlanacak.)",
                "Kaydedildi", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
