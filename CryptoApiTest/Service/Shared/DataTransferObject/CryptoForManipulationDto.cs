using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObject
{
    public record CryptoForManipulationDto
    {
        [Required(ErrorMessage = "Symbol is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Symbol is 20 characters.")]
        public string? Symbol { get; set; }

        [MaxLength(255, ErrorMessage = "Maximum length for the Description is 255 characters.")]
        public string? Description { get; set; }
    }
}
