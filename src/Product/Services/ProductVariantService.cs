using Contracts;
using Entities.Models;
using Repository;
using Services.Contracts;
using Shared.RequestParameters;

namespace Services
{
    public sealed class ProductVariantService : IProductVariantService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public ProductVariantService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }

        public async Task<ProductVariant> CreateVariant(ProductVariant variant)
        {
            var createdVariant = await _repositoryManager.ProductVariant.CreateVariant(variant);
            return createdVariant;
        }

        public async Task<bool> DeleteVariant(string productVariantId)
        {
            return await _repositoryManager.ProductVariant.DeleteVariant(productVariantId);
        }

        public async Task<ProductVariant> GetVariantById(string productVariantID)
        {
            return await _repositoryManager.ProductVariant.GetVariantById(productVariantID);
        }

        public async Task<(IEnumerable<ProductVariant> variants, MetaData metaData)> GetVariants(ProductVariantParameters productVariantParameters)
        {
            var variantsWithMetaData = await _repositoryManager.ProductVariant.GetVariants(productVariantParameters);
            return (variants: variantsWithMetaData, metaData: variantsWithMetaData.MetaData);
        }
    }
}
