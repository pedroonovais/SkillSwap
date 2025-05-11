using SkillSwapCommon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwapCommon.DTOs
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public Guid SkillId { get; set; }
        public Guid RequesterId { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
