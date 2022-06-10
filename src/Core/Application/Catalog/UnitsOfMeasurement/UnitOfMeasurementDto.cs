namespace FSH.WebApi.Application.Catalog.UnitsOfMeasurement;
public class UnitOfMeasurementDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
}
