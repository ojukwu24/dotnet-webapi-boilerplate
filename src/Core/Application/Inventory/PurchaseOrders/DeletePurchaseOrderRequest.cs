using FSH.WebApi.Domain.Inventory;

namespace FSH.WebApi.Application.Inventory.PurchaseOrders;
public class DeletePurchaseOrderRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public DeletePurchaseOrderRequest(Guid id) => Id = id;
}
public class DeletePurchaseOrderRequestHandler : IRequestHandler<DeletePurchaseOrderRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepository<PurchaseOrder> _repository;

    private readonly IStringLocalizer _t;

    public DeletePurchaseOrderRequestHandler(IRepository<PurchaseOrder> repository, IStringLocalizer<DeletePurchaseOrderRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);
    public async Task<Guid> Handle(DeletePurchaseOrderRequest request, CancellationToken cancellationToken)
    {
        var purchaseOrder = await _repository.GetByIdAsync(request.Id, cancellationToken);
        _ = purchaseOrder ?? throw new NotFoundException(_t["Purchase Order {0} Not Found."]);

        //TODO: Raise an event to remove the value from stock
        await _repository.DeleteAsync(purchaseOrder, cancellationToken);

        return request.Id;
    }
}