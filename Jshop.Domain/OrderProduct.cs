namespace Jshop.Domain
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class OrderProduct
    {
        [Key]
        public long OrderProductId { get; set; }

        public long OrderId { get; set; }
        public long ProductId { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}
