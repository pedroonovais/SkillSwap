using SkillSwapCommon.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwapCommon.Validators
{
    public static class SkillValidator
    {
        public static bool IsValid(SkillCreateDto dto)
        {
            return !string.IsNullOrWhiteSpace(dto.Title)
                && dto.CreditValue > 0
                && dto.OwnerId != Guid.Empty;
        }
    }
}
