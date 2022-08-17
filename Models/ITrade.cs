namespace TradeCategory.Models;
interface ITrade
{
    double Value { get; }
    string ClientSector { get; }
    DateTime NextPaymentDate { get; }

}