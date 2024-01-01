using CVGenerator.API.Entiy;

namespace CVGenerator.API.Entity
{
    public class PersonEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Region { get; set; } = "";

        public string DriverLicence { get; set; } = "";
        public string LinkedIn { get; set; } = "";
        public string GitHub { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";

        public List<EducationEntity> Education { get; set; } = new List<EducationEntity>();
        public List<ExpierenceEntity> Expierences { get; set; } = new List<ExpierenceEntity>();
        public List<SkillEntity> Skills { get; set; } = new List<SkillEntity>();

        internal PersonDetail ToDetail()
        {
            return new PersonDetail
            {
                FirstName = FirstName,
                LastName = LastName,
                DriverLicence = DriverLicence,
                LinkedIn = LinkedIn,
                GitHub = GitHub,
                Email = Email,
                Phone = Phone,
                Expierences = Expierences.Select(x => x as Expierence).ToList(),
                Education = Education.Select(x => x as Education).ToList(),
                Skills = Skills.Select(x => x as Skill).ToList()
            };
        }
    }
}
