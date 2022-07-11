using FSH.WebApi.Application.Catalog.UnitsOfMeasurement;

namespace FSH.WebApi.Host.Controllers.Catalog;
[Route("api/[controller]")]
[ApiController]
public class UnitsOfMeasurementController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.UnitsOfMeasurements)]
    [OpenApiOperation("Search Unit of Measurements using using available filters.", "")]
    public Task<PaginationResponse<UnitOfMeasurementDto>> SearchAsync(SearchUnitOfMeasurementRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.UnitsOfMeasurements)]
    [OpenApiOperation("Get units of measurment details.", "")]
    public Task<UnitOfMeasurementDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetUnitOfMeasurementRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.UnitsOfMeasurements)]
    [OpenApiOperation("Create a new Unit of measurement.", "")]
    public Task<Guid> CreateAsync(CreateUnitOfMeasurementRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.UnitsOfMeasurements)]
    [OpenApiOperation("Update a Unit of Measurement.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateUnitOfMeasurementRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.UnitsOfMeasurements)]
    [OpenApiOperation("Delete a Unit of Measurement.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteUnitOfMeasurementRequest(id));
    }
}
