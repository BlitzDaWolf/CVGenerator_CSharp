namespace CVGenerator
{
    public record Education (string SchoolName, string type, DateTime StartDate, DateTime? EndDate)
    {
        public string a => $"{StartDate.Year} - {(EndDate == null ? "now" : EndDate.Value.Year)}";
        public bool Finished => EndDate != null;
    }
}
