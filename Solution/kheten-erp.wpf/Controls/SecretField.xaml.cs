using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace kheten_erp.wpf.Controls
{
    /// <summary>
    /// Etiketli kimlik/anahtar giriş alanı. Varsayılan olarak maskeli (parola gibi);
    /// göz simgesiyle açılıp gizlenebilir. Masked=False ise düz metin alanı gibi davranır
    /// (mağaza URL'si, satıcı ID gibi gizli olmayan değerler için).
    /// </summary>
    public partial class SecretField : UserControl
    {
        private bool _revealed;

        public SecretField()
        {
            InitializeComponent();
            UpdateVisibility();
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(string), typeof(SecretField),
                new PropertyMetadata("", OnLabelChanged));

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(string), typeof(SecretField),
                new PropertyMetadata("", OnValueChanged));

        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty MaskedProperty =
            DependencyProperty.Register(nameof(Masked), typeof(bool), typeof(SecretField),
                new PropertyMetadata(true, OnMaskedChanged));

        public bool Masked
        {
            get => (bool)GetValue(MaskedProperty);
            set => SetValue(MaskedProperty, value);
        }

        private static void OnLabelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => ((SecretField)d).LabelText.Text = (string)e.NewValue;

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var f = (SecretField)d;
            var v = (string)e.NewValue ?? "";
            f.Txt.Text = v;
            f.Pwd.Password = v;
        }

        private static void OnMaskedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => ((SecretField)d).UpdateVisibility();

        private void Reveal_Click(object sender, RoutedEventArgs e)
        {
            // Görünür kutudaki güncel değeri diğerine taşı, sonra modu değiştir.
            if (_revealed) Pwd.Password = Txt.Text;
            else Txt.Text = Pwd.Password;

            _revealed = !_revealed;
            UpdateVisibility();
        }

        private void UpdateVisibility()
        {
            if (!Masked)
            {
                Txt.Visibility = Visibility.Visible;
                Pwd.Visibility = Visibility.Collapsed;
                RevealBtn.Visibility = Visibility.Collapsed;
                return;
            }

            RevealBtn.Visibility = Visibility.Visible;
            Txt.Visibility = _revealed ? Visibility.Visible : Visibility.Collapsed;
            Pwd.Visibility = _revealed ? Visibility.Collapsed : Visibility.Visible;
            RevealIcon.Data = (Geometry)Application.Current.Resources[_revealed ? "Icon.EyeOff" : "Icon.Eye"];
        }
    }
}
