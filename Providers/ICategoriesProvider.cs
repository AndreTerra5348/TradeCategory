using TradeCategory.Categories;

namespace TradeCategory.Providers;

interface ICategoriesProvider
{
    IEnumerable<ICategory> Categories { get; }
}
