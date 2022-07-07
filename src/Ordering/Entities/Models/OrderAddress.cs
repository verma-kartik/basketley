using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class OrderAddress
    {
        [Key]
        public int? AddressId { get; set; }
        [StringLength(450)]
        public string? ContactName { get; set; }

        [StringLength(450)]
        public string? Phone { get; set; }

        [StringLength(450)]
        public string? AddressLine1 { get; set; }

        [StringLength(450)]
        public string? AddressLine2 { get; set; }

        [StringLength(450)]
        public string? City { get; set; }

        public string? District { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        [StringLength(450)]
        public string? ZipCode { get; set; }

    }
}
