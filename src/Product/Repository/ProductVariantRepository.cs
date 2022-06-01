using Entities.Models;
using MongoDB.Driver;
using Shared.RequestParameters;

namespace Repository
{
    public class ProductVariantRepository : IProductVariantRepository
    {
        protected IProductVariantContext _variantContext;

        public ProductVariantRepository(IProductVariantContext variantContext)
        {
            _variantContext = variantContext;   
        }

        public async Task<ProductVariant> CreateVariant(ProductVariant variant)
        {
            await _variantContext.ProductVariants.InsertOneAsync(variant);
            return variant;
        }

        public async Task<bool> DeleteVariant(string productVariantId)
        {
            FilterDefinition<ProductVariant> filter = Builders<ProductVariant>.Filter.Eq(p => p.Id, productVariantId);

            DeleteResult deleteResult = await _variantContext
                .ProductVariants
                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<ProductVariant> GetVariantById(string productVariantID)
        {
            return await _variantContext
                .ProductVariants
                .Find(p => p.Id == productVariantID)
                .FirstOrDefaultAsync();
        }

        public async Task<PagedList<ProductVariant>> GetVariants(ProductVariantParameters productVariantParameters)
        {
            var variants = await _variantContext.ProductVariants
                .Find(p => p.Price >= productVariantParameters.MinPrice && p.Price <= productVariantParameters.MaxPrice)
                .ToListAsync();

            return PagedList<ProductVariant>.ToPagedList(variants, productVariantParameters.PageNumber, productVariantParameters.PageSize);
        }
    }
}
