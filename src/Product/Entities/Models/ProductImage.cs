using Entities.Models.Enums;

namespace Entities.Models
{
    public class ProductImage
    {
        public string? ID { get; set; }
        public string? AltText { get; set; } 
        public string? ImageUrl { get; set; }
        public string? ImageType { get; set; }

        public ProductImage() : this(string.Empty, string.Empty, string.Empty, ProductMediaType.IMAGE.ToString()) { }

        public ProductImage(string? id, string? alt, string? url, string? imageType)
        {
            ID = id;
            AltText = alt;
            ImageUrl = url;
            ImageType = imageType;
        }
    }
}
