namespace Shared.RequestParameters
{
    public class ProductVariantParameters : RequestParameters
    {
        public uint MinPrice { get; set; }
        public uint MaxPrice { get; set; } = int.MaxValue;
    }
}
