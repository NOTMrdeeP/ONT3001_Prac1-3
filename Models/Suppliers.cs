using System.ComponentModel.DataAnnotations;

namespace Practical1.Models
{
    public class Suppliers
    {
        [Key]
        public int SupplierID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Company Name cannot exceed 100 characters.")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Contact Name cannot exceed 100 characters.")]
        public string ContactName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Contact Title cannot exceed 50 characters.")]
        public string ContactTitle { get; set; }

        [Required]
        [StringLength(75, ErrorMessage = "Address cannot exceed 75 characters.")]
        public string Address { get; set; }

        [Required]
        [StringLength(75, ErrorMessage = "City cannot exceed 75 characters.")]
        public string City { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Region cannot exceed 50 characters.")]
        public string Region { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [StringLength(10, ErrorMessage = "Postal Code cannot exceed 10 characters.")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Country cannot exceed 50 characters.")]
        public string Country { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10, ErrorMessage = "Phone cannot exceed 10 characters.")]
        public string Phone { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Fax cannot exceed 10 characters.")]
        public string Fax { get; set; }

        [DataType(DataType.Url)]
        public string HomePage { get; set; }

        // Navigation property: 1 Supplier to Many Products
        public virtual ICollection<Products> Products { get; set; }

    }
}
