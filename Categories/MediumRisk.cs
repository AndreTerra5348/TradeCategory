using TradeCategory.Models;

namespace TradeCategory.Categories;

class MediumRisk : ICategory
{
    const int ValueThreashold = 1000000;
    public string Name { get; } = "MEDIUMRISK";

    public bool IsInCategory(ITrade trade)
    {
        return trade.Value > ValueThreashold && trade.ClientSector == Sectors.Public;
    }
}