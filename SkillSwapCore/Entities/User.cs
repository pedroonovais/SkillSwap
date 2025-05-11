namespace SkillSwapCore.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public int Credits { get; set; }

        public ICollection<Skill> SkillsOffered { get; set; } = new List<Skill>();
        public ICollection<Transaction> TransactionsSent { get; set; } = new List<Transaction>();
        public ICollection<Transaction> TransactionsReceived { get; set; } = new List<Transaction>();
    }
}
