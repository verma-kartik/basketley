using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? CustomerID { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Company { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public string? CountryCode { get; set; }

        public string? CountryName { get; set; }

        public string? EmailMarketingConsent { get; set; }

        public bool VerfiedEmail { get; set; }

        public List<Address>? Addresses { get; set; }
    }
}
