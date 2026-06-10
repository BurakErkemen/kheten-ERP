using System.Collections.Generic;

namespace kheten_erp.wpf.Models
{
    // ===== Basit görüntüleme modelleri (UI demo verisi) =====

    public record LowStockItem(string Name, string Stock, string Min);
    public record TopProduct(string Name, string Qty, string Revenue);

    public record Product(string Code, string Name, string Category, string Unit,
                          string Stock, string Price, string Status, string StatusKind);

    public record SalesDoc(string No, string Customer, string Date, string Amount,
                           string Status, string StatusKind);

    public record PurchaseDoc(string No, string Supplier, string Date, string Amount,
                              string Status, string StatusKind);

    public record Contact(string Code, string Name, string Type, string Phone,
                          string Balance, string BalanceKind);

    /// <summary>
    /// Tüm ekranların kullandığı sabit demo verisi. Gerçek sistemde bu yerini
    /// veritabanı/servis katmanına bırakır.
    /// </summary>
    public static class SampleData
    {
        public static List<LowStockItem> LowStock { get; } = new()
        {
            new("Vida M6x40 Galvaniz", "18", "50"),
            new("Conta Seti 12'li", "9", "40"),
            new("Rulman 6204 ZZ", "23", "60"),
            new("Kayış A-32", "5", "25"),
            new("Filtre Hava HF-220", "31", "80"),
        };

        public static List<TopProduct> TopProducts { get; } = new()
        {
            new("Hidrolik Pompa HP-5", "142", "₺ 213.000"),
            new("Çelik Levha 2mm", "1.250", "₺ 187.500"),
            new("Elektrik Motoru 5.5kW", "64", "₺ 156.800"),
            new("Vana 2\" Pirinç", "320", "₺ 96.000"),
            new("Kablo NYY 3x2.5", "4.800", "₺ 72.000"),
        };

        public static List<Product> Products { get; } = new()
        {
            new("STK-1001", "Hidrolik Pompa HP-5", "Hidrolik", "Adet", "84",  "₺ 1.500", "Stokta",  "ok"),
            new("STK-1002", "Çelik Levha 2mm",     "Metal",    "m²",   "1.250","₺ 150",   "Stokta",  "ok"),
            new("STK-1003", "Vida M6x40 Galvaniz", "Bağlantı", "Adet", "18",   "₺ 2,40",  "Kritik",  "warn"),
            new("STK-1004", "Elektrik Motoru 5.5kW","Elektrik","Adet", "32",   "₺ 2.450", "Stokta",  "ok"),
            new("STK-1005", "Conta Seti 12'li",    "Yedek",    "Set",  "9",    "₺ 85",    "Kritik",  "warn"),
            new("STK-1006", "Vana 2\" Pirinç",      "Tesisat",  "Adet", "0",    "₺ 300",   "Tükendi", "err"),
            new("STK-1007", "Kablo NYY 3x2.5",     "Elektrik", "m",    "4.800","₺ 15",    "Stokta",  "ok"),
            new("STK-1008", "Rulman 6204 ZZ",      "Bağlantı", "Adet", "23",   "₺ 45",    "Kritik",  "warn"),
            new("STK-1009", "Filtre Hava HF-220",  "Yedek",    "Adet", "31",   "₺ 120",   "Stokta",  "ok"),
            new("STK-1010", "Kayış A-32",          "Yedek",    "Adet", "5",    "₺ 60",    "Kritik",  "warn"),
        };

        public static List<SalesDoc> Sales { get; } = new()
        {
            new("SF-2026-0418", "Mavi Tekstil A.Ş.",  "08.06.2026", "₺ 18.400", "Ödendi",   "ok"),
            new("SF-2026-0417", "Demir İnşaat Ltd.",  "07.06.2026", "₺ 42.150", "Bekliyor", "warn"),
            new("SF-2026-0416", "Yıldız Otomotiv",    "06.06.2026", "₺ 9.800",  "Ödendi",   "ok"),
            new("SF-2026-0415", "Anadolu Gıda",       "05.06.2026", "₺ 67.300", "Gecikti",  "err"),
            new("SF-2026-0414", "Bereket Market",     "04.06.2026", "₺ 5.250",  "Ödendi",   "ok"),
            new("SF-2026-0413", "Kaya Mühendislik",   "03.06.2026", "₺ 28.900", "Bekliyor", "warn"),
            new("SF-2026-0412", "Güneş Enerji A.Ş.",  "02.06.2026", "₺ 113.000","Ödendi",   "ok"),
            new("SF-2026-0411", "Toros Lojistik",     "01.06.2026", "₺ 7.600",  "Taslak",   "info"),
        };

        public static List<PurchaseDoc> Purchases { get; } = new()
        {
            new("AF-2026-0192", "Anadolu Metal San.", "08.06.2026", "₺ 32.000", "Onaylandı", "ok"),
            new("AF-2026-0191", "Ege Plastik",        "06.06.2026", "₺ 14.500", "Teslim Bekliyor", "warn"),
            new("AF-2026-0190", "Marmara Kimya",      "05.06.2026", "₺ 8.900",  "Onaylandı", "ok"),
            new("AF-2026-0189", "Star Elektrik",      "03.06.2026", "₺ 21.300", "Sipariş Verildi", "info"),
            new("AF-2026-0188", "Demirören Çelik",    "01.06.2026", "₺ 96.000", "Onaylandı", "ok"),
            new("AF-2026-0187", "Akın Rulman",        "29.05.2026", "₺ 4.750",  "İptal",     "err"),
        };

        public static List<Contact> Contacts { get; } = new()
        {
            new("CR-001", "Mavi Tekstil A.Ş.",   "Müşteri",   "0212 555 11 22", "₺ 0",        "ok"),
            new("CR-002", "Demir İnşaat Ltd.",   "Müşteri",   "0312 444 33 11", "₺ 42.150",   "warn"),
            new("CR-003", "Anadolu Metal San.",  "Tedarikçi", "0224 333 88 99", "-₺ 32.000",  "err"),
            new("CR-004", "Yıldız Otomotiv",     "Müşteri",   "0232 777 66 55", "₺ 0",        "ok"),
            new("CR-005", "Ege Plastik",         "Tedarikçi", "0232 111 22 33", "-₺ 14.500",  "err"),
            new("CR-006", "Anadolu Gıda",        "Müşteri",   "0322 654 32 10", "₺ 67.300",   "warn"),
            new("CR-007", "Güneş Enerji A.Ş.",   "Müşteri",   "0216 989 87 65", "₺ 0",        "ok"),
            new("CR-008", "Marmara Kimya",       "Tedarikçi", "0262 502 40 30", "-₺ 8.900",   "err"),
        };
    }
}
