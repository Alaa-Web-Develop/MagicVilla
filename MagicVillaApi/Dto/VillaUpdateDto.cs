using System.ComponentModel.DataAnnotations;

namespace MagicVillaApi.Dto
{
    public class VillaUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public string Details { get; set; }

        [Required]
        public double Rate { get; set; }
        [Required]
        public int Occupancy { get; set; }
        [Required]
        public int sqfet { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }//الراحة اللطف
    }
}
