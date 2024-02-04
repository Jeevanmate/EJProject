using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJProject.Shared.Domain
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Product Name does not meet length requirements")]
        public string? ProductName { get; set; }

        public string? Category { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float Price { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Condition does not meet length requirements")]
        public string? Condition { get; set; }

        [Required]
        public string? Image { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Description does not meet length requirements")]
        public string? Description { get; set; }

        public int? SellerID { get; set; }
        public virtual Seller? Seller { get; set; }

    }

}
