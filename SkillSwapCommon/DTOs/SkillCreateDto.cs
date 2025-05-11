using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwapCommon.DTOs
{
    public class SkillCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreditValue { get; set; }
        public Guid OwnerId { get; set; }
    }
}
