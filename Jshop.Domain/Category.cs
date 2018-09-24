namespace Jshop.Domain
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key]
        public long CategoryId { get; set; }

        [Display(Name = "Nombre de la categoría")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "El campo es requerido, no puede superar los 30 caracteres y debe empezar por mayusculas"), Required, StringLength(30)]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}
