using CVGenerator.API.Entity;
using System.Text.Json.Serialization;

namespace CVGenerator.API.Entiy
{
    public record EducationEntity : Education
    {
        public EducationEntity(Education education) : base(education.SchoolName, education.type, education.StartDate, education.EndDate) { }

        public EducationEntity(string SchoolName, string type, DateTime StartDate, DateTime? EndDate) : base(SchoolName, type, StartDate, EndDate)
        {
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid PersonId { get; set; }
        public PersonEntity Person { get; set; }
    }
}
