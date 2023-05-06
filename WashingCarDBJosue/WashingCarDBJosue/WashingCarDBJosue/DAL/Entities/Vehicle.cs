using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WashingCarDBJosue.DAL.Entities
{
    public class Vehicle : Entity
    {
        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }
        [Required]
        public Guid ServiceId { get; set; }

        [Display(Name = "Propietario")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe ser de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es oblilgatorio.")]
        public string Owner { get; set; }

        [Display(Name = "Numero de Placa")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe ser de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es oblilgatorio.")]
        public String NumberPlate { get; set; }
    }
}
