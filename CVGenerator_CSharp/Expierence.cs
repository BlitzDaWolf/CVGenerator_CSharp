namespace CVGenerator_CSharp
{
    public record Expierence(string JobName, string function, string Desctiption, DateTime StartDate, DateTime? EndDate)
    {
        public string a => $"{StartDate.Year} - {(EndDate == null ? "now" : EndDate.Value.Year)}";
        public bool Finished => EndDate != null;
    }
}
