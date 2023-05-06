using System.ComponentModel.DataAnnotations;

namespace WashingCarDBJosue.DAL.Entities
{
    public class Entity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

    }
}
