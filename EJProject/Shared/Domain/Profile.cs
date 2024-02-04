using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJProject.Shared.Domain
{
    public class Profile : BaseDomainModel
    {
        public int ProfileID { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Gender does not meet the length requirements")]
        public string? Gender { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Number is not a valid phone number")]
        public string? PhoneNumber { get; set; }



        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Description does not meet length requirements")]
        public string? Description { get; set; }

        [Required]
        public string? Image { get; set; } = string.Empty;

    }
}
