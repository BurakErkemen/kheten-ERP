using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace kheten_erp.wpf.Models
{
    /// <summary>
    /// Stok ekranında listelenen, formla düzenlenebilen ürün satırı.
    /// INotifyPropertyChanged sayesinde düzenleme tabloya anında yansır.
    /// Durum (StatusKind) stok metnine göre otomatik türetilir.
    /// </summary>
    public class ProductItem : INotifyPropertyChanged
    {
        private string _code = "";
        private string _name = "";
        private string _category = "Genel";
        private string _unit = "Adet";
        private string _stock = "0";
        private string _price = "₺ 0";
        private string _status = "Stokta";
        private string _statusKind = "ok";

        public string Code   { get => _code;   set { _code = value;   OnChanged(); } }
        public string Name   { get => _name;   set { _name = value;   OnChanged(); } }
        public string Category { get => _category; set { _category = value; OnChanged(); } }
        public string Unit   { get => _unit;   set { _unit = value;   OnChanged(); } }
        public string Price  { get => _price;  set { _price = value;  OnChanged(); } }

        public string Stock
        {
            get => _stock;
            set { _stock = value; OnChanged(); RecalcStatus(); }
        }

        public string Status     { get => _status;     private set { _status = value;     OnChanged(); } }
        public string StatusKind { get => _statusKind; private set { _statusKind = value; OnChanged(); } }

        /// <summary>Stok adedine göre durumu yeniden hesaplar (0 → Tükendi, ≤20 → Kritik, üzeri → Stokta).</summary>
        private void RecalcStatus()
        {
            var n = ParseStock(_stock);
            if (n <= 0)        { Status = "Tükendi"; StatusKind = "err"; }
            else if (n <= 20)  { Status = "Kritik";  StatusKind = "warn"; }
            else               { Status = "Stokta";  StatusKind = "ok"; }
        }

        private static int ParseStock(string s)
        {
            // "1.250" gibi binlik ayraçlı değerleri de okuyabilmek için ayrac temizlenir.
            var cleaned = (s ?? "").Replace(".", "").Replace(" ", "").Trim();
            return int.TryParse(cleaned, out var v) ? v : 0;
        }

        public ProductItem Clone() => (ProductItem)MemberwiseClone();

        public void CopyFrom(ProductItem o)
        {
            Code = o.Code; Name = o.Name; Category = o.Category;
            Unit = o.Unit; Price = o.Price; Stock = o.Stock;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
