using TradeCategory.Categories;

namespace TradeCategory.Providers;

class CategoriesProvider : ICategoriesProvider
{
    private readonly IReferenceDateProvider _referenceDateProvider;
    public IEnumerable<ICategory> Categories { get; }

    public CategoriesProvider(IReferenceDateProvider referenceDateProvider)
    {
        _referenceDateProvider = referenceDateProvider;
        Categories = new List<ICategory>
        {
            new Expired(_referenceDateProvider),
            new HighRisk(),
            new MediumRisk()
        };
    }
}