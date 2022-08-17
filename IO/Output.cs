using TradeCategory.Categories;

namespace TradeCategory.IO;

class Output
{
    public void WriteCategories(IEnumerable<ICategory> categories)
    {
        foreach (var category in categories)
        {
            Console.WriteLine(category.Name);
        }
    }

    public void WriteInvalidInput()
    {
        Console.WriteLine("Invalid input.");
    }

}