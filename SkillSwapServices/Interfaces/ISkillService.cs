using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillSwapCore.Entities;

namespace SkillSwapServices.Interfaces
{
    public interface ISkillService
    {
        Task AddAsync(Skill skill);
        Task<Skill> GetByIdAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
