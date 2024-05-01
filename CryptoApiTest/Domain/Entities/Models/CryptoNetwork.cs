using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{

    public class CryptoNetwork : BaseModel
    {
        [Column("CryptoNetworkId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the name is 20 characters.")]
        public string? Name { get; set; }

        [MaxLength(255, ErrorMessage = "Maximum length for the Description is 255 characters.")]
        public string? Description { get; set; }

        [ForeignKey(nameof(Crypto))]
        public long CryptoId { get; set; }

        public Crypto? Crypto { get; set; }
    }
}