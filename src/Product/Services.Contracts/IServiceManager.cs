﻿namespace Services.Contracts
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
        IProductVariantService ProductVariantService { get; }
    }
}
