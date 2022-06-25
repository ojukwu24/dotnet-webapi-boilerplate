namespace FSH.WebApi.Application.Catalog.UoMConversions
{
    public class UoMConversionByUnitsSpec : Specification<UoMConversion>, ISingleResultSpecification
    {
        public UoMConversionByUnitsSpec(Guid fromUnitId, Guid toUnitId, Guid productId) =>
            Query.Where(p=> p.FromUoMId == fromUnitId && p.ToUoMId == toUnitId && p.ProductId == productId);
    }
}