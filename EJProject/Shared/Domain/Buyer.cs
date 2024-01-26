using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJProject.Shared.Domain
{
    public class Buyer : BaseDomainModel
    {
        public int BuyerID { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Number is not a valid phone number")]
        public string? PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Emai Address is not a valid email")]
        [EmailAddress]
        public string? Email { get; set; }

        public virtual List<Trade>?Trades { get; set; }
    }
}
