using Entities.Models;
using Shared.RequestParameters;

namespace Services.Contracts
{
    public interface IProductVariantService
    {
        public Task<ProductVariant> CreateVariant(ProductVariant variant);

        public Task<bool> DeleteVariant(string productVariantId);

        public Task<ProductVariant> GetVariantById(string productVariantID);

        public Task<(IEnumerable<ProductVariant> variants, MetaData metaData)> GetVariants(ProductVariantParameters productVariantParameters);
    }
}
