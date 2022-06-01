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
            try
            {
                var createdVariant = await _repositoryManager.ProductVariant.CreateVariant(variant);
                return createdVariant;
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the {nameof(CreateVariant)} " +
                    $"service method {ex}. Cannot create variant.");
                throw;
            }
        }

        public async Task<bool> DeleteVariant(string productVariantId)
        {
            try
            {
                return await _repositoryManager.ProductVariant.DeleteVariant(productVariantId);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the {nameof(DeleteVariant)} " +
                    $"service method {ex}. Product Variant not found with ID {nameof(productVariantId)}. Try again!");
                throw;
            }
        }

        public async Task<ProductVariant> GetVariantById(string productVariantID)
        {
            try
            {
                return await _repositoryManager.ProductVariant.GetVariantById(productVariantID);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the {nameof(GetVariantById)} " +
                    $"service method {ex}. Product Variant not found with ID {nameof(productVariantID)}. Try again!");
                throw;
            }
        }

        public async Task<(IEnumerable<ProductVariant> variants, MetaData metaData)> GetVariants(ProductVariantParameters productVariantParameters)
        {
            try
            {
                var variantsWithMetaData = await _repositoryManager.ProductVariant.GetVariants(productVariantParameters);
                return (variants: variantsWithMetaData, metaData: variantsWithMetaData.MetaData );
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the {nameof(GetVariants)} " +
                    $"service method {ex}");
                throw;
            }
        }
    }
}
