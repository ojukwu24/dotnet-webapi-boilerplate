using FSH.WebApi.Domain.Inventory;

namespace FSH.WebApi.Application.Inventory.PurchaseOrderHeaders;
public class GetPurchaseOrderHeaderRequest : IRequest<PurchaseOrderHeaderDto>
{
    public Guid Id { get; set; }
    public GetPurchaseOrderHeaderRequest(Guid id)
    {
        Id = id;
    }
}
public class GetPurchaseOrderHeaderRequestHandler : IRequestHandler<GetPurchaseOrderHeaderRequest, PurchaseOrderHeaderDto>
{
    private readonly IRepository<PurchaseOrderHeader> _repository;
    private readonly IStringLocalizer _t;

    public GetPurchaseOrderHeaderRequestHandler(IRepository<PurchaseOrderHeader> repository, IStringLocalizer<GetPurchaseOrderHeaderRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<PurchaseOrderHeaderDto> Handle(GetPurchaseOrderHeaderRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<PurchaseOrderHeader, PurchaseOrderHeaderDto>)new PurchaseOrderHeaderByIdWithSupplierSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Purchase Order Header {0} Not Found.", request.Id]);
}
