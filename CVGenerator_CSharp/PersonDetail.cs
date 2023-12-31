namespace CVGenerator_CSharp
{
    public class PersonDetail
    {
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        public List<Education> Education { get; set; } = new List<Education>();
        public List<Expierence> Expierences { get; set; } = new List<Expierence>();
    }
}
