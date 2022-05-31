using Entities.Models;
using Entities.Models.Enums;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class ContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            //bool existProduct = productCollection.Find(p => true).Any();
            //if (!existProduct)
            //{
                productCollection.InsertOneAsync(GetPreconfiguredProducts());
            //}
        }

        private static Product GetPreconfiguredProducts()
        {
            Weight thisweight = new(WeightUnit.G.ToString(), 500);
            ProductImage image = new("idk", "idk", "idk", ProductMediaType.VIDEO.ToString() );
            ProductVariant variant = new("123", "IPhoneX Pro", 1199.0, DateTime.Now, DateTime.Now, true //, thisweight, true, image
                                                                                                                              );
            //List<ProductVariant> variants = new List<ProductVariant>
            //{
            //    variant
            //};
            //    { new ProductVariant("123", "IPhoneX Pro", 1199.0, DateTime.Now, DateTime.Now, thisweight, true, image),
            //      new ProductVariant("124", "IPhoneX Pro", 1199.0, DateTime.Now, DateTime.Now, thisweight, true, image)

            //};
            return new Product()
            {
                //new Product()
                //{
                Id = "602d2149e773f2a3990b47a2",
                Name = "IPhone 12",
                ProductType = ProductType.SHIPPABLE.ToString(),
                Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum" +
                    " rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet," +
                    " consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora" +
                    " nihil dicta earum fugiat. Temporibus, voluptatibus.",
                Category = "Smart Phone",
                Price = 920.00,
                Created = DateTime.Now,
                UpdatedAt = DateTime.Now,
                ChargeTaxes = true,

                IsAvailable = true,
                WeightOfProduct = thisweight,
                Image = image,
                ProductVariant = variant
                
                //}
            };
        }
    
}
}
