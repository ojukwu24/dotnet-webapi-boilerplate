namespace FSH.WebApi.Application.Catalog.UoMConversions
{
    public class UoMConversionDto : IDto
    {
        public Guid ProductId {get; set;}
        public string ProductName {get; set;} = default!;
        public Guid TFromUoMId {get; set;}  //UoM is Unit of Measurement
        public string FromUnitName {get; set;} = default!;
        public Guid ToUoMId {get; set;}  //UoM is Unit of Measurement
        public string ToUnitName {get; set;} = default!;
        public decimal Multiplier {get; set;}
    }
}