using TM.Shared.DTOs;
using TM.Shared;
using TM.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace TM.Api.Services
{
    public class UserService
    {
        private readonly TaskContext _context;

        public UserService(TaskContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<UserDto>> GetUsersAsync(int startIndex, int pageSize)
        {
            var query = _context.Users.AsQueryable();

            var total = await query.CountAsync();
            var users = await query.OrderBy(u => u.Id)  
                        .Skip(startIndex)
                        .Take(pageSize)
                        .Select(u => new UserDto(u.Id, u.Name, u.Email, u.Phone, u.IsApproved))
                        .ToArrayAsync();

            return new PagedResult<UserDto>(users, total);
        }

        public async Task ToggleUserApprovedStatus(int userId)
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (dbUser != null)
            {
                dbUser.IsApproved = !dbUser.IsApproved;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(int userId)
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (dbUser != null)
            {
                _context.Users.Remove(dbUser);
                await _context.SaveChangesAsync();
            }
        }

    }
}
