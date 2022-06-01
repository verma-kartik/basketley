using Entities.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<ProductVariant>> GetVariants()
        {
            return await _variantContext.ProductVariants.Find(p => true).ToListAsync();
        }
    }
}
