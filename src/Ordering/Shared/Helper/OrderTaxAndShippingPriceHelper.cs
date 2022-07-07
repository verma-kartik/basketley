using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Helper
{
    public class OrderTaxAndShippingPriceHelper
    {
        public bool IsProductPriceIncludedTax { get; set; }

        public IList<ShippingPriceHelper>? ShippingPrices { get; set; }

        public string? SelectedShippingMethodName { get; set; }

        public CartHelper? Cart { get; set; }
    }
}
