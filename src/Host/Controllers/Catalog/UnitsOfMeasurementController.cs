using FSH.WebApi.Application.Catalog.UnitsOfMeasurement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FSH.WebApi.Host.Controllers.Catalog;
[Route("api/[controller]")]
[ApiController]
public class UnitsOfMeasurementController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.UnitsOfMeasurement)]
    [OpenApiOperation("Search Unit of Measurements using using available filters.", "")]
    public Task<PaginationResponse<UnitOfMeasurementDto>> SearchAsync(SearchUnitOfMeasurementRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.UnitsOfMeasurement)]
    [OpenApiOperation("Get units of measurment details.", "")]
    public Task<UnitOfMeasurementDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetUnitOfMeasurementRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.UnitsOfMeasurement)]
    [OpenApiOperation("Create a new Unit of measurement.", "")]
    public Task<Guid> CreateAsync(CreateUnitOfMeasurementRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.UnitsOfMeasurement)]
    [OpenApiOperation("Update a Unit of Measurement.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateUnitOfMeasurementRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.UnitsOfMeasurement)]
    [OpenApiOperation("Delete a Unit of Measurement.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteUnitOfMeasurementRequest(id));
    }
}
