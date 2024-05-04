using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObject
{
    public record CryptoNetworkForManipulationDto
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the name is 20 characters.")]
        public string? Name { get; init; }
        [MaxLength(255, ErrorMessage = "Maximum length for the Description is 255 characters.")]
        public string? Description { get; init; }
    }
}
