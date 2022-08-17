using TradeCategory.Categories;
using TradeCategory.Models;

namespace TradeCategory.Services;

interface IClassifier
{
    ICategory GetCategory(ITrade trade);
}