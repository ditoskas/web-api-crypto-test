using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    [Microsoft.EntityFrameworkCore.Index(nameof(Hash), IsUnique = true)]
    public class CryptoBlock : BaseModel
    {
        [Column("CryptoBlockId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required(ErrorMessage = "Hash is a required field.")]
        //[MaxLength(128, ErrorMessage = "Maximum length for the Hash is 128 characters.")]
        public string Hash { get; set; }
        public long? Height { get; set; }
        [Required(ErrorMessage = "Chain is a required field.")]
        [MaxLength(45, ErrorMessage = "Maximum length for the Chain is 45 characters.")]
        public string Chain { get; set; }
        public string? Total { get; set; }
        public long? Fees { get; set; }
        public long? BaseFee { get; set; }
        public long? Size { get; set; }
        public int? Ver { get; set; }
        public DateTime? Time { get; set; }
        public DateTime? ReceivedTime { get; set; }
        public string? CoinbaseAddr { get; set; }
        public string? RelayedBy { get; set; }
        public int? Nonce { get; set; }
        public int? NTx { get; set; }
        public string? PrevBlock { get; set; }
        public string? MrklRoot { get; set; }
        public ICollection<CryptoTransaction?> Txids { get; set; }
        public ICollection<CryptoInternalTransaction> InternalTxids { get; set; }
        public int? Depth { get; set; }
        public string? PrevBlockUrl { get; set; }
        public string? TxUrl { get; set; }
        public string? NextTxids { get; set; }

        [ForeignKey(nameof(CryptoNetwork))]
        public long CryptoNetworkId { get; set; }
        public CryptoNetwork? CryptoNetwork { get; set; }
    }
}
