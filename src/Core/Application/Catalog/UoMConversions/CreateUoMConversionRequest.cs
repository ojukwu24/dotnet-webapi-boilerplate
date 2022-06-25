namespace FSH.WebApi.Application.Catalog.UoMConversions
{
    public class CreateUoMConversionRequest : IRequest<Guid>
    {
        public Guid ProductId { get; set; }

        /// <summary>
        /// UoM is Unit of Measurement.
        /// </summary>
        public Guid FromUoMId { get; set; }

        /// <summary>
        /// UoM is Unit of Measurement.
        /// </summary>
        public Guid ToUoMId { get; set; }
        public decimal Multiplier { get; set; }
    }

    public class CreateUoMConversionRequestHandler : IRequestHandler<CreateUoMConversionRequest, Guid>
    {
        private readonly IRepository<UoMConversion> _repository;
        private readonly IRepository<Product> _productRepository;
        public CreateUoMConversionRequestHandler(IRepository<UoMConversion> repository, IRepository<Product> productRepository) =>
        (_repository, _productRepository) = (repository, productRepository);
        public async Task<DefaultIdType> Handle(CreateUoMConversionRequest request, CancellationToken cancellationToken)
        {
            var uoMConversion = new UoMConversion(request.ProductId, request.FromUoMId, request.ToUoMId, request.Multiplier);

            await _repository.AddAsync(uoMConversion, cancellationToken);

            return uoMConversion.Id;
        }
    }
}