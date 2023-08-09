using System.ComponentModel.DataAnnotations;

namespace MagicVillaApi.Dto
{
    public class VillaCreateDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public string Details { get; set; }

        [Required]
        public double Rate { get; set; }
        public int Occupancy { get; set; }
        public int sqfet { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }//الراحة اللطف
    }
}
