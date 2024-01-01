namespace CVGenerator.API.Entity
{
    public record ExpierenceEntity : Expierence
    {
        public ExpierenceEntity(string JobName, string function, string Desctiption, DateTime StartDate, DateTime? EndDate) : base(JobName, function, Desctiption, StartDate, EndDate)
        {
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid PersonId { get; set; }
        public PersonEntity Person { get; set; }
    }
}
