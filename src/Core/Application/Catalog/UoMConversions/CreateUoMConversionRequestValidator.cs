namespace FSH.WebApi.Application.Catalog.UoMConversions
{
    public class CreateUoMConversionRequestValidator : CustomValidator<CreateUoMConversionRequest>
    {
        public CreateUoMConversionRequestValidator(IReadRepository<UoMConversion> uomConversionRepo,
        IReadRepository<UnitOfMeasurement> uomRepo, IReadRepository<Product> productRepo,
        IStringLocalizer<CreateUoMConversionRequestValidator> T){
            RuleFor(p => p.FromUoMId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await uomRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Unit of Measurement {0} Not Found.", id])
            .MustAsync(async (CreateUoMConversionRequest,fromUnitId, ct) => await uomConversionRepo.GetBySpecAsync(
                new UoMConversionByUnitsSpec(fromUnitId,CreateUoMConversionRequest.ToUoMId,CreateUoMConversionRequest.ProductId), ct) is null)
                .WithMessage((_,fromUnitId) => T["Conversion for the selected product and units already exists"]);

            RuleFor(x => x.Multiplier)
            .GreaterThanOrEqualTo(1);

            RuleFor(p => p.ToUoMId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await uomRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Unit of Measurement {0} Not Found.", id]);

            RuleFor(p => p.ProductId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await productRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Product {0} Not Found.", id]);
        }
    }
}