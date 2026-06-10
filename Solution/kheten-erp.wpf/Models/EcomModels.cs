namespace kheten_erp.wpf.Models
{
    /// <summary>Pazaryerinden düşen sipariş. Net = Tutar − Komisyon − Kargo.</summary>
    public record EcomOrder(
        string OrderNo,
        string Channel,
        string Customer,
        string Date,
        string Amount,
        string Commission,
        string Cargo,
        string Net,
        string Status,
        string StatusKind);

    /// <summary>Kanal (pazaryeri) kârlılık parametreleri — ayarlarda tutulur.</summary>
    public record ChannelProfit(
        string Channel,
        string Commission,   // örn. "%18"
        string Cargo,        // örn. "₺ 44,90"
        string MonthlyOrders,
        string MonthlyNet);
}
