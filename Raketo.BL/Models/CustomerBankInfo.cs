using System.ComponentModel.DataAnnotations;

namespace Raketo.BL.Models
{
    public class CustomerBankInfo
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Surname { get; set; } = string.Empty;

        [Required]
        [StringLength(16, MinimumLength = 16)]
        public string NumberCard { get; set; } = string.Empty;

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string CVV { get; set; } = string.Empty;

        [Required]
        public string TotalPrice { get; set; } = string.Empty;

    }
}
