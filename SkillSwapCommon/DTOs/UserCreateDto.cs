using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwapCommon.DTOs
{
    public class UserCreateDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
