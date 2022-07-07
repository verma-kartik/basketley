using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Helper
{
    public class TaxAndShippingPriceRequestHelper
    {
        public string? SelectedShippingMethodName { get; set; }

        public ShippingAddressHelper? NewShippingAddress { get; set; }

        public long ExistingShippingAddressId { get; set; }
    }
}
