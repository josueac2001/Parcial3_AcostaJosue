using WashingCarDBJosue.DAL.Entities;

namespace WashingCarDBJosue.Models
{
    public class VehicleViewModel : VehicleDetails
    {
        public Service Service { get; set; }

        public Guid ServiceId { get; set; }

        public string Owner { get; set; }

        public String NumberPlate { get; set; }
    }
}
