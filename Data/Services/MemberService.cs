using Microsoft.EntityFrameworkCore;
using MuslimApp.Data.viewmodel;
using MuslimApp.Models;

namespace MuslimApp.Data.Services
{
    public class MemberService : IMemberService
    {
        private readonly ApplicationDbContext _context;

        public MemberService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(member member)
        {
            await _context.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var res = await _context.members.FirstOrDefaultAsync(m => m.memberID == id);
            _context.members.Remove(res);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<member>> GetAllAsync()
        {
            var result = await _context.members.Include(x => x.mosque).ToListAsync();
            return result;
        }

        public async Task<member> GetByIdAsync(int id)
        {
            var res = await _context.members.Include(x => x.mosque).FirstOrDefaultAsync(m => m.memberID == id);
            return res;
        }

        public async Task<membersdropdown> GetMembersdropdownValues()
        {
          var response =new membersdropdown();
            response.Mosques = await _context.mosques.OrderBy(m => m.mosqueName).ToListAsync();
            return response;  
        }

        public async Task<member> UpdateAsync(int id, member newmember)
        {
            _context.Update(newmember);
            await _context.SaveChangesAsync();
            return newmember;
        }
    }
}
