using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace kheten_erp.wpf.Models
{
    /// <summary>Satış faturası satırı. Durum metnine göre rozet rengi (StatusKind) türetilir.</summary>
    public class SalesItem : INotifyPropertyChanged
    {
        private string _no = "";
        private string _customer = "";
        private string _date = "";
        private string _amount = "₺ 0";
        private string _status = "Taslak";
        private string _statusKind = "info";

        public string No       { get => _no;       set { _no = value;       OnChanged(); } }
        public string Customer { get => _customer; set { _customer = value; OnChanged(); } }
        public string Date     { get => _date;     set { _date = value;     OnChanged(); } }
        public string Amount   { get => _amount;   set { _amount = value;   OnChanged(); } }

        public string Status
        {
            get => _status;
            set { _status = value; OnChanged(); RecalcKind(); }
        }

        public string StatusKind { get => _statusKind; private set { _statusKind = value; OnChanged(); } }

        private void RecalcKind() => StatusKind = _status switch
        {
            "Ödendi"   => "ok",
            "Bekliyor" => "warn",
            "Gecikti"  => "err",
            _          => "info",   // Taslak
        };

        public SalesItem Clone() => (SalesItem)MemberwiseClone();
        public void CopyFrom(SalesItem o)
        {
            No = o.No; Customer = o.Customer; Date = o.Date; Amount = o.Amount; Status = o.Status;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnChanged([CallerMemberName] string? n = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }
}
