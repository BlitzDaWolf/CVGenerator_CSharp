using CVGenerator_CSharp;
using QuestPDF;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

var pdetail = Newtonsoft.Json.JsonConvert.DeserializeObject<PersonDetail>(File.ReadAllText("./PersonDetails.json"));

pdetail.Expierences = pdetail.Expierences.OrderByDescending(x => x.StartDate).ToList();
pdetail.Education = pdetail.Education.OrderByDescending(x => x.StartDate).ToList();
pdetail.Skills = pdetail.Skills.OrderByDescending(x=> x.Level).ToList();

Settings.License = LicenseType.Community;

CVDocument document = new CVDocument(pdetail.GitHub, pdetail);
document
    .ShowInPreviewer();
    // .GeneratePdf($"./CV-{pdetail.FullName}.pdf");