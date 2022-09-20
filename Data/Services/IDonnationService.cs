using MuslimApp.Data.viewmodel;
using MuslimApp.Models;

namespace MuslimApp.Data.Services
{
    public interface IDonnationService
    {
        Task<IEnumerable<Donation>> GetAllAsync();
        Task<Donation> GetByIdAsync(int id);
        Task AddAsync(Donation newdonation);
        Task<Donation> UpdateAsync(int id, Donation newdonations);
        Task DeleteAsync(int id);
        Task<DonationsdropDown> GetDonationsdropDownValues();
    }
}
