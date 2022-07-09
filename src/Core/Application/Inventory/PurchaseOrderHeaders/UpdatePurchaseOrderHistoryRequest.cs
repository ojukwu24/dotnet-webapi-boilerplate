using FSH.WebApi.Domain.Common.Events;
using FSH.WebApi.Domain.Inventory;

namespace FSH.WebApi.Application.Inventory.PurchaseOrderHeaders;
public class UpdatePurchaseOrderHistoryRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public Guid SupplierId { get; set; }
    public string SupplierName { get; set; } = default!;
    public DateTime PurchaseOrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Code { get; set; } = default!;
    public string Note { get; private set; } = default!;
}

public class UpdatePurchaseOrderHistoryRequestHandler : IRequestHandler<UpdatePurchaseOrderHistoryRequest, Guid>
{
    public readonly IRepository<PurchaseOrderHeader> _repository;
    private readonly IStringLocalizer _t;

    public UpdatePurchaseOrderHistoryRequestHandler(IRepository<PurchaseOrderHeader> repository, IStringLocalizer<UpdatePurchaseOrderHistoryRequestHandler> t)
    {
        _repository = repository;
        _t = t;
    }

    public async Task<Guid> Handle(UpdatePurchaseOrderHistoryRequest request, CancellationToken cancellationToken)
    {
        var purchaseOrderHeader = await _repository.GetByIdAsync(request.Id, cancellationToken);
        _ = purchaseOrderHeader ?? throw new NotFoundException(_t["Purchase Order Header {0} Not Found.", request.Id]);

        var updatePurchaseOrderHeader = purchaseOrderHeader.Update(request.SupplierId, request.PurchaseOrderDate, request.TotalAmount, request.Code, request.Note);

        // Add Domain Events to be raised after the commit
        purchaseOrderHeader.DomainEvents.Add(EntityUpdatedEvent.WithEntity(purchaseOrderHeader));

        await _repository.UpdateAsync(updatePurchaseOrderHeader, cancellationToken);

        return request.Id;
    }
}
