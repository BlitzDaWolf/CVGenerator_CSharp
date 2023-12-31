using CVGenerator_CSharp;
using QuestPDF.Fluent;
using QuestPDF.Previewer;

GitHub gitHub = new GitHub();

CVDocument document = new CVDocument();
document.ShowInPreviewer();

/*Document.Create(container =>
{
    container.Page(page =>
    {
        page.Header()
            .AlignCenter()
            .Text("Test")
            .FontSize(30);

        page.Content()
            .PaddingHorizontal(25)
            .BorderHorizontal(1);
    });
})
.ShowInPreviewer();*/