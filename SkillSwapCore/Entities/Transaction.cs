using SkillSwapCommon.Enums;

namespace SkillSwapCore.Entities
{

    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid FromUserId { get; set; }
        public Guid ToUserId { get; set; }
        public Guid SkillId { get; set; }

        public DateTime RequestedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public TransactionStatus Status { get; set; }
        public int CreditValue { get; set; }
        public required Skill Skill { get; set; }
        public required User FromUser { get; set; }
        public required User ToUser { get; set; }
    }
}
