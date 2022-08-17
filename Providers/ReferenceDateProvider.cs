namespace TradeCategory.Providers;
class ReferenceDateProvider : IReferenceDateProvider
{
    private readonly DateTime referenceDate;
    public DateTime ReferenceDate => referenceDate;

    public ReferenceDateProvider(DateTime referenceDate)
    {
        this.referenceDate = referenceDate;
    }

}