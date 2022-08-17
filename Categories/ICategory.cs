using TradeCategory.Models;

namespace TradeCategory.Categories;
interface ICategory
{
    string Name { get; }
    bool IsInCategory(ITrade trade);
}