﻿namespace Shared.RequestParameters
{
    public class ProductParameters : RequestParameters
    {
        public uint MinPrice { get; set; }
        public uint MaxPrice { get; set; } = int.MaxValue;
    }
}
