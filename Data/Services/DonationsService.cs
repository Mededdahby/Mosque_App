using Microsoft.EntityFrameworkCore;
using MuslimApp.Data.viewmodel;
using MuslimApp.Models;

namespace MuslimApp.Data.Services
{
    public class DonationsService : IDonnationService
    {
        private readonly ApplicationDbContext _context;

        public DonationsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Donation newdonation)
        {
            await _context.AddAsync(newdonation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var res = await _context.donations.FirstOrDefaultAsync(m => m.Id == id);
            _context.donations.Remove(res);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Donation>> GetAllAsync()
        {
            var result = await _context.donations.Include(x => x.mosque).ToListAsync();
            return result;
        }

        public async Task<Donation> GetByIdAsync(int id)
        {
            var res = await _context.donations.Include(x => x.mosque).FirstOrDefaultAsync(m => m.Id == id);
            return res;
        }

        public async Task<DonationsdropDown> GetDonationsdropDownValues()
        {
            var response = new DonationsdropDown();
            response.Mosques = await _context.mosques.OrderBy(m => m.mosqueName).ToListAsync();
            return response;
        }

        public async Task<Donation> UpdateAsync(int id, Donation newdonations)
        {
            _context.Update(newdonations);
            await _context.SaveChangesAsync();
            return newdonations;
        }
    }
}
