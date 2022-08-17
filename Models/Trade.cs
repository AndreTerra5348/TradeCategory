using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace TradeCategory.Models;
class Trade : ITrade
{
    public static readonly string DateFormat = "M/d/yyyy";
    public double Value { get; }
    public string ClientSector { get; }
    public DateTime NextPaymentDate { get; }

    public Trade(double value, string clientSector, DateTime nextPaymentDate)
    {
        Value = value;
        ClientSector = clientSector;
        NextPaymentDate = nextPaymentDate;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, out Trade? result)
    {
        if (s is null)
        {
            result = null;
            return false;
        }

        var fields = s.Split(' ');
        if (!double.TryParse(fields[0], out var value))
        {
            Console.WriteLine("Invalid value: " + fields[0]);
            result = null;
            return false;
        }

        if (fields[1] != Sectors.Private && fields[1] != Sectors.Public)
        {
            Console.WriteLine("Invalid sector: " + fields[1]);
            result = null;
            return false;
        }

        if (!DateTime.TryParseExact(fields[2], DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
        {
            Console.WriteLine("Invalid date: " + fields[2]);
            result = null;
            return false;
        }

        result = new Trade(value, fields[1], date);
        return true;
    }
}