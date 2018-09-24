namespace Jshop.Domain
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        public long ProductId { get; set; }

        [Display(Name = "Nombre del producto")]
        public string Name { get; set; }

        [Display(Name = "Cantidad")]
        public double Amount { get; set; }

        public long CategoryId { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
