using SkillSwapCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwapServices.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(Guid userId);
        Task<bool> CreateUserAsync(string name, string email, string password);
        Task<bool> UpdateUserCreditsAsync(Guid userId, int creditChange);
        Task<bool> UserExistsAsync(Guid userId);
    }
}
