using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Microsoft.EntityFrameworkCore.Index(nameof(Symbol), IsUnique = true)]

    public class Crypto : BaseModel
    {
        [Column("CryptoId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "Symbol is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Symbol is 20 characters.")]
        public string? Symbol { get; set; }

        [MaxLength(255, ErrorMessage = "Maximum length for the Description is 255 characters.")]
        public string? Description { get; set; }

        public ICollection<CryptoNetwork>? CryptoNetworks { get; set; }
    }
}
