using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Address
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Id { get; set; }

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? District { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public int Zip { get; set; }

        public string? CountryCode { get; set; }

        public int? CustomerId { get; set; }
        //public Customer? Customer { get; set; }
    }
}
