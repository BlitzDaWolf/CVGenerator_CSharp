namespace CVGenerator
{
    public class PersonDetail
    {
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        public string DriverLicence { get; set; } = "";
        public string LinkedIn { get; set; } = "";
        public string GitHub { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";

        public List<Education> Education { get; set; } = new List<Education>();
        public List<Expierence> Expierences { get; set; } = new List<Expierence>();
        public List<Skill> Skills { get; set; } = new List<Skill>();
    }
}
