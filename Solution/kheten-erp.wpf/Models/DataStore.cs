using System.Collections.ObjectModel;

namespace kheten_erp.wpf.Models
{
    /// <summary>
    /// Oturum boyunca yaşayan tek merkezli veri deposu. Tüm ekranlar aynı
    /// koleksiyonlara bağlanır; bir yerde eklenen/silinen kayıt her yerde görünür.
    /// (Backend bağlandığında bu sınıf servis çağrılarıyla değiştirilecek.)
    /// </summary>
    public sealed class DataStore
    {
        public static DataStore Current { get; } = new();

        public ObservableCollection<ProductItem>  Products  { get; } = new();
        public ObservableCollection<ContactItem>  Contacts  { get; } = new();
        public ObservableCollection<SalesItem>    Sales     { get; } = new();
        public ObservableCollection<PurchaseItem> Purchases { get; } = new();
        public ObservableCollection<EcomOrder>    EcomOrders { get; } = new();
        public ObservableCollection<ChannelProfit> Channels { get; } = new();

        private DataStore()
        {
            foreach (var p in SampleData.Products)
                Products.Add(new ProductItem
                {
                    Code = p.Code, Name = p.Name, Category = p.Category,
                    Unit = p.Unit, Price = p.Price, Stock = p.Stock,
                });

            foreach (var c in SampleData.Contacts)
                Contacts.Add(new ContactItem
                {
                    Code = c.Code, Name = c.Name, Type = c.Type, Phone = c.Phone, Balance = c.Balance,
                });

            foreach (var s in SampleData.Sales)
                Sales.Add(new SalesItem
                {
                    No = s.No, Customer = s.Customer, Date = s.Date, Amount = s.Amount, Status = s.Status,
                });

            foreach (var p in SampleData.Purchases)
                Purchases.Add(new PurchaseItem
                {
                    No = p.No, Supplier = p.Supplier, Date = p.Date, Amount = p.Amount, Status = p.Status,
                });

            foreach (var o in SampleData.EcomOrders) EcomOrders.Add(o);
            foreach (var ch in SampleData.Channels)  Channels.Add(ch);
        }

        /// <summary>Yeni belge numarası üretir (örn. SF-2026-0419).</summary>
        public string NextSalesNo()    => $"SF-2026-{(419 + Sales.Count):0000}";
        public string NextPurchaseNo() => $"AF-2026-{(193 + Purchases.Count):0000}";
        public string NextContactCode() => $"CR-{(Contacts.Count + 1):000}";
    }
}
