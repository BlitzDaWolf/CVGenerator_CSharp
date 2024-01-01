namespace CVGenerator.API.Entity
{
    public record SkillEntity : Skill
    {
        public SkillEntity(string Name, int Level) : base(Name, Level)
        {
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid PersonId { get; set; }
        public PersonEntity Person { get; set; }
    }
}
