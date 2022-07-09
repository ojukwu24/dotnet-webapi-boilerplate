using FSH.WebApi.Domain.Inventory;

namespace FSH.WebApi.Application.Inventory.PurchaseOrderHeaders;
public class CreatePurchaseOrderHeaderRequestValidator : CustomValidator<CreatePurchaseOrderHeaderRequest>
{
    public CreatePurchaseOrderHeaderRequestValidator(IReadRepository<PurchaseOrderHeader> purchaseOrderHeaderRepo, IReadRepository<Supplier> supplierRepo, IStringLocalizer<CreatePurchaseOrderHeaderRequestValidator> T)
    {
        RuleFor(p => p.Code)
             .NotEmpty()
             .MaximumLength(100)
             .MustAsync(async (code, ct) => await purchaseOrderHeaderRepo.GetBySpecAsync(new PurchaseOrderHeaderByCodeSpec(code), ct) is null)
             .WithMessage((_, code) => T["Purchase Order Hearder {0} already Exists.", code]);

        RuleFor(p => p.SupplierId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await supplierRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Supplier {0} Not Found.", id]);
    }
}
