using MagicVillaApi.Models;
using System.Linq.Expressions;

namespace MagicVillaApi.Repository.IRepository
{
    public interface IVillaRepo:IRepository<Villa>
    {
     
        Task<Villa> UpdateAsync(Villa villa);

    }
}
