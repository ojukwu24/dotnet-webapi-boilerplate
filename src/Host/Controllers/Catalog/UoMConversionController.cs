using FSH.WebApi.Application.Catalog.UoMConversions;
using Microsoft.AspNetCore.Mvc;

namespace FSH.WebApi.Host.Controllers.Catalog;
public class UoMConversionController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.UnitsOfMeasurementsConversion)]
    [OpenApiOperation("Search Units of Measure COnversion using available filters.", "")]
    public Task<PaginationResponse<UoMConversionDto>> SearchAsync(SearchUoMConversionRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.UnitsOfMeasurementsConversion)]
    [OpenApiOperation("Get Unit of Measurement Conversion details.", "")]
    public Task<UoMConversionDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetUoMConversionRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.UnitsOfMeasurementsConversion)]
    [OpenApiOperation("Create a new Unit of Measurement Conversion.", "")]
    public Task<Guid> CreateAsync(CreateUoMConversionRequest request)
    {
        return Mediator.Send(request);
    }
}
