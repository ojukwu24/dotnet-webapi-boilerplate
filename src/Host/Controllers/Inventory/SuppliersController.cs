using FSH.WebApi.Application.Inventory.Suppliers;

namespace FSH.WebApi.Host.Controllers.Inventory;
[Route("api/[controller]")]
[ApiController]
public class SuppliersController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Suppliers)]
    [OpenApiOperation("Search Suppliers using available filters.", "")]
    public Task<PaginationResponse<SupplierDto>> SearchAsync(SearchSuppliersRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Suppliers)]
    [OpenApiOperation("Get category details.", "")]
    public Task<SupplierDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetSupplierRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Suppliers)]
    [OpenApiOperation("Create a new category.", "")]
    public Task<Guid> CreateAsync(CreateSupplierRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Suppliers)]
    [OpenApiOperation("Update a category.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateSupplierRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Suppliers)]
    [OpenApiOperation("Delete a category.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteSupplierRequest(id));
    }
}
