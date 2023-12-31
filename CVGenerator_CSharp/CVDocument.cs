using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace CVGenerator_CSharp
{
    public class CVDocument : IDocument
    {
        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {

            });
        }
    }
}
