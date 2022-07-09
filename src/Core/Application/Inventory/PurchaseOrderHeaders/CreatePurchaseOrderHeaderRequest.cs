using FSH.WebApi.Domain.Common.Events;
using FSH.WebApi.Domain.Inventory;

namespace FSH.WebApi.Application.Inventory.PurchaseOrderHeaders;
public class CreatePurchaseOrderHeaderRequest : IRequest<Guid>
{
    public Guid SupplierId { get; set; }
    public string SupplierName { get; set; } = default!;
    public DateTime PurchaseOrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Code { get; set; } = default!;
    public string Note { get; private set; } = default!;
}

public class CreatePurchaseOrderHeaderRequestHandler : IRequestHandler<CreatePurchaseOrderHeaderRequest, Guid>
{
    private readonly IRepository<PurchaseOrderHeader> _repository;

    public CreatePurchaseOrderHeaderRequestHandler(IRepository<PurchaseOrderHeader> repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreatePurchaseOrderHeaderRequest request, CancellationToken cancellationToken)
    {
        var purchaseOrderHeader = new PurchaseOrderHeader(request.SupplierId, request.PurchaseOrderDate, request.TotalAmount, request.Code, request.Note);

        purchaseOrderHeader.DomainEvents.Add(EntityCreatedEvent.WithEntity(purchaseOrderHeader));
        await _repository.AddAsync(purchaseOrderHeader, cancellationToken);
        return purchaseOrderHeader.Id;
    }
}