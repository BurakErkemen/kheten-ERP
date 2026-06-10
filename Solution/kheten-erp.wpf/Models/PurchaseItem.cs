using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace kheten_erp.wpf.Models
{
    /// <summary>Alış (satınalma) belgesi satırı.</summary>
    public class PurchaseItem : INotifyPropertyChanged
    {
        private string _no = "";
        private string _supplier = "";
        private string _date = "";
        private string _amount = "₺ 0";
        private string _status = "Sipariş Verildi";
        private string _statusKind = "info";

        public string No       { get => _no;       set { _no = value;       OnChanged(); } }
        public string Supplier { get => _supplier; set { _supplier = value; OnChanged(); } }
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
            "Onaylandı"       => "ok",
            "Teslim Bekliyor" => "warn",
            "İptal"           => "err",
            _                 => "info",   // Sipariş Verildi
        };

        public PurchaseItem Clone() => (PurchaseItem)MemberwiseClone();
        public void CopyFrom(PurchaseItem o)
        {
            No = o.No; Supplier = o.Supplier; Date = o.Date; Amount = o.Amount; Status = o.Status;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnChanged([CallerMemberName] string? n = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }
}
