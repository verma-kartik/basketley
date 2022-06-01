using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IProductVariantService
    {
        public Task<ProductVariant> CreateVariant(ProductVariant variant);

        public Task<bool> DeleteVariant(string productVariantId);

        public Task<ProductVariant> GetVariantById(string productVariantID);

        public Task<IEnumerable<ProductVariant>> GetVariants();
    }
}
