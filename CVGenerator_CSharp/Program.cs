using CVGenerator_CSharp;
using QuestPDF.Previewer;

var pdetail = Newtonsoft.Json.JsonConvert.DeserializeObject<PersonDetail>(File.ReadAllText("./PersonDetails.json"));

pdetail.Expierences = pdetail.Expierences.OrderByDescending(x => x.StartDate).ToList();
pdetail.Education = pdetail.Education.OrderByDescending(x => x.StartDate).ToList();

CVDocument document = new CVDocument(pdetail.GitHub, pdetail);
document
    .ShowInPreviewer();