using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practical1.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Product Name cannot exceed 100 characters.")]
        public string ProductName { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit Price must be greater than zero.")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity of units in stock cannot be negative.")]
        public int UnitsInStock { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity of units on order cannot be negative.")]
        public int UnitsOnOrder { get; set; }

        [Required]
        public int ReorderLevel { get; set; }

        [Required]
        public bool Discontinued { get; set; }
        
        // Foreign key to Supplier
        [Required]
        [ForeignKey("Suppliers")]
        public int SupplierID { get; set; }

        // Navigation property
        public virtual Suppliers Suppliers { get; set; }
    }
}
