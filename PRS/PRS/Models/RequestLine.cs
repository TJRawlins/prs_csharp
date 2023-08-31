using System.Text.Json.Serialization;

namespace PRS.Models
{
    public class RequestLine
    {
        public int Id { get; set; }
        public int Quantity { get; set; } = 1;

        public int RequestId { get; set; }
        [JsonIgnore]
        public virtual Request? Requests { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Products { get; set; }
    }
}
