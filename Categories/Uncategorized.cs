using TradeCategory.Models;

namespace TradeCategory.Categories;

class Uncategorized : ICategory
{
    public string Name { get; } = "No category found for trade";

    public bool IsInCategory(ITrade trade)
    {
        return true;
    }
}