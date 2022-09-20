using Microsoft.EntityFrameworkCore;
using MuslimApp.Data;
using MuslimApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuslimApp.Data.Services
{
    public class MosqueService : IMosqueService
    {
       private readonly ApplicationDbContext _context;

        public MosqueService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(mosque mosque)
        {
          await _context.AddAsync(mosque);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var res = await _context.mosques.FirstOrDefaultAsync(m => m.mosqueId == id);
            _context.mosques.Remove(res);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<mosque>> GetAllAsync()
        {
            var result = await _context.mosques.ToListAsync();
            return result;
        }

        public async Task<mosque> GetByIdAsync(int id)
        {
            var res = await _context.mosques.Include( x => x.members).
                FirstOrDefaultAsync(m => m.mosqueId == id);
            return res;
        }

        public async Task<mosque> UpdateAsync(int id, mosque newmosque)
        {
            _context.Update(newmosque);
            await _context.SaveChangesAsync();
            return newmosque;
        }
    }
}
