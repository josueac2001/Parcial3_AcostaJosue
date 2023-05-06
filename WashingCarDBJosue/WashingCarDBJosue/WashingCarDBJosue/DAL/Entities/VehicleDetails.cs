using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WashingCarDBJosue.DAL.Entities
{
    public class VehicleDetails: Entity
    {
        [ForeignKey("VehiculeId")]
        public virtual Vehicle Vehicle { get; set; }
        [Required]
        [Display(Name = "Vehiculo")]
        public Guid VehiculeId { get; set; }
        

        [Display(Name = "Fecha de creación")]
        public DateTime? CreationDate { get; set; }

        [Display(Name = "Fecha de Entrega")]
        public DateTime? DeliveryDate { get; set; }
    }
}
