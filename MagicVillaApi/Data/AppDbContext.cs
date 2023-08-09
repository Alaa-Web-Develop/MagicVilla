using MagicVillaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)//pass connecstr to dbcontext
        {   
        }
        public DbSet<Villa> Villas { get; set; }

        //Seeding Data :
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
            {
                Id=1,
                Name="Villa1",
                Amenity="Amenity1",
                Details="Deatils1",
                ImageUrl="img1",
                Occupancy=1,
                sqfet=1,
                Rate=1,
                CreatedDate=DateTime.Now
            }, new Villa
            {
                Id = 2,
                Name = "Villa2",
                Amenity = "Amenity2",
                Details = "Deatils2",
                ImageUrl = "img2",
                Occupancy = 2,
                sqfet = 2,
                Rate = 2,
                CreatedDate = DateTime.Now
            }, new Villa
            {
                Id = 3,
                Name = "Villa3",
                Amenity = "Amenity3",
                Details = "Deatils3",
                ImageUrl = "img3",
                Occupancy = 3,
                sqfet = 3,
                Rate = 3,
                CreatedDate = DateTime.Now
            }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
