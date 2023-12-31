using CVGenerator_CSharp;
using QuestPDF.Fluent;
using QuestPDF.Previewer;

GitHub gitHub = new GitHub();

CVDocument document = new CVDocument("blitzdawolf", new PersonDetail());
document
    .ShowInPreviewer();