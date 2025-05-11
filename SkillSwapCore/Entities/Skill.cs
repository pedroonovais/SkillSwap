namespace SkillSwapCore.Entities
{
    public class Skill
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int CreditValue { get; set; }

        public Guid OwnerId { get; set; }
        public required User Owner { get; set; }
    }

}
