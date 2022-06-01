using Entities.Models;
using Shared.RequestParameters;

namespace Repository
{
    public interface IProductVariantRepository
    {
        Task<PagedList<ProductVariant>> GetVariants(ProductVariantParameters productVariantParameters);

        Task<ProductVariant> GetVariantById(string productVariantID);

        Task<ProductVariant> CreateVariant(ProductVariant variant);

        Task<bool> DeleteVariant(string productVariantId);

    }
}
