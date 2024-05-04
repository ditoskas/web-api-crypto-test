using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Microsoft.EntityFrameworkCore.Index(nameof(Hash), IsUnique = true)]
    public class CryptoTransaction : BaseModel
    {
        [Column("CryptoTransactionId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required(ErrorMessage = "Hash is a required field.")]
        [MaxLength(128, ErrorMessage = "Maximum length for the Hash is 128 characters.")]
        public string Hash { get; set; }

        [ForeignKey(nameof(CryptoBlock))]
        public long CryptoBlockId { get; set; }

        public CryptoBlock? CryptoBlock { get; set; }
    }
}
