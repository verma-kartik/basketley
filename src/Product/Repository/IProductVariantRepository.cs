using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductVariantRepository
    {
        Task<IEnumerable<ProductVariant>> GetVariants();

        Task<ProductVariant> GetVariantById(string productVariantID);

        Task<ProductVariant> CreateVariant(ProductVariant variant);

        Task<bool> DeleteVariant(string productVariantId);

    }
}
