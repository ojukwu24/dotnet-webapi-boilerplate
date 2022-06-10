namespace FSH.WebApi.Application.Catalog.UnitsOfMeasurement;

internal class UnitOfMeasurementByNameSpec : Specification<UnitOfMeasurement>, ISingleResultSpecification
{
    public UnitOfMeasurementByNameSpec(string name) =>
        Query.Where(b => b.Name == name);
}