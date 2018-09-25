namespace Jshop.Domain
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Store
    {
        [Key]
        public long StoreId { get; set; }

        [Display(Name = "Nombre de la tienda")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "El campo es requerido, no puede superar los 30 caracteres y debe empezar por mayusculas"), Required, StringLength(30)]
        public string Name { get; set; }

        [Display(Name = "Dirección")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Debes rellenar la dirección  y debe tener una longitud entre {1} y {2} ")]
        public string Address { get; set; }

        [Display(Name = "Código postal")]
        public string CodePostal { get; set; }

        [Display(Name = "Foto del local")]
        public string Photo { get; set; }

        [Display(Name = "Teléfono")]
        [RegularExpression(@"^\+(?:[0-9]\x20?){6,15}[0-9]$", ErrorMessage = "El numero de teléfono debe empezar por +Código internacional hasta un máximo de 15 digitos")]
        public string Phone { get; set; }

        [Display(Name = "Latitude")]
        [Required(ErrorMessage = "Debes especificar la latitud")]
        public double Latitude { get; set; }

        [Display(Name = "Longitude")]
        [Required(ErrorMessage = "Debes especificar la longitud")]
        public double Longitude { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
