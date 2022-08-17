using TradeCategory.Models;
using TradeCategory.Providers;

namespace TradeCategory.Categories;

class Expired : ICategory
{
    private const int DaysToExpire = 30;
    public string Name { get; } = "EXPIRED";

    private readonly IReferenceDateProvider referenceDateProvider;

    public Expired(IReferenceDateProvider referenceDateProvider)
    {
        this.referenceDateProvider = referenceDateProvider;
    }

    public bool IsInCategory(ITrade trade)
    {
        var date = referenceDateProvider.ReferenceDate.Subtract(trade.NextPaymentDate);
        return date.Days > DaysToExpire;
    }
}