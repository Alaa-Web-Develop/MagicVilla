﻿using System.ComponentModel.DataAnnotations;

namespace MagicVillaApi.Models
{
    public class Villa
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdatedOn { get; set; }

        public string Details { get; set; }
        public double Rate { get; set; }
        public int Occupancy { get; set; }
        public int sqfet { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }//الراحة اللطف

       

    }
}
