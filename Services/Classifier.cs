using TradeCategory.Categories;
using TradeCategory.Models;
using TradeCategory.Providers;

namespace TradeCategory.Services;
class Classifier : IClassifier
{
    private readonly ICategoriesProvider _categoriesProvider;
    private readonly ICategory _uncategorized;
    public Classifier(ICategoriesProvider categoriesProvider)
    {
        _categoriesProvider = categoriesProvider;
        _uncategorized = new Uncategorized();
    }

    public ICategory GetCategory(ITrade trade)
    {
        foreach (var category in _categoriesProvider.Categories)
        {
            if (category.IsInCategory(trade))
            {
                return category;
            }
        }
        return _uncategorized;
    }
}