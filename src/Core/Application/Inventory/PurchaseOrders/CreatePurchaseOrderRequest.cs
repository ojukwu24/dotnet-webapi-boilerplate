using FSH.WebApi.Domain.Inventory;

namespace FSH.WebApi.Application.Inventory.PurchaseOrders;
public class CreatePurchaseOrderRequest : IRequest<Guid>
{
    public Guid PurchaseOrderHeaderId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
}

public class CreatePurchaseOrderRequestValidator : CustomValidator<CreatePurchaseOrderRequest>
{
    public CreatePurchaseOrderRequestValidator(IReadRepository<PurchaseOrder> repository, IStringLocalizer<CreatePurchaseOrderRequestValidator> T, IReadRepository<Product> productRepo, IReadRepository<PurchaseOrderHeader> pohRepo)
    {
        RuleFor(p => p.ProductId)
        .NotEmpty()
        .MustAsync(async (productId, ct) => await productRepo.GetByIdAsync(productId, ct) is not null)
        .WithMessage((_, productId) => T["Product {0} not found.", productId]);

        RuleFor(p => p.PurchaseOrderHeaderId)
            .NotEmpty()
            .MustAsync(async (purchaseOrderHeaderId, ct) => await pohRepo.GetByIdAsync(purchaseOrderHeaderId, ct) is not null)
            .WithMessage((_, purchaseOrderHeaderId) => T["Purchase Order Header {0} not found.", purchaseOrderHeaderId]);

        RuleFor(x => x.Quantity)
            .GreaterThanOrEqualTo(1);
    }
}

public class CreatePurchaseOrderRequestHandler : IRequestHandler<CreatePurchaseOrderRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<PurchaseOrder> _repository;

    public CreatePurchaseOrderRequestHandler(IRepositoryWithEvents<PurchaseOrder> repository) => _repository = repository;

    public async Task<Guid> Handle(CreatePurchaseOrderRequest request, CancellationToken cancellationToken)
    {
        var purchaseOrder = new PurchaseOrder(request.PurchaseOrderHeaderId, request.UnitPrice, request.Quantity, request.ProductId);

        await _repository.AddAsync(purchaseOrder, cancellationToken);

        return purchaseOrder.Id;
    }
}
