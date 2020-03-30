using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipType
    {
        public Byte Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public Byte DurationInMonths { get; set; }
        public Byte DiscountRate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PaysAsYouGo = 1;
    }
}