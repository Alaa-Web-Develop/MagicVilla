using MagicVillaApi.Data;
using MagicVillaApi.Models;
using MagicVillaApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVillaApi.Repository
{
    public class VillaRepository :Repository<Villa>, IVillaRepo
    {
        private readonly AppDbContext _db;
        //Inject DB In ctor
        public VillaRepository(AppDbContext db):base(db)
        {
            _db = db;
        }
        public async Task<Villa> UpdateAsync(Villa villa)
        {
            villa.LastUpdatedOn = DateTime.Now;
            _db.Villas.Update(villa);
            await _db.SaveChangesAsync();
            return villa;
        }
    }
}
