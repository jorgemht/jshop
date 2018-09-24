namespace Jshop.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class Customer
    {
        [Key]
        public long CustomerId { get; set; }

        [Display(Name = "Nombre del cliente")]
        public string Name { get; set; }
        [Display(Name = "correo electronico")]
        public string Email { get; set; }
        [Display(Name = "Foto del cliente")]
        public string Photo { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
