namespace CVGenerator_CSharp
{
    public record Expierence(string SchoolName, string function, DateTime StartDate, DateTime? EndDate)
    {
        public string a => $"{StartDate.Year} - {(EndDate == null ? "now" : EndDate.Value.Year)}";
        public bool Finished => EndDate != null;
    }
}
