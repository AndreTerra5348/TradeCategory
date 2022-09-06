using TradeCategory.Models;

namespace TradeCategory.Categories;

class PublicUncategorized : ICategory
{
    public string Name { get; } = "PUBLIC_UNCATEGORIZED";

    public bool IsInCategory(ITrade trade)
    {
        return trade.ClientSector == Sectors.Public;
    }
}