using CVGenerator_CSharp;
using QuestPDF.Previewer;

var pdetail = Newtonsoft.Json.JsonConvert.DeserializeObject<PersonDetail>(File.ReadAllText("./PersonDetails.json"));

CVDocument document = new CVDocument(pdetail.GitHub, pdetail);
document
    .ShowInPreviewer();