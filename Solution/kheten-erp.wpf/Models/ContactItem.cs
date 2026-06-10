using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace kheten_erp.wpf.Models
{
    /// <summary>Cari hesap satırı (müşteri/tedarikçi). Bakiye işaretine göre renk türetilir.</summary>
    public class ContactItem : INotifyPropertyChanged
    {
        private string _code = "";
        private string _name = "";
        private string _type = "Müşteri";
        private string _phone = "";
        private string _balance = "₺ 0";
        private string _balanceKind = "ok";

        public string Code  { get => _code;  set { _code = value;  OnChanged(); } }
        public string Name  { get => _name;  set { _name = value;  OnChanged(); } }
        public string Type  { get => _type;  set { _type = value;  OnChanged(); } }
        public string Phone { get => _phone; set { _phone = value; OnChanged(); } }

        public string Balance
        {
            get => _balance;
            set { _balance = value; OnChanged(); RecalcKind(); }
        }

        public string BalanceKind { get => _balanceKind; private set { _balanceKind = value; OnChanged(); } }

        private void RecalcKind()
        {
            var b = _balance ?? "";
            if (b.Contains('-'))                 BalanceKind = "err";   // borçluyuz (tedarikçi)
            else if (b.Replace("₺", "").Replace(" ", "").Trim() is "0" or "0,00")
                                                 BalanceKind = "ok";    // bakiye sıfır
            else                                 BalanceKind = "warn";  // alacaklıyız (müşteri)
        }

        public ContactItem Clone() => (ContactItem)MemberwiseClone();
        public void CopyFrom(ContactItem o)
        {
            Code = o.Code; Name = o.Name; Type = o.Type; Phone = o.Phone; Balance = o.Balance;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnChanged([CallerMemberName] string? n = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }
}
