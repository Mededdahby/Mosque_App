using MuslimApp.Data.viewmodel;
using MuslimApp.Models;

namespace MuslimApp.Data.Services
{
    public interface IMemberService
    {
        Task<IEnumerable<member>> GetAllAsync();
        Task<member> GetByIdAsync(int id);
        Task AddAsync(member newmember);
        Task<member> UpdateAsync(int id, member newmember);
        Task DeleteAsync(int id);
     Task<membersdropdown> GetMembersdropdownValues();

    }
}
