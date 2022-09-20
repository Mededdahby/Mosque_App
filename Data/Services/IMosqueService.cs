using MuslimApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuslimApp.Data.Services
{
    public interface IMosqueService
    {
       Task< IEnumerable<mosque>> GetAllAsync();
       Task <mosque> GetByIdAsync(int id);
        Task AddAsync(mosque mosque);    
        Task<mosque> UpdateAsync( int  id , mosque newmosque); 
        Task DeleteAsync(int id);    

    }
}
