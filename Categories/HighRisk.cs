using TradeCategory.Models;

namespace TradeCategory.Categories;

class HighRisk : ICategory
{
    const int ValueThreashold = 1000000;
    public string Name { get; } = "HIGHRISK";

    public bool IsInCategory(ITrade trade)
    {
        return trade.Value > ValueThreashold && trade.ClientSector == Sectors.Private;
    }
}