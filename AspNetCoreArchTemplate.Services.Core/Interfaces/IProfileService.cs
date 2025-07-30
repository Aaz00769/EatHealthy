using EatHealthy.Data.Models;
using EatHealthy.Web.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Services.Core.Interfaces
{
    public interface IProfileService
    {
        Task CreateOrUpdateProfileAsync(Guid userId, UserProfileModel model);
        Task<UserProfile> GetUserProfileAsync(Guid userId);
        Task<int> CalculateDailyCalorieTarget(UserProfile profile);
    }
}
