using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRS.Models
{
    public class Request
    {
        public int Id { get; set; }
        [StringLength(80)]
        public string Description { get; set; } = string.Empty;
        [StringLength(80)]
        public string Justification { get; set; } = string.Empty;
        [StringLength(80)]
        public string? RejectionReason { get; set; }
        [StringLength(20)]
        public string DeliveryMode { get; set; } = "Pickup";
        [StringLength(10)]
        public string Status { get; set; } = "NEW";
        [Column(TypeName = "decimal(11,2)")]
        public decimal Total { get; set; } = 0;

        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public List<RequestLine>? RequestLines { get; set; }

    }
}
