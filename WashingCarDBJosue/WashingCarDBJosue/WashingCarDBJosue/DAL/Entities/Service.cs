using System.ComponentModel.DataAnnotations;

namespace WashingCarDBJosue.DAL.Entities
{
    public class Service : Entity
    {
        [Display(Name = "Servicio")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe ser de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es oblilgatorio.")]
        public String Name { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es oblilgatorio.")]
        public decimal Price { get; set; }
    }
}
