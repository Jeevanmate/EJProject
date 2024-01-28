using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJProject.Shared.Domain
{
    public class Staff : BaseDomainModel
    {
        public int StaffID { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "Gender does not meet the length requirements")]
        public string? Gender { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Position does not meet the length requirements")]
        public string? Position { get; set; }
    }
}
