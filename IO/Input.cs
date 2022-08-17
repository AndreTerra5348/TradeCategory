namespace TradeCategory.IO;

class Input
{
    public string? ReadReferenceDate()
    {
        Console.WriteLine("Enter the reference date:");
        return Console.ReadLine();
    }

    public string? ReadTradeAmount()
    {
        Console.WriteLine("Enter the number of trades:");
        return Console.ReadLine();
    }

    public string? ReadTrade()
    {
        Console.WriteLine("Enter the trade:");
        return Console.ReadLine();
    }
}