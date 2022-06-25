namespace FSH.WebApi.Domain.Catalog
{
    public class UoMConversion: AuditableEntity, IAggregateRoot
    {
        public Guid ToUoMId {get; private set;}  //UoM is Unit of Measurement
        public virtual UnitOfMeasurement ToUoM {get; private set;} = default!;
        public Guid FromUoMId {get; private set;}  //UoM is Unit of Measurement
        public virtual UnitOfMeasurement FromUoM {get; private set;} = default!;
        public decimal Multiplier {get; private set;}
        public virtual Product Product {get; private set;} = default!;
        public Guid ProductId {get; set;}

        public UoMConversion(Guid productId, Guid fromUoMId,  Guid toUoMId, decimal multiplier)
        {
            ProductId = productId;
            ToUoMId = toUoMId;
            Multiplier = multiplier;
            FromUoMId = fromUoMId;
        }


        public UoMConversion Update(Guid? productId, Guid? fromUoMId, Guid? toUoMId, decimal? multiplier)
        {
            if(productId.HasValue && productId.Value != Guid.Empty && !productId.Equals(productId.Value)) productId = productId.Value;
            if(toUoMId.HasValue && toUoMId.Value != Guid.Empty && !ToUoMId.Equals(toUoMId.Value)) ToUoMId = toUoMId.Value;
            if(fromUoMId.HasValue && fromUoMId.Value != Guid.Empty && !FromUoMId.Equals(fromUoMId.Value)) FromUoMId = fromUoMId.Value;
            if(multiplier.HasValue && Multiplier != multiplier) Multiplier = multiplier.Value;
            return this;
        }

    }
}