using System.Globalization;
using TradeCategory.Categories;
using TradeCategory.IO;
using TradeCategory.Models;
using TradeCategory.Providers;
using TradeCategory.Services;

namespace TradeCategory;

class Worker
{
    private readonly Input _input;
    private readonly Output _output;

    public Worker()
    {
        _input = new Input();
        _output = new Output();
    }

    public void Run()
    {
        DateTime refDate = GetReferenceDate();
        int tradeAmount = GetTradeAmount();
        IEnumerable<ITrade> portfolio = GetPortfolio(tradeAmount);
        IReferenceDateProvider refDateProvider = new ReferenceDateProvider(refDate);
        ICategoriesProvider categoriesProvider = new CategoriesProvider(refDateProvider);
        IClassifier classifier = new Classifier(categoriesProvider);
        IEnumerable<ICategory> categories = portfolio.Select(classifier.GetCategory);
        _output.WriteCategories(categories);
    }

    DateTime GetReferenceDate()
    {
        string? referenceDateString = _input.ReadReferenceDate();
        if (!DateTime.TryParseExact(referenceDateString, Trade.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var referenceDate))
        {
            _output.WriteInvalidInput();
            return GetReferenceDate();
        }

        return referenceDate;
    }

    int GetTradeAmount()
    {
        string? tradeAmountString = _input.ReadTradeAmount();
        if (!int.TryParse(tradeAmountString, out var tradeAmount))
        {
            _output.WriteInvalidInput();
            return GetTradeAmount();
        }

        return tradeAmount;
    }

    ITrade GetTrade()
    {
        string? tradeString = _input.ReadTrade();
        if (!Trade.TryParse(tradeString, out Trade? trade))
        {
            _output.WriteInvalidInput();
            return GetTrade();
        }

        return trade!;
    }

    IEnumerable<ITrade> GetPortfolio(int tradeAmount)
    {
        List<ITrade> portfolio = new List<ITrade>();
        for (int i = 0; i < tradeAmount; i++)
        {
            ITrade trade = GetTrade();
            portfolio.Add(trade);
        }
        return portfolio;
    }
}