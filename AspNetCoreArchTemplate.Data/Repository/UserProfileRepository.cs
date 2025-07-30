using AspNetCoreArchTemplate.Data.Repository.Interfaces;
using EatHealthy.Data;
using EatHealthy.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreArchTemplate.Data.Repository
{
    public class UserProfileRepository : BaseRepository<UserProfile, Guid>, IUserProfileRepository
    {
        public UserProfileRepository(EatHealthyDbContext context) : base(context) { }

        public async Task<UserProfile> GetByUserIdAsync(Guid userId)
        {
            return await _context.UserProfiles
                .FirstOrDefaultAsync(p => p.UserId == userId);
        }
    }
}
