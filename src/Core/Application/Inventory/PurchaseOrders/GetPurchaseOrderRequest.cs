using FSH.WebApi.Domain.Inventory;

namespace FSH.WebApi.Application.Inventory.PurchaseOrders;

public class GetPurchaseOrderRequest : IRequest<PurchaseOrderDetailsDto>
{
    public Guid Id { get; set; }
    public GetPurchaseOrderRequest(Guid id) => Id = id;
}

public class PurchaseOrderByIdSpec : Specification<PurchaseOrder, PurchaseOrderDetailsDto>, ISingleResultSpecification
{
    public PurchaseOrderByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}
public class GetPurchaseOrderRequestHandler : IRequestHandler<GetPurchaseOrderRequest, PurchaseOrderDetailsDto>
{
    private readonly IRepository<PurchaseOrder> _repository;
    private readonly IStringLocalizer _t;

    public GetPurchaseOrderRequestHandler(IRepository<PurchaseOrder> repository, IStringLocalizer<GetPurchaseOrderRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<PurchaseOrderDetailsDto> Handle(GetPurchaseOrderRequest request, CancellationToken cancellationToken) =>
       await _repository.GetBySpecAsync(
           (ISpecification<PurchaseOrder, PurchaseOrderDetailsDto>)new PurchaseOrderByIdSpec(request.Id), cancellationToken)
       ?? throw new NotFoundException(_t["Purchase Order {0} Not Found.", request.Id]);
}
